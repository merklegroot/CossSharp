using Newtonsoft.Json;

namespace CossSharp.Lib.Models
{
    public class CossBaseCurrency
    {
        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonProperty("minimum_total_order")]
        public decimal MinimumTotalOrder { get; set; }
    }
}
