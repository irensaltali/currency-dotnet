using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CurrencyDotNet.Model
{
    [XmlRoot(ElementName = "Sender")]
    public partial class Sender
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
    }

    //[Serializable()]
    //public partial class Cube
    //{
    //    public CubeWithTime CubeWithTime { get; set; } 
    //}

    [Serializable()]
    public partial class CubeWithTime
    {
        [XmlElement("Cube")]
        public List<CubeWithCurrency> CubeWithCurrencies { get; set; }

        [XmlAttribute(AttributeName = "time")]
        public string Time { get; set; }
    }

    [Serializable()]
    public partial class CubeWithCurrency
    {
        [XmlAttribute("currency")]
        public string Currency { get; set; }
        [XmlAttribute("rate")]
        public decimal Rate { get; set; }
    }

    [Serializable()]
    [XmlRoot(ElementName = "Envelope")]
    public class ECBModel
    {
        [XmlElement(ElementName = "subject")]
        public string Subject { get; set; }
        [XmlElement(ElementName = "Sender")]
        public Sender Sender { get; set; }
        [XmlElement(ElementName = "Cube")]
        public CubeWithTime Cube { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
    }
}
