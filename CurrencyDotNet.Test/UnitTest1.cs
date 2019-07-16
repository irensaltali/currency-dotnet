using CurrencyDotNetCore;
using CurrencyDotNetCore.Model;
using Xunit;

namespace CurrencyDotNet.Test
{
    public class UnitTest1
    {
        protected CurrencyConverter converter;
        protected decimal roundStep = 0.05M;
        public UnitTest1()
        {
            converter = new CurrencyConverter(roundStep);
        }

        [Fact]
        public void ConversionTest()
        {
            var response1 = converter.Convert(Currency.TRY, 252M, Currency.EUR);
            var response2 = converter.Convert(Currency.TRY, 232M, Currency.GBP);
            var response3 = converter.Convert(Currency.EUR, 31M, Currency.USD);

            Assert.True(response1 % roundStep == 0);
            Assert.True(response2 % roundStep == 0);
            Assert.True(response3 % roundStep == 0);

        }
    }
}
