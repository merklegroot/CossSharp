using Newtonsoft.Json;
using System;

namespace CossSharp.Models
{
    public class CossMarketSummaryItem
    {
        [JsonProperty("MarketName")]
        public string MarketName { get; set; }

        [JsonProperty("High")]
        public decimal High { get; set; }

        [JsonProperty("Low")]
        public decimal Low { get; set; }

        [JsonProperty("BaseVolume")]
        public decimal BaseVolume { get; set; }

        [JsonProperty("Last")]
        public string Last { get; set; }

        [JsonProperty("TimeStamp")]
        public DateTime TimeStamp { get; set; }

        [JsonProperty("Volume")]
        public decimal? Volume { get; set; }

        [JsonProperty("Ask")]
        public decimal Ask { get; set; }

        [JsonProperty("Bid")]
        public decimal Bid { get; set; }

        [JsonProperty("PrevDay")]
        public decimal PrevDay { get; set; }
    }
}
