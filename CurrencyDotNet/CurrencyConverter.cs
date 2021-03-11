using CurrencyDotNet.Models;

namespace CurrencyDotNet
{
    public class CurrencyConverter
    {
        private IConverter converter;

        public CurrencyConverter(DataSource dataSource)
        {
            if (dataSource == DataSource.CBRT)
                converter = new CBRT.CBRTConverter();
        }
        public CurrencyConverter(DataSource dataSource, decimal roundStep)
        {
            if (dataSource == DataSource.CBRT)
                converter = new CBRT.CBRTConverter(roundStep);
        }

        public decimal GetRate(Currency From, Currency To) => converter.GetRate(From, To);

        public decimal Convert(Currency From, decimal FromAmount, Currency To) => converter.Convert(From, FromAmount, To);
    }
}
