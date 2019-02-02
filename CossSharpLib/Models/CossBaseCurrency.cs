﻿using Newtonsoft.Json;

namespace CossSharpLib.Models
{
    public class CossBaseCurrency
    {
        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonProperty("minimum_total_order")]
        public decimal MinimumTotalOrder { get; set; }
    }
}
