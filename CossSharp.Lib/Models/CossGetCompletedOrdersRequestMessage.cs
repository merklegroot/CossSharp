using Newtonsoft.Json;

namespace CossSharp.Lib.Models
{
    internal class CossGetCompletedOrdersRequestMessage
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("from_id")]
        public string FromId { get; set; }

        [JsonProperty("limit")]
        public int? Limit { get; set; }

        [JsonProperty("page")]
        public int? Page { get; set; }

        [JsonProperty("timestamp")]
        public string TimeStamp { get; set; }

        [JsonProperty("recvWindow")]
        public long RecvWindow { get; set; }
    }
}
