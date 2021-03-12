using CurrencyDotNet.Models;

namespace CurrencyDotNet
{
    public class CurrencyConverter
    {
        private IConverter converter;

        public CurrencyConverter(DataSource dataSource, decimal roundStep = 0.01M, string APIKey = null)
        {
            if (dataSource == DataSource.CBRT)
                converter = new CBRT.CBRTConverter(roundStep);
            else if (dataSource == DataSource.Fixer && string.IsNullOrEmpty(APIKey))
                throw new System.ArgumentNullException("APIKey", "API Key can not be null or empty for Fixer API");
            else if (dataSource == DataSource.Fixer && !string.IsNullOrEmpty(APIKey))
                converter = new Fixer.FixerConverter(APIKey, roundStep);
        }

        public decimal GetRate(Currency From, Currency To) => converter.GetRate(From, To);

        public decimal Convert(Currency From, decimal FromAmount, Currency To) => converter.Convert(From, FromAmount, To);
    }
}
