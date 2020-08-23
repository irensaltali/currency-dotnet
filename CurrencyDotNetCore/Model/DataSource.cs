using System.Collections.Generic;

namespace CurrencyDotNet.Model
{
    public class DataSource
    {
        public string DataSourceAddress;
        public DataSource(string source)
        {
            DataSourceAddresses.TryGetValue(source, out DataSourceAddress);
        }

        private static readonly Dictionary<string, string> DataSourceAddresses = new Dictionary<string, string>
            {
                {"TCMB","http://www.tcmb.gov.tr/kurlar/today.xml"},
                {"ECB","https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml"}
            };

        /// <summary>
        /// Türkiye Cumhuriyeti Merkez Bankası - Central Bank of The Republic Of Turkey)
        /// </summary>
        public static readonly DataSource TCMB = new DataSource("TCMB");

        /// <summary>
        /// European Central Bank
        /// </summary>
        public static readonly DataSource ECB = new DataSource("ECB");
    }
}
