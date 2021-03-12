using CurrencyDotNet.Models;

namespace CurrencyDotNet
{
    public class CurrencyConverter
    {
        private IConverter converter;

        public CurrencyConverter(DataSource dataSource, double roundStep = 0.01, string APIKey = null)
        {
            if (dataSource == DataSource.CBRT)
                converter = new CBRT.CBRTConverter(roundStep);
            else if (dataSource == DataSource.Fixer && string.IsNullOrEmpty(APIKey))
                throw new System.ArgumentNullException("APIKey", "API Key can not be null or empty for Fixer API");
            else if (dataSource == DataSource.Fixer && !string.IsNullOrEmpty(APIKey))
                converter = new Fixer.FixerConverter("e2faf5febf3324c2906e568bba367252", roundStep);
        }

        public double GetRate(Currency From, Currency To) => converter.GetRate(From, To);

        public double Convert(Currency From, double FromAmount, Currency To) => converter.Convert(From, FromAmount, To);
    }
}
