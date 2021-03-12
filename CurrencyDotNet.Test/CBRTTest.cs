using CurrencyDotNet.Models;
using Xunit;

namespace CurrencyDotNet.Test
{
    public class CBRTTest
    {
        protected CurrencyConverter converter;
        protected double roundStep = 0.05;
        public CBRTTest()
        {
            converter = new CurrencyConverter(DataSource.CBRT, roundStep);
        }

        [Fact]
        public void ConversionTestFromTRY()
        {
            var response1 = converter.Convert(Currency.TRY, 252, Currency.EUR);
            var response2 = converter.Convert(Currency.TRY, 232, Currency.GBP);

            Assert.True(response1 % roundStep == 0);
            Assert.True(response1 > 0);
            Assert.True(response2 % roundStep == 0);
            Assert.True(response2 > 0);

        }

        [Fact]
        public void CrossConversionTest()
        {
            var response = converter.Convert(Currency.EUR, 31, Currency.USD);

            Assert.True(response % roundStep == 0);
            Assert.True(response > 0);
        }

        [Fact]
        public void TestAllCurrencies()
        {
            foreach (var currency1 in Currency.CurrencySymbol)
            {
                foreach (var currency2 in Currency.CurrencySymbol)
                {
                    var currencyFrom = new Currency(currency1.Key);
                    var currencyto = new Currency(currency2.Key);

                    var result = converter.GetRate(currencyFrom, currencyto);

                    Assert.True(result > 0);
                }
            }
        }

    }
}
