using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace Model.Entities
{
    [Serializable]
    public class Response
    {
        [JsonProperty("Date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("PreviousDate")]
        public DateTimeOffset PreviousDate { get; set; }

        [JsonProperty("PreviousURL")]
        public string PreviousURL { get; set; }

        [JsonProperty("Timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("Valute")]
        public Dictionary<string,Currency> Valute { get; set; }
    }
}
