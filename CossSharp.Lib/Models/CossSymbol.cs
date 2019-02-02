using Newtonsoft.Json;

namespace CossSharp.Lib.Models
{
    public class CossSymbol
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("amount_limit_decimal")]
        public int? AmountLimitDecimal { get; set; }

        [JsonProperty("price_limit_decimal")]
        public int? PriceLimitDecimal { get; set; }

        [JsonProperty("allow_trading")]
        public bool AllowTrading { get; set; }
    }
}
