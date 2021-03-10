using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Serialization;

namespace CurrencyDotNetCore.Model
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
        public decimal ForexBuying
        {
            get
            {
                if (string.IsNullOrEmpty(_ForexBuying))
                    return 0;
                else
                    return decimal.Parse(_ForexBuying, CultureInfo.InvariantCulture);
            }
        }
        [XmlElement("ForexBuying")]
        public string _ForexBuying { get; set; }

        [XmlIgnore]
        public decimal ForexSelling
        {
            get
            {
                if (string.IsNullOrEmpty(_ForexSelling))
                    return 0;
                else
                    return decimal.Parse(_ForexSelling, CultureInfo.InvariantCulture);
            }
        }
        [XmlElement("ForexSelling")]
        public string _ForexSelling { get; set; }

        [XmlIgnore]
        public decimal BanknoteBuying
        {
            get
            {
                if (string.IsNullOrEmpty(_BanknoteBuying))
                    return 0;
                else
                    return decimal.Parse(_BanknoteBuying, CultureInfo.InvariantCulture);
            }
        }
        [XmlElement("BanknoteBuying")]
        public string _BanknoteBuying { get; set; }

        [XmlIgnore]
        public decimal BanknoteSelling
        {
            get
            {
                if (string.IsNullOrEmpty(_BanknoteSelling))
                    return 0;
                else
                    return decimal.Parse(_BanknoteSelling, CultureInfo.InvariantCulture);
            }
        }
        [XmlElement("BanknoteSelling")]
        public string _BanknoteSelling { get; set; }

        [XmlIgnore]
        public decimal CrossRateUSD
        {
            get
            {
                if (string.IsNullOrEmpty(_CrossRateUSD))
                    return 0;
                else
                    return decimal.Parse(_CrossRateUSD, CultureInfo.InvariantCulture);
            }
        }
        [XmlElement("CrossRateUSD")]
        public string _CrossRateUSD { get; set; }

        [XmlIgnore]
        public decimal CrossRateOther
        {
            get
            {
                if (string.IsNullOrEmpty(_CrossRateOther))
                    return 0;
                else
                    return decimal.Parse(_CrossRateOther, CultureInfo.InvariantCulture);
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
