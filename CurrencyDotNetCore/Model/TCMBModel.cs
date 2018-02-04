using System;
using System.Collections.Generic;

namespace CurrencyDotNetCore.Model
{
    [SerializableAttribute()]
    [System.Xml.Serialization.XmlRoot("Tarih_Date", Namespace = "", IsNullable = false)]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class TCMBModel
    {
        [System.Xml.Serialization.XmlElement("Currency")]
        public List<TCMBModelCurrency> Currencies { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Tarih { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Date { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Bulten_No { get; set; }
    }

    [SerializableAttribute()]
    public partial class TCMBModelCurrency
    {
        public byte Unit { get; set; }

        public string Isim { get; set; }

        public string CurrencyName { get; set; }

        public string ForexBuying { get; set; }

        public string ForexSelling { get; set; }

        public string BanknoteBuying { get; set; }

        public string BanknoteSelling { get; set; }

        public string CrossRateUSD { get; set; }

        public string CrossRateOther { get; set; }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte CrossOrder { get; set; }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Kod { get; set; }
        
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CurrencyCode { get; set; }
    }
}
