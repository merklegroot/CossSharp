using Newtonsoft.Json;

namespace CossSharp.Lib.Models
{
    public class CossBalanceItem
    {
        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("available")]
        public decimal Available { get; set; }

        [JsonProperty("in_order")]
        public decimal InOrder { get; set; }

        [JsonProperty("memo")]
        public string Memo { get; set; }
    }
}
