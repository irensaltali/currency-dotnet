using System.Collections.Generic;
using System.Threading;

namespace CurrencyDotNetCore.Model
{
    public sealed class Currency
    {

        private readonly string internationalCode;
        private readonly Dictionary<string, string> NamesInEnglish;
        private readonly Dictionary<string, string> NamesInTurkish;

        public static readonly Currency TRY = new Currency("TRY");
        public static readonly Currency USD = new Currency("USD");
        public static readonly Currency AUD = new Currency("AUD");
        public static readonly Currency DKK = new Currency("DKK");
        public static readonly Currency EUR = new Currency("EUR");
        public static readonly Currency GBP = new Currency("GBP");
        public static readonly Currency CHF = new Currency("CHF");
        public static readonly Currency SEK = new Currency("SEK");
        public static readonly Currency CAD = new Currency("CAD");
        public static readonly Currency KWD = new Currency("KWD");
        public static readonly Currency NOK = new Currency("NOK");
        public static readonly Currency SAR = new Currency("SAR");
        public static readonly Currency JPY = new Currency("JPY");
        public static readonly Currency BGN = new Currency("BGN");
        public static readonly Currency RON = new Currency("RON");
        public static readonly Currency RUB = new Currency("RUB");
        public static readonly Currency IRR = new Currency("IRR");
        public static readonly Currency CNY = new Currency("CNY");
        public static readonly Currency PKR = new Currency("PKR");

        private Currency(string value)
        {
            this.internationalCode = value;
            this.NamesInEnglish = new Dictionary<string, string>
            {
                {"TRY","Turkish Lira"},
                {"USD","US Dolar"},
                {"AUD","Australian Dollar"},
                {"DKK","Danish Krone"},
                {"EUR","Euro"},
                {"GBP","Pound Sterling"},
                {"CHF","Swiss Franc"},
                {"SEK","Swedish Krona"},
                {"CAD","Canadian Dollar"},
                {"KWD","Kuwaiti Dinar"},
                {"NOK","Norwegian Krone"},
                {"SAR","Saudi Riyal"},
                {"JPY","Japanese Yen"},
                {"BGN","Bulgarian Lev"},
                {"RON","Romanian Leu"},
                {"RUB","Russian Ruble"},
                {"IRR","Iranian Rial"},
                {"CNY","Chinese Yuan"},
                {"PKR","Pakistan Rupee"}
            };
            this.NamesInTurkish = new Dictionary<string, string>
            {
                {"TRY","Türk Lirası"},
                {"USD","Amerikan Doları"},
                {"AUD","Avustralya Dolaru"},
                {"DKK","Danimarka Kronu"},
                {"EUR","Euro"},
                {"GBP","İngiliz Siterlini"},
                {"CHF","İsvişre Frangı"},
                {"SEK","İsveç Kronu"},
                {"CAD","Kanada Doları"},
                {"KWD","Kuveyt Dinarı"},
                {"NOK","Norveç Kronu"},
                {"SAR","Suudi Arabistan Riyali"},
                {"JPY","Japon Yeni"},
                {"BGN","Bulgar Levası"},
                {"RON","Rumen Leyi"},
                {"RUB","Rus Rublesi"},
                {"IRR","Iran Riyali"},
                {"CNY","Çin Yuanı"},
                {"PKR","Pakistan Rupisi"}
            };
        }
        

        public override string ToString()
        {
            return internationalCode;
        }

        public string GetName()
        {
            string currentLang = Thread.CurrentThread.CurrentCulture.Name;
            string name;

            if (currentLang == "tr-TR")
                NamesInTurkish.TryGetValue(internationalCode, out name);
            else if (currentLang == "en-US")
                NamesInEnglish.TryGetValue(internationalCode, out name);
            else
                NamesInEnglish.TryGetValue(internationalCode, out name);

            return name;
        }
        
    }
}
