using CurrencyDotNetCore.Model;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace CurrencyDotNetCore
{
    public class CurrencyConverter
    {
        private TCMBModel TCMBData;
        private string DataSourceName;

        public CurrencyConverter()
        {
            GetTCMBData();

            DataSourceName = "TCMB";
        }

        //public CurrencyConverter(string DataSource)
        //{
        //    DataCollector DataCollector = new DataCollector();
        //    TCMBData = DataCollector.GetTCMBData();

        //    this.DataSourceName = DataSource;
        //}

        private void GetTCMBData()
        {

            XmlSerializer serializer = new XmlSerializer(typeof(TCMBModel));
            XmlTextReader reader = new XmlTextReader("http://www.tcmb.gov.tr/kurlar/today.xml");

            TCMBData = (TCMBModel)serializer.Deserialize(reader);
        }


        public double GetRate(Currency From, Currency To)
        {
            var fromCurrency = TCMBData.Currencies.Where(c => c.Kod == From.ToString()).FirstOrDefault();
            var toCurrency = TCMBData.Currencies.Where(c => c.Kod == To.ToString()).FirstOrDefault();
            double rate = 0;

            if (From.ToString() == To.ToString())
                rate = 1;
            else if (To.ToString() == "TRY")
            {
                if (string.IsNullOrEmpty(fromCurrency.ForexSelling))
                    return -1;
                else
                    rate = double.Parse(fromCurrency.ForexSelling, CultureInfo.InvariantCulture);

                if (fromCurrency.ToString() == "JPY" || fromCurrency.ToString() == "IRR")
                    rate = rate / 100;
            }
            else if (From.ToString() == "TRY")
            {
                if (string.IsNullOrEmpty(toCurrency.ForexSelling))
                    return -1;
                else
                {
                    rate = double.Parse(toCurrency.ForexSelling, CultureInfo.InvariantCulture);
                    rate = 1 / rate;
                }
            }
            else if (From.ToString() == "USD")
            {
                if (string.IsNullOrEmpty(toCurrency.CrossRateUSD) && string.IsNullOrEmpty(toCurrency.CrossRateOther))
                    return -1;
                else if (string.IsNullOrEmpty(toCurrency.CrossRateUSD))
                    rate = 1 / double.Parse(toCurrency.CrossRateOther, CultureInfo.InvariantCulture);
                else
                    rate = double.Parse(toCurrency.CrossRateUSD, CultureInfo.InvariantCulture);
            }
            else if (To.ToString() == "USD")
            {
                if (string.IsNullOrEmpty(fromCurrency.CrossRateUSD))
                    return -1;
                else
                {
                    rate = double.Parse(fromCurrency.CrossRateUSD, CultureInfo.InvariantCulture);
                    rate = 1 / rate;
                }
            }
            else
            {
                rate = double.Parse(fromCurrency.ForexSelling, CultureInfo.InvariantCulture) / double.Parse(toCurrency.ForexSelling, CultureInfo.InvariantCulture);
            }

            return rate;
        }

        public double Convert(Currency From, double FromAmount, Currency To)
        {
            var rate = GetRate(From, To);
            return rate * FromAmount;
        }
    }
}
