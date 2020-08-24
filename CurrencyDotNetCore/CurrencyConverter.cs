using CurrencyDotNetCore.Model;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Caching;
using System;
using CurrencyDotNet.Model;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;

namespace CurrencyDotNetCore
{
    public class CurrencyConverter
    {
        private readonly decimal roundStep = 0M;
        private readonly DataSource currentDataSource = DataSource.TCMB;
        readonly ObjectCache cache = MemoryCache.Default;
        readonly CacheItemPolicy policy = new CacheItemPolicy();

        public CurrencyConverter(decimal roundStep = 0M, int secondsToCacheExpire = 3600)
        {
            if (roundStep > 0)
                this.roundStep = roundStep;

            policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(secondsToCacheExpire);
        }


        public CurrencyConverter(DataSource dataSource, decimal roundStep = 0M, int secondsToCacheExpire = 3600)
        {
            if (roundStep > 0)
                this.roundStep = roundStep;

            currentDataSource = dataSource;

            policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(secondsToCacheExpire);
        }


        #region TCMB
        private TCMBModel TCMBData
        {
            get
            {
                if (cache.Get("TCMBData") == null)
                {
                    return GetTCMBData();
                }
                else
                {
                    return (TCMBModel)cache.Get("TCMBData");
                }
            }
        }

        private TCMBModel GetTCMBData()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TCMBModel));
            XmlTextReader reader = new XmlTextReader("http://www.tcmb.gov.tr/kurlar/today.xml");
            var TCMBData = (TCMBModel)serializer.Deserialize(reader);

            cache.Set("TCMBData", TCMBData, policy);

            return TCMBData;
        }

        private decimal GetRateForTCMB(Currency From, Currency To)
        {
            try
            {
                var fromCurrency = TCMBData.Currencies.Where(c => c.Kod == From.InternationalCode).FirstOrDefault();
                var toCurrency = TCMBData.Currencies.Where(c => c.Kod == To.InternationalCode).FirstOrDefault();


                if (From.InternationalCode == To.InternationalCode)
                    return 1;
                else if (To.InternationalCode == "TRY")
                {
                    if (fromCurrency.BanknoteSelling > 0)
                        return fromCurrency.BanknoteSelling / fromCurrency.Unit;
                    else if (fromCurrency.ForexSelling > 0)
                        return fromCurrency.ForexSelling / fromCurrency.Unit;
                    else
                        return -1;

                }
                else if (From.InternationalCode == "TRY")
                {
                    if (toCurrency.BanknoteSelling > 0)
                        return 1 / (toCurrency.BanknoteSelling / toCurrency.Unit);
                    else if (toCurrency.ForexSelling > 0)
                        return 1 / (toCurrency.ForexSelling / toCurrency.Unit);
                    else
                        return -1;
                }
                else if (From.InternationalCode == "USD")
                {
                    if (toCurrency.CrossRateUSD > 0)
                        return toCurrency.CrossRateUSD / toCurrency.Unit;
                    else if (toCurrency.CrossRateOther > 0)
                        return 1 / (toCurrency.CrossRateOther / toCurrency.Unit);
                    else
                        return -1;
                }
                else if (To.InternationalCode == "USD")
                {
                    if (fromCurrency.CrossRateUSD > 0)
                        return 1 / (fromCurrency.CrossRateUSD / fromCurrency.Unit);
                    else if (fromCurrency.CrossRateOther > 0)
                        return fromCurrency.CrossRateOther / fromCurrency.Unit;
                    else
                        return -1;
                }
                else
                {
                    if (fromCurrency.BanknoteSelling > 0 && toCurrency.BanknoteSelling > 0)
                        return (fromCurrency.BanknoteSelling / fromCurrency.Unit) / (toCurrency.BanknoteSelling / toCurrency.Unit);
                    else if (fromCurrency.BanknoteSelling > 0 && fromCurrency.ForexSelling > 0)
                        return (fromCurrency.BanknoteSelling / fromCurrency.Unit) / (toCurrency.ForexSelling / toCurrency.Unit);
                    else if (fromCurrency.ForexSelling > 0 && fromCurrency.BanknoteSelling > 0)
                        return (fromCurrency.ForexSelling / fromCurrency.Unit) / (toCurrency.BanknoteSelling / toCurrency.Unit);
                    else if (fromCurrency.ForexSelling > 0 && fromCurrency.ForexSelling > 0)
                        return (fromCurrency.ForexSelling / fromCurrency.Unit) / (toCurrency.ForexSelling / toCurrency.Unit);
                    else
                        return -1;
                }
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        #endregion

        #region ECB
        private ECBModel ECBData
        {
            get
            {
                if (cache.Get("ECBData") == null)
                {
                    return GetECBDataAsync().GetAwaiter().GetResult();
                }
                else
                {
                    return (ECBModel)cache.Get("ECBData");
                }
            }
        }

        private async Task<ECBModel> GetECBDataAsync()
        {
            string file = null;
            using (var client = new HttpClient())
            {
                using (var result = await client.GetAsync("https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml"))
                {
                    if (result.IsSuccessStatusCode)
                    {
                        file = await result.Content.ReadAsStringAsync();
                    }
                }
            }

            file = file.Replace("gesmes:", string.Empty);
            file = file.Replace("<Cube>\n", string.Empty);
            int Place = file.LastIndexOf("</Cube>\n");
            file = file.Remove(Place, ("</Cube>\n").Length).Insert(Place, string.Empty);
            file = file.Replace(" xmlns:gesmes=\"http://www.gesmes.org/xml/2002-08-01\" xmlns=\"http://www.ecb.int/vocabulary/2002-08-01/eurofxref\"", string.Empty);

            XmlSerializer serializer = new XmlSerializer(typeof(ECBModel));
            StringReader reader = new StringReader(file);
            var ECBData = (ECBModel)serializer.Deserialize(reader);

            cache.Set("ECBData", ECBData, policy);

            return ECBData;
        }

        private decimal GetRateForECB(Currency From, Currency To)
        {
            var ec = ECBData;
            try
            {
                var fromCurrency = ECBData.Cube.CubeWithCurrencies.Where(c => c.Currency == From.InternationalCode).FirstOrDefault();
                var toCurrency = ECBData.Cube.CubeWithCurrencies.Where(c => c.Currency == To.InternationalCode).FirstOrDefault();

                if (From == To)
                    return 1;
                else if (To == Currency.EUR)
                {
                    return 1 / fromCurrency.Rate;


                }
                else if (From == Currency.EUR)
                {
                    return fromCurrency.Rate;

                }
                else
                {
                    return toCurrency.Rate / fromCurrency.Rate;
                }
            }
            catch (Exception e)
            {
                return -1;
            }
        }
        #endregion

        public decimal GetRate(Currency From, Currency To)
        {
            if (currentDataSource == DataSource.TCMB)
            {
                return GetRateForTCMB(From, To);
            }
            else if (currentDataSource == DataSource.ECB)
            {
                return GetRateForECB(From, To);
            }
            else
            {
                return -1;
            }
        }


        public decimal Convert(Currency From, decimal FromAmount, Currency To)
        {
            var rate = GetRate(From, To);
            if (roundStep > 0)
                return Round(rate * FromAmount);
            else
                return rate * FromAmount;
        }

        private decimal Round(decimal d)
        {
            var modRemainder = d % roundStep;
            var baseValue = d - modRemainder;

            if (modRemainder > 0)
                return baseValue + roundStep;
            else
                return baseValue;
        }
    }
}
