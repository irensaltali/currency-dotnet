using NUnit.Framework;

namespace CurrencyDotNetCore.Samples
{
    public class Sample
    {
        protected CurrencyConverter converter;
        protected decimal roundStep = 0.05M;

        [SetUp]
        public void Initialize()
        {
            converter = new CurrencyConverter(roundStep);
        }
    }
}
