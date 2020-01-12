using Newtonsoft.Json;

namespace CossSharp.Models
{
    public class CossCreateOrderResponseMessage
    {
        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("order_side")]
        public string OrderSide { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("order_size")]
        public decimal OrderSize { get; set; }

        [JsonProperty("order_price")]
        public decimal OrderPrice { get; set; }

        [JsonProperty("total")]
        public string Total { get; set; }

        [JsonProperty("createTime")]
        public long CreateTime { get; set; }

        [JsonProperty("order_symbol")]
        public string OrderSymbol { get; set; }

        [JsonProperty("avg")]
        public decimal Avg { get; set; }

        [JsonProperty("executed")]
        public decimal Executed { get; set; }

        [JsonProperty("stop_price")]
        public decimal StopPrice { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
