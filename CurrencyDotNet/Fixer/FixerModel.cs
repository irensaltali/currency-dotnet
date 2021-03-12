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
        public Dictionary<string,decimal> Rates { get; set; }
        [JsonProperty("error")]
        public Error Error { get; set; }
    }

    public class Error
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("info")]
        public string Info { get; set; }
    }
}
