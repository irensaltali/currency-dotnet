using CurrencyDotNet.Models;

namespace CurrencyDotNet
{
    public interface IConverter
    {
        decimal GetRate(Currency From, Currency To);
        decimal Convert(Currency From, decimal FromAmount, Currency To);
    }
}
