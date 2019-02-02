using Newtonsoft.Json;

namespace CossSharp.Lib.Models
{
    public class CossCancelOrderResponseMessage
    {
        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("order_symbol")]
        public string OrderSymbol { get; set; }
    }
}
