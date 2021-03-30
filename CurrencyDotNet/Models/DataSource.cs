using System.Collections.Generic;

namespace CurrencyDotNet.Models
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
                {"CBRT","http://www.TCMB.gov.tr/kurlar/today.xml"},
                //{"ECB","https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml"}
                {"Fixer","http://data.fixer.io/api/"}
            };

        /// <summary>
        /// Central Bank of The Republic Of Turkey
        /// </summary>
        public static readonly DataSource CBRT = new DataSource("CBRT");
        /// <summary>
        /// Central Bank of The Republic Of Turkey
        /// </summary>
        public static readonly DataSource Fixer = new DataSource("Fixer");

        ///// <summary>
        ///// European Central Bank
        ///// </summary>
        //public static readonly DataSource ECB = new DataSource("ECB");
    }
}
