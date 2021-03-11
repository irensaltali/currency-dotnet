using System.Collections.Generic;

namespace CurrencyDotNet.Models
{
    public sealed class Currency
    {

        private readonly string _internationalCode;
        private readonly string _nameInEnglish;
        private readonly string _symbol;

        public string InternationalCode { get { return _internationalCode; } }
        public string NameInEnglish { get { return _nameInEnglish; } }
        public string Symbol { get { return _symbol; } }


        public static readonly Dictionary<string, string> NamesInEnglish = new Dictionary<string, string>
            {
                {"AED", "United Arab Emirates Dirham"},
                {"AFN", "Afghan Afghani"},
                {"ALL", "Albanian Lek"},
                {"AMD", "Armenian Dram"},
                {"ANG", "Netherlands Antillean Guilder"},
                {"AOA", "Angolan Kwanza"},
                {"ARS", "Argentine Peso"},
                {"AUD", "Australian Dollar"},
                {"AWG", "Aruban Florin"},
                {"AZN", "Azerbaijani Manat"},
                {"BAM", "Bosnia-Herzegovina Convertible Mark"},
                {"BBD", "Barbadian Dollar"},
                {"BDT", "Bangladeshi Taka"},
                {"BGN", "Bulgarian Lev"},
                {"BHD", "Bahraini Dinar"},
                {"BIF", "Burundian Franc"},
                {"BMD", "Bermudan Dollar"},
                {"BND", "Brunei Dollar"},
                {"BOB", "Bolivian Boliviano"},
                {"BRL", "Brazilian Real"},
                {"BSD", "Bahamian Dollar"},
                {"BTC", "Bitcoin"},
                {"BTN", "Bhutanese Ngultrum"},
                {"BWP", "Botswanan Pula"},
                {"BYN", "New Belarusian Ruble"},
                {"BYR", "Belarusian Ruble"},
                {"BZD", "Belize Dollar"},
                {"CAD", "Canadian Dollar"},
                {"CDF", "Congolese Franc"},
                {"CHF", "Swiss Franc"},
                {"CLF", "Chilean Unit of Account (UF)"},
                {"CLP", "Chilean Peso"},
                {"CNY", "Chinese Yuan"},
                {"COP", "Colombian Peso"},
                {"CRC", "Costa Rican Colón"},
                {"CUC", "Cuban Convertible Peso"},
                {"CUP", "Cuban Peso"},
                {"CVE", "Cape Verdean Escudo"},
                {"CZK", "Czech Republic Koruna"},
                {"DJF", "Djiboutian Franc"},
                {"DKK", "Danish Krone"},
                {"DOP", "Dominican Peso"},
                {"DZD", "Algerian Dinar"},
                {"EGP", "Egyptian Pound"},
                {"ERN", "Eritrean Nakfa"},
                {"ETB", "Ethiopian Birr"},
                {"EUR", "Euro"},
                {"FJD", "Fijian Dollar"},
                {"FKP", "Falkland Islands Pound"},
                {"GBP", "British Pound Sterling"},
                {"GEL", "Georgian Lari"},
                {"GGP", "Guernsey Pound"},
                {"GHS", "Ghanaian Cedi"},
                {"GIP", "Gibraltar Pound"},
                {"GMD", "Gambian Dalasi"},
                {"GNF", "Guinean Franc"},
                {"GTQ", "Guatemalan Quetzal"},
                {"GYD", "Guyanaese Dollar"},
                {"HKD", "Hong Kong Dollar"},
                {"HNL", "Honduran Lempira"},
                {"HRK", "Croatian Kuna"},
                {"HTG", "Haitian Gourde"},
                {"HUF", "Hungarian Forint"},
                {"IDR", "Indonesian Rupiah"},
                {"ILS", "Israeli New Sheqel"},
                {"IMP", "Manx pound"},
                {"INR", "Indian Rupee"},
                {"IQD", "Iraqi Dinar"},
                {"IRR", "Iranian Rial"},
                {"ISK", "Icelandic Króna"},
                {"JEP", "Jersey Pound"},
                {"JMD", "Jamaican Dollar"},
                {"JOD", "Jordanian Dinar"},
                {"JPY", "Japanese Yen"},
                {"KES", "Kenyan Shilling"},
                {"KGS", "Kyrgystani Som"},
                {"KHR", "Cambodian Riel"},
                {"KMF", "Comorian Franc"},
                {"KPW", "North Korean Won"},
                {"KRW", "South Korean Won"},
                {"KWD", "Kuwaiti Dinar"},
                {"KYD", "Cayman Islands Dollar"},
                {"KZT", "Kazakhstani Tenge"},
                {"LAK", "Laotian Kip"},
                {"LBP", "Lebanese Pound"},
                {"LKR", "Sri Lankan Rupee"},
                {"LRD", "Liberian Dollar"},
                {"LSL", "Lesotho Loti"},
                {"LTL", "Lithuanian Litas"},
                {"LVL", "Latvian Lats"},
                {"LYD", "Libyan Dinar"},
                {"MAD", "Moroccan Dirham"},
                {"MDL", "Moldovan Leu"},
                {"MGA", "Malagasy Ariary"},
                {"MKD", "Macedonian Denar"},
                {"MMK", "Myanma Kyat"},
                {"MNT", "Mongolian Tugrik"},
                {"MOP", "Macanese Pataca"},
                {"MRO", "Mauritanian Ouguiya"},
                {"MUR", "Mauritian Rupee"},
                {"MVR", "Maldivian Rufiyaa"},
                {"MWK", "Malawian Kwacha"},
                {"MXN", "Mexican Peso"},
                {"MYR", "Malaysian Ringgit"},
                {"MZN", "Mozambican Metical"},
                {"NAD", "Namibian Dollar"},
                {"NGN", "Nigerian Naira"},
                {"NIO", "Nicaraguan Córdoba"},
                {"NOK", "Norwegian Krone"},
                {"NPR", "Nepalese Rupee"},
                {"NZD", "New Zealand Dollar"},
                {"OMR", "Omani Rial"},
                {"PAB", "Panamanian Balboa"},
                {"PEN", "Peruvian Nuevo Sol"},
                {"PGK", "Papua New Guinean Kina"},
                {"PHP", "Philippine Peso"},
                {"PKR", "Pakistani Rupee"},
                {"PLN", "Polish Zloty"},
                {"PYG", "Paraguayan Guarani"},
                {"QAR", "Qatari Rial"},
                {"RON", "Romanian Leu"},
                {"RSD", "Serbian Dinar"},
                {"RUB", "Russian Ruble"},
                {"RWF", "Rwandan Franc"},
                {"SAR", "Saudi Riyal"},
                {"SBD", "Solomon Islands Dollar"},
                {"SCR", "Seychellois Rupee"},
                {"SDG", "Sudanese Pound"},
                {"SEK", "Swedish Krona"},
                {"SGD", "Singapore Dollar"},
                {"SHP", "Saint Helena Pound"},
                {"SLL", "Sierra Leonean Leone"},
                {"SOS", "Somali Shilling"},
                {"SRD", "Surinamese Dollar"},
                {"STD", "São Tomé and Príncipe Dobra"},
                {"SVC", "Salvadoran Colón"},
                {"SYP", "Syrian Pound"},
                {"SZL", "Swazi Lilangeni"},
                {"THB", "Thai Baht"},
                {"TJS", "Tajikistani Somoni"},
                {"TMT", "Turkmenistani Manat"},
                {"TND", "Tunisian Dinar"},
                {"TOP", "Tongan Paʻanga"},
                {"TRY", "Turkish Lira"},
                {"TTD", "Trinidad and Tobago Dollar"},
                {"TWD", "New Taiwan Dollar"},
                {"TZS", "Tanzanian Shilling"},
                {"UAH", "Ukrainian Hryvnia"},
                {"UGX", "Ugandan Shilling"},
                {"USD", "United States Dollar"},
                {"UYU", "Uruguayan Peso"},
                {"UZS", "Uzbekistan Som"},
                {"VEF", "Venezuelan Bolívar Fuerte"},
                {"VND", "Vietnamese Dong"},
                {"VUV", "Vanuatu Vatu"},
                {"WST", "Samoan Tala"},
                {"XAF", "CFA Franc BEAC"},
                {"XAG", "Silver (troy ounce)"},
                {"XAU", "Gold (troy ounce)"},
                {"XCD", "East Caribbean Dollar"},
                {"XDR", "Special Drawing Rights"},
                {"XOF", "CFA Franc BCEAO"},
                {"XPF", "CFP Franc"},
                {"YER", "Yemeni Rial"},
                {"ZAR", "South African Rand"},
                {"ZMK", "Zambian Kwacha (pre-2013)"},
                {"ZMW", "Zambian Kwacha"},
                {"ZWL", "Zimbabwean Dollar"}
            };

        public static readonly Dictionary<string, string> CurrencySymbol = new Dictionary<string, string>
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

        public static readonly Currency AED = new Currency("AED");
        public static readonly Currency AFN = new Currency("AFN");
        public static readonly Currency ALL = new Currency("ALL");
        public static readonly Currency AMD = new Currency("AMD");
        public static readonly Currency ANG = new Currency("ANG");
        public static readonly Currency AOA = new Currency("AOA");
        public static readonly Currency ARS = new Currency("ARS");
        public static readonly Currency AUD = new Currency("AUD");
        public static readonly Currency AWG = new Currency("AWG");
        public static readonly Currency AZN = new Currency("AZN");
        public static readonly Currency BAM = new Currency("BAM");
        public static readonly Currency BBD = new Currency("BBD");
        public static readonly Currency BDT = new Currency("BDT");
        public static readonly Currency BGN = new Currency("BGN");
        public static readonly Currency BHD = new Currency("BHD");
        public static readonly Currency BIF = new Currency("BIF");
        public static readonly Currency BMD = new Currency("BMD");
        public static readonly Currency BND = new Currency("BND");
        public static readonly Currency BOB = new Currency("BOB");
        public static readonly Currency BRL = new Currency("BRL");
        public static readonly Currency BSD = new Currency("BSD");
        public static readonly Currency BTC = new Currency("BTC");
        public static readonly Currency BTN = new Currency("BTN");
        public static readonly Currency BWP = new Currency("BWP");
        public static readonly Currency BYN = new Currency("BYN");
        public static readonly Currency BYR = new Currency("BYR");
        public static readonly Currency BZD = new Currency("BZD");
        public static readonly Currency CAD = new Currency("CAD");
        public static readonly Currency CDF = new Currency("CDF");
        public static readonly Currency CHF = new Currency("CHF");
        public static readonly Currency CLF = new Currency("CLF");
        public static readonly Currency CLP = new Currency("CLP");
        public static readonly Currency CNY = new Currency("CNY");
        public static readonly Currency COP = new Currency("COP");
        public static readonly Currency CRC = new Currency("CRC");
        public static readonly Currency CUC = new Currency("CUC");
        public static readonly Currency CUP = new Currency("CUP");
        public static readonly Currency CVE = new Currency("CVE");
        public static readonly Currency CZK = new Currency("CZK");
        public static readonly Currency DJF = new Currency("DJF");
        public static readonly Currency DKK = new Currency("DKK");
        public static readonly Currency DOP = new Currency("DOP");
        public static readonly Currency DZD = new Currency("DZD");
        public static readonly Currency EGP = new Currency("EGP");
        public static readonly Currency ERN = new Currency("ERN");
        public static readonly Currency ETB = new Currency("ETB");
        public static readonly Currency EUR = new Currency("EUR");
        public static readonly Currency FJD = new Currency("FJD");
        public static readonly Currency FKP = new Currency("FKP");
        public static readonly Currency GBP = new Currency("GBP");
        public static readonly Currency GEL = new Currency("GEL");
        public static readonly Currency GGP = new Currency("GGP");
        public static readonly Currency GHS = new Currency("GHS");
        public static readonly Currency GIP = new Currency("GIP");
        public static readonly Currency GMD = new Currency("GMD");
        public static readonly Currency GNF = new Currency("GNF");
        public static readonly Currency GTQ = new Currency("GTQ");
        public static readonly Currency GYD = new Currency("GYD");
        public static readonly Currency HKD = new Currency("HKD");
        public static readonly Currency HNL = new Currency("HNL");
        public static readonly Currency HRK = new Currency("HRK");
        public static readonly Currency HTG = new Currency("HTG");
        public static readonly Currency HUF = new Currency("HUF");
        public static readonly Currency IDR = new Currency("IDR");
        public static readonly Currency ILS = new Currency("ILS");
        public static readonly Currency IMP = new Currency("IMP");
        public static readonly Currency INR = new Currency("INR");
        public static readonly Currency IQD = new Currency("IQD");
        public static readonly Currency IRR = new Currency("IRR");
        public static readonly Currency ISK = new Currency("ISK");
        public static readonly Currency JEP = new Currency("JEP");
        public static readonly Currency JMD = new Currency("JMD");
        public static readonly Currency JOD = new Currency("JOD");
        public static readonly Currency JPY = new Currency("JPY");
        public static readonly Currency KES = new Currency("KES");
        public static readonly Currency KGS = new Currency("KGS");
        public static readonly Currency KHR = new Currency("KHR");
        public static readonly Currency KMF = new Currency("KMF");
        public static readonly Currency KPW = new Currency("KPW");
        public static readonly Currency KRW = new Currency("KRW");
        public static readonly Currency KWD = new Currency("KWD");
        public static readonly Currency KYD = new Currency("KYD");
        public static readonly Currency KZT = new Currency("KZT");
        public static readonly Currency LAK = new Currency("LAK");
        public static readonly Currency LBP = new Currency("LBP");
        public static readonly Currency LKR = new Currency("LKR");
        public static readonly Currency LRD = new Currency("LRD");
        public static readonly Currency LSL = new Currency("LSL");
        public static readonly Currency LTL = new Currency("LTL");
        public static readonly Currency LVL = new Currency("LVL");
        public static readonly Currency LYD = new Currency("LYD");
        public static readonly Currency MAD = new Currency("MAD");
        public static readonly Currency MDL = new Currency("MDL");
        public static readonly Currency MGA = new Currency("MGA");
        public static readonly Currency MKD = new Currency("MKD");
        public static readonly Currency MMK = new Currency("MKK");
        public static readonly Currency MNT = new Currency("MNT");
        public static readonly Currency MOP = new Currency("MOP");
        public static readonly Currency MRO = new Currency("MRO");
        public static readonly Currency MUR = new Currency("MUR");
        public static readonly Currency MVR = new Currency("MVR");
        public static readonly Currency MWK = new Currency("MWK");
        public static readonly Currency MXN = new Currency("MXN");
        public static readonly Currency MYR = new Currency("MYR");
        public static readonly Currency MZN = new Currency("MZN");
        public static readonly Currency NAD = new Currency("NAD");
        public static readonly Currency NGN = new Currency("NGN");
        public static readonly Currency NIO = new Currency("NIO");
        public static readonly Currency NOK = new Currency("NOK");
        public static readonly Currency NPR = new Currency("NPR");
        public static readonly Currency NZD = new Currency("NZD");
        public static readonly Currency OMR = new Currency("OMR");
        public static readonly Currency PAB = new Currency("PAB");
        public static readonly Currency PEN = new Currency("PEN");
        public static readonly Currency PGK = new Currency("PGK");
        public static readonly Currency PHP = new Currency("PHP");
        public static readonly Currency PKR = new Currency("PKR");
        public static readonly Currency PLN = new Currency("PLN");
        public static readonly Currency PYG = new Currency("PYG");
        public static readonly Currency QAR = new Currency("QAR");
        public static readonly Currency RON = new Currency("RON");
        public static readonly Currency RSD = new Currency("RSD");
        public static readonly Currency RUB = new Currency("RUB");
        public static readonly Currency RWF = new Currency("RWF");
        public static readonly Currency SAR = new Currency("SAR");
        public static readonly Currency SBD = new Currency("SBD");
        public static readonly Currency SCR = new Currency("SCR");
        public static readonly Currency SDG = new Currency("SDG");
        public static readonly Currency SEK = new Currency("SEK");
        public static readonly Currency SGD = new Currency("SGD");
        public static readonly Currency SHP = new Currency("SHP");
        public static readonly Currency SLL = new Currency("SLL");
        public static readonly Currency SOS = new Currency("SOS");
        public static readonly Currency SRD = new Currency("SRD");
        public static readonly Currency STD = new Currency("STD");
        public static readonly Currency SVC = new Currency("SVC");
        public static readonly Currency SYP = new Currency("SYP");
        public static readonly Currency SZL = new Currency("SZL");
        public static readonly Currency THB = new Currency("THB");
        public static readonly Currency TJS = new Currency("TJS");
        public static readonly Currency TMT = new Currency("TMT");
        public static readonly Currency TND = new Currency("TND");
        public static readonly Currency TOP = new Currency("TOP");
        public static readonly Currency TRY = new Currency("TRY");
        public static readonly Currency TTD = new Currency("TTD");
        public static readonly Currency TWD = new Currency("TWD");
        public static readonly Currency TZS = new Currency("TZS");
        public static readonly Currency UAH = new Currency("UAH");
        public static readonly Currency UGX = new Currency("UGX");
        public static readonly Currency USD = new Currency("USD");
        public static readonly Currency UYU = new Currency("UYU");
        public static readonly Currency UZS = new Currency("UZS");
        public static readonly Currency VEF = new Currency("VEF");
        public static readonly Currency VND = new Currency("VND");
        public static readonly Currency VUV = new Currency("VUV");
        public static readonly Currency WST = new Currency("WST");
        public static readonly Currency XAF = new Currency("XAF");
        public static readonly Currency XAG = new Currency("XAG");
        public static readonly Currency XAU = new Currency("XAU");
        public static readonly Currency XCD = new Currency("XCD");
        public static readonly Currency XDR = new Currency("XDR");
        public static readonly Currency XOF = new Currency("XOF");
        public static readonly Currency XPF = new Currency("XPF");
        public static readonly Currency YER = new Currency("YER");
        public static readonly Currency ZAR = new Currency("ZAR");
        public static readonly Currency ZMK = new Currency("ZMK");
        public static readonly Currency ZMW = new Currency("ZMW");
        public static readonly Currency ZWL = new Currency("ZWL");

        public Currency(string value)
        {
            _internationalCode = value;
            NamesInEnglish.TryGetValue(value, out _nameInEnglish);
            CurrencySymbol.TryGetValue(value, out _symbol);
        }

        public override string ToString()
        {
            return _internationalCode;
        }


    }
}
