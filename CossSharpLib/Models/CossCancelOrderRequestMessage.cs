using Newtonsoft.Json;

namespace CossSharpLib.Models
{
    internal class CossCancelOrderRequestMessage
    {
        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("order_symbol")]
        public string OrderSymbol { get; set; }

        [JsonProperty("timestamp")]
        public string TimeStamp { get; set; }

        [JsonProperty("recvWindow")]
        public int RecvWindow { get; set; }
    }
}
