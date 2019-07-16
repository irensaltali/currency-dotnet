using CurrencyDotNetCore.Model;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Caching;
using System;

namespace CurrencyDotNetCore
{
    public class CurrencyConverter
    {
        
        private readonly decimal roundStep = 0M;
        readonly ObjectCache cache = MemoryCache.Default;
        readonly CacheItemPolicy policy = new CacheItemPolicy();

        public CurrencyConverter(decimal roundStep = 0M, int secondsToCacheExpire=3600)
        {
            if (roundStep > 0)
                this.roundStep = roundStep;

            policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(secondsToCacheExpire);
        }

        //public CurrencyConverter(string DataSource)
        //{
        //    DataCollector DataCollector = new DataCollector();
        //    TCMBData = DataCollector.GetTCMBData();

        //    this.DataSourceName = DataSource;
        //}

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


        public decimal GetRate(Currency From, Currency To)
        {
            var fromCurrency = TCMBData.Currencies.Where(c => c.Kod == From.InternationalCode).FirstOrDefault();
            var toCurrency = TCMBData.Currencies.Where(c => c.Kod == To.InternationalCode).FirstOrDefault();
            decimal rate = 0;

            if (From.InternationalCode == To.InternationalCode)
                rate = 1;
            else if (To.InternationalCode == "TRY")
            {
                if (string.IsNullOrEmpty(fromCurrency.ForexSelling))
                    return -1;
                else
                    rate = decimal.Parse(fromCurrency.ForexSelling, CultureInfo.InvariantCulture);

                if (fromCurrency.ToString() == "JPY" || fromCurrency.ToString() == "IRR")
                    rate = rate / 100;
            }
            else if (From.InternationalCode == "TRY")
            {
                if (string.IsNullOrEmpty(toCurrency.ForexSelling))
                    return -1;
                else
                {
                    rate = decimal.Parse(toCurrency.ForexSelling, CultureInfo.InvariantCulture);
                    rate = 1 / rate;
                }
            }
            else if (From.InternationalCode == "USD")
            {
                if (string.IsNullOrEmpty(toCurrency.CrossRateUSD) && string.IsNullOrEmpty(toCurrency.CrossRateOther))
                    return -1;
                else if (string.IsNullOrEmpty(toCurrency.CrossRateUSD))
                    rate = 1 / decimal.Parse(toCurrency.CrossRateOther, CultureInfo.InvariantCulture);
                else
                    rate = decimal.Parse(toCurrency.CrossRateUSD, CultureInfo.InvariantCulture);
            }
            else if (To.InternationalCode == "USD")
            {
                if (string.IsNullOrEmpty(fromCurrency.CrossRateUSD))
                    return -1;
                else
                {
                    rate = decimal.Parse(fromCurrency.CrossRateUSD, CultureInfo.InvariantCulture);
                    rate = 1 / rate;
                }
            }
            else
            {
                rate = decimal.Parse(fromCurrency.ForexSelling, CultureInfo.InvariantCulture) / decimal.Parse(toCurrency.ForexSelling, CultureInfo.InvariantCulture);
            }

            return rate;
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
