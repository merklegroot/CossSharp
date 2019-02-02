using Newtonsoft.Json;
using System.Collections.Generic;

namespace CossSharp.Lib.Models
{
    public class CossGetMarketSummariesResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("result")]
        public List<CossMarketSummaryItem> Result { get; set; }
    }
}
