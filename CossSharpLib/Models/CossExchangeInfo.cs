using Newtonsoft.Json;
using System.Collections.Generic;

namespace CossSharpLib.Models
{
    public class CossExchangeInfo
    {
        [JsonProperty("timezone")]
        public string TimeZone { get; set; }

        [JsonProperty("server_time")]
        public long ServerTime { get; set; }

        [JsonProperty("base_currencies")]
        public List<CossBaseCurrency> BaseCurrencies { get; set; }

        [JsonProperty("coins")]
        public List<CossCoin> Coins { get; set; }

        [JsonProperty("symbols")]
        public List<CossSymbol> Symbols { get; set; }
    }
}
