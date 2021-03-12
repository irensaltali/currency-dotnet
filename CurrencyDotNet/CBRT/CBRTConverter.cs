using CurrencyDotNet.Models;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Caching;
using System;

namespace CurrencyDotNet.CBRT
{
    public class CBRTConverter : IConverter
    {
        private readonly decimal roundStep;
        readonly ObjectCache cache = MemoryCache.Default;
        readonly CacheItemPolicy policy = new CacheItemPolicy();

        public CBRTConverter(decimal roundStep = 0, int secondsToCacheExpire = 3600)
        {
            if (roundStep > 0)
                this.roundStep = roundStep;

            policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(secondsToCacheExpire);
        }

        private CBRTModel CBRTData
        {
            get
            {
                if (cache.Get("CBRTData") == null)
                {
                    return GetCBRTData();
                }
                else
                {
                    return (CBRTModel)cache.Get("CBRTData");
                }
            }
        }

        private CBRTModel GetCBRTData()
        {

            XmlSerializer serializer = new XmlSerializer(typeof(CBRTModel));
            XmlTextReader reader = new XmlTextReader("http://www.tcmb.gov.tr/kurlar/today.xml");
            var CBRTData = (CBRTModel)serializer.Deserialize(reader);

            cache.Set("CBRTData", CBRTData, policy);

            return CBRTData;

        }


        public decimal GetRate(Currency From, Currency To)
        {
            try
            {
                var fromCurrency = CBRTData.Currencies.Where(c => c.Kod == From.InternationalCode).FirstOrDefault();
                var toCurrency = CBRTData.Currencies.Where(c => c.Kod == To.InternationalCode).FirstOrDefault();


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
                        return toCurrency.CrossRateUSD;
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
            catch (Exception)
            {
                throw;
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
