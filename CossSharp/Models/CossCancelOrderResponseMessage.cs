﻿using Newtonsoft.Json;

namespace CossSharp.Models
{
    public class CossCancelOrderResponseMessage
    {
        [JsonProperty("order_id")]
        public string OrderId { get; set; }

        [JsonProperty("order_symbol")]
        public string OrderSymbol { get; set; }
    }
}
