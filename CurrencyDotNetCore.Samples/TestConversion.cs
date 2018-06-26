using CurrencyDotNetCore.Model;
using NUnit.Framework;

namespace CurrencyDotNetCore.Samples
{
    class TestConversion : Sample
    {
        [Test]
        public void ConversionTest()
        {
            var response1 = converter.Convert(Currency.TRY, 252M, Currency.EUR);
            var response2 = converter.Convert(Currency.TRY, 232M, Currency.GBP);
            var response3 = converter.Convert(Currency.EUR, 31M, Currency.USD);

            Assert.IsTrue(response1 % roundStep == 0);
            Assert.IsTrue(response2 % roundStep == 0);
            Assert.IsTrue(response3 % roundStep == 0);
        }
    }
}
