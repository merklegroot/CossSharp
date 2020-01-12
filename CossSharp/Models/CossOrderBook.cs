using Newtonsoft.Json;
using System.Collections.Generic;

namespace CossSharp.Models
{
    public class CossOrderBook
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("asks")]
        public List<CossOrder> Asks { get; set; }

        [JsonProperty("bids")]
        public List<CossOrder> Bids { get; set; }

        [JsonProperty("limit")]
        public int Limit { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }        
    }
}
