using Newtonsoft.Json;
using System.Collections.Generic;

namespace CurrencyDotNet.Fixer
{
    public class FixerModel
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("timestamp")]
        public int Timestamp { get; set; }
        [JsonProperty("base")]
        public string BaseCurrency { get; set; }
        [JsonProperty("date")]
        public string Date { get; set; }
        [JsonProperty("rates")]
        public Dictionary<string,double> Rates { get; set; }
    }
}
