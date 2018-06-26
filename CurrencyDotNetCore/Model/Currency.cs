using System.Collections.Generic;

namespace CurrencyDotNetCore.Model
{
    public sealed class Currency
    {

        private readonly string _internationalCode;
        private readonly string _nameInEnglish;
        private readonly string _nameInTurkish;
        private readonly string _symbol;

        public string InternationalCode { get { return _internationalCode; } }
        public string NameInEnglish { get { return _nameInEnglish; } }
        public string NameInTurkish { get { return _nameInTurkish; } }
        public string Symbol { get { return _symbol; } }


        private readonly Dictionary<string, string> NamesInEnglish = new Dictionary<string, string>
            {
                {"TRY","Turkish Lira"},
                {"USD","US Dolar"},
                {"AUD","Australian Dollar"},
                {"DKK","Danish Krone"},
                {"EUR","Euro"},
                {"GBP","Pound"},
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
        private readonly Dictionary<string, string> NamesInTurkish = new Dictionary<string, string>
            {
                {"TRY","Türk Lirası"},
                {"USD","Amerikan Doları"},
                {"AUD","Avustralya Doları"},
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
        private readonly Dictionary<string, string> MatchingCulture = new Dictionary<string, string>
            {
                {"TRY","tr-TR"},
                {"USD","en-US"},
                {"AUD","en-AU"},
                {"DKK","da-DK"},
                {"EUR","en-150"},
                {"GBP","en"},
                {"CHF","de-CH"},
                {"SEK","sv-SE"},
                {"CAD","en-CA"},
                {"KWD","ar-KW"},
                {"NOK","nb-NO"},
                {"SAR","ar-SA"},
                {"JPY","ja-JP"},
                {"BGN","bg-BG"},
                {"RON","ro-RO"},
                {"RUB","ru-RU"},
                {"IRR","fa-IR"},
                {"CNY","zh-CN"},
                {"PKR","en-PK"}
            };
        private readonly Dictionary<string, string> CurrencySymbol = new Dictionary<string, string>
            {
                {"TRY","₺"},
                {"USD","$"},
                {"AUD","$"},
                {"DKK","kr."},
                {"EUR","€"},
                {"GBP","£"},
                {"CHF","fr."},
                {"SEK","kr"},
                {"CAD","$"},
                {"KWD","د.ك.‏"},
                {"NOK","kr"},
                {"SAR","ر.س."},
                {"JPY","¥"},
                {"BGN","лв."},
                {"RON","lei"},
                {"RUB","р."},
                {"IRR","ريال"},
                {"CNY","¥"},
                {"PKR","Rs"}
            };

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

        public Currency(string value)
        {
            _internationalCode = value;
            NamesInEnglish.TryGetValue(value, out _nameInEnglish);
            NamesInTurkish.TryGetValue(value, out _nameInTurkish);
            CurrencySymbol.TryGetValue(value, out _symbol);
        }

        public override string ToString()
        {
            return _internationalCode;
        }


    }
}
