using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Serialization;

namespace CurrencyDotNet.CBRT
{
    [Serializable()]
    [XmlRoot("Tarih_Date", Namespace = "", IsNullable = false)]
    [XmlType(AnonymousType = true)]
    public partial class CBRTModel
    {
        [XmlElement("Currency")]
        public List<CBRTModelCurrency> Currencies { get; set; }

        [XmlAttribute()]
        public string Tarih { get; set; }

        [XmlAttribute()]
        public string Date { get; set; }

        [XmlAttribute()]
        public string Bulten_No { get; set; }
    }

    [Serializable()]
    public partial class CBRTModelCurrency
    {
        public int Unit { get; set; }

        public string Isim { get; set; }

        public string CurrencyName { get; set; }

        [XmlIgnore]
        public double ForexBuying
        {
            get
            {
                if (string.IsNullOrEmpty(_ForexBuying))
                    return 0;
                else
                    return double.Parse(_ForexBuying, CultureInfo.InvariantCulture);
            }
        }
        [XmlElement("ForexBuying")]
        public string _ForexBuying { get; set; }

        [XmlIgnore]
        public double ForexSelling
        {
            get
            {
                if (string.IsNullOrEmpty(_ForexSelling))
                    return 0;
                else
                    return double.Parse(_ForexSelling, CultureInfo.InvariantCulture);
            }
        }
        [XmlElement("ForexSelling")]
        public string _ForexSelling { get; set; }

        [XmlIgnore]
        public double BanknoteBuying
        {
            get
            {
                if (string.IsNullOrEmpty(_BanknoteBuying))
                    return 0;
                else
                    return double.Parse(_BanknoteBuying, CultureInfo.InvariantCulture);
            }
        }
        [XmlElement("BanknoteBuying")]
        public string _BanknoteBuying { get; set; }

        [XmlIgnore]
        public double BanknoteSelling
        {
            get
            {
                if (string.IsNullOrEmpty(_BanknoteSelling))
                    return 0;
                else
                    return double.Parse(_BanknoteSelling, CultureInfo.InvariantCulture);
            }
        }
        [XmlElement("BanknoteSelling")]
        public string _BanknoteSelling { get; set; }

        [XmlIgnore]
        public double CrossRateUSD
        {
            get
            {
                if (string.IsNullOrEmpty(_CrossRateUSD))
                    return 0;
                else
                    return double.Parse(_CrossRateUSD, CultureInfo.InvariantCulture);
            }
        }
        [XmlElement("CrossRateUSD")]
        public string _CrossRateUSD { get; set; }

        [XmlIgnore]
        public double CrossRateOther
        {
            get
            {
                if (string.IsNullOrEmpty(_CrossRateOther))
                    return 0;
                else
                    return double.Parse(_CrossRateOther, CultureInfo.InvariantCulture);
            }
        }
        [XmlElement("CrossRateOther")]
        public string _CrossRateOther { get; set; }
        
        [XmlAttribute()]
        public byte CrossOrder { get; set; }
        
        [XmlAttribute()]
        public string Kod { get; set; }
        
        [XmlAttribute()]
        public string CurrencyCode { get; set; }
    }
}
