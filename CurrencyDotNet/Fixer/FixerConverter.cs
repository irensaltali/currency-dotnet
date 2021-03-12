using System;
using System.Net;
using System.Runtime.Caching;
using Newtonsoft.Json;
using CurrencyDotNet.Models;

namespace CurrencyDotNet.Fixer
{
    public class FixerConverter : IConverter
    {
        private readonly decimal roundStep;
        private readonly string APIKey;
        readonly ObjectCache cache = MemoryCache.Default;
        readonly CacheItemPolicy policy = new CacheItemPolicy();

        public FixerConverter(string _APIKey, decimal roundStep = 0, int secondsToCacheExpire = 3600)
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

            if (!FixerData.Success)
                throw new Exception(FixerData.Error.Info);

            cache.Set("FixerData", FixerData, policy);

            return FixerData;

        }

        public decimal GetRate(Currency From, Currency To)
        {
            try
            {
                FixerData.Rates.TryGetValue(From.InternationalCode, out decimal fromRate);
                FixerData.Rates.TryGetValue(To.InternationalCode, out decimal toRate);
                FixerData.Rates.TryGetValue(FixerData.BaseCurrency, out decimal baseRate);



                if (From.InternationalCode == To.InternationalCode)
                    return 1;
                else if (To.InternationalCode == FixerData.BaseCurrency)
                {
                    return 1/fromRate;
                }
                else if (From.InternationalCode == FixerData.BaseCurrency)
                {
                    return 1/toRate;
                }
                else
                {
                    return toRate / fromRate;
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
