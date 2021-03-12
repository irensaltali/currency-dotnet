using System;
using System.Net;
using System.Runtime.Caching;
using Newtonsoft.Json;
using CurrencyDotNet.Models;

namespace CurrencyDotNet.Fixer
{
    public class FixerConverter : IConverter
    {
        private readonly double roundStep;
        private readonly string APIKey;
        readonly ObjectCache cache = MemoryCache.Default;
        readonly CacheItemPolicy policy = new CacheItemPolicy();

        public FixerConverter(string _APIKey, double roundStep = 0, int secondsToCacheExpire = 3600)
        {
            if (roundStep > 0)
                this.roundStep = roundStep;

            APIKey = _APIKey;
            policy.AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(secondsToCacheExpire);
        }

        private FixerModel FixerData
        {
            get
            {
                if (cache.Get("FixerData") == null)
                {
                    return GetFixerData();
                }
                else
                {
                    return (FixerModel)cache.Get("FixerData");
                }
            }
        }

        private FixerModel GetFixerData()
        {
            var json = new WebClient().DownloadString("http://data.fixer.io/api/latest?access_key=" + APIKey);
            var FixerData = JsonConvert.DeserializeObject<FixerModel>(json);

            cache.Set("FixerData", FixerData, policy);

            return FixerData;

        }

        public double GetRate(Currency From, Currency To)
        {
            try
            {
                FixerData.Rates.TryGetValue(From.InternationalCode, out double fromCurrency);
                FixerData.Rates.TryGetValue(To.InternationalCode, out double toCurrency);
                FixerData.Rates.TryGetValue(FixerData.BaseCurrency, out double baseCurrency);



                if (From.InternationalCode == To.InternationalCode)
                    return 1;
                else if (To.InternationalCode == FixerData.BaseCurrency)
                {
                    return toCurrency;
                }
                else if (From.InternationalCode == FixerData.BaseCurrency)
                {
                    return 1/toCurrency;
                }
                else
                {
                    return toCurrency / fromCurrency;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public double Convert(Currency From, double FromAmount, Currency To)
        {
            var rate = GetRate(From, To);
            if (roundStep > 0)
                return Round(rate * FromAmount);
            else
                return rate * FromAmount;
        }

        private double Round(double d)
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
