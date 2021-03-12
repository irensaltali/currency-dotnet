using CurrencyDotNet.Models;

namespace CurrencyDotNet
{
    public interface IConverter
    {
        double GetRate(Currency From, Currency To);
        double Convert(Currency From, double FromAmount, Currency To);
    }
}
