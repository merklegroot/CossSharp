using Newtonsoft.Json;

namespace CossSharpLib.Models
{
    public class CossCoin
    {
        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("minimum_order_amount")]
        public decimal MinimumOrderAmount { get; set; }
    }
}
