using Newtonsoft.Json;
using System.Collections.Generic;

namespace CossSharpLib.Models
{
    public class CossGetOpenOrdersResponseMessage
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("list")]
        public List<CossOpenOrder> List { get; set; }
    }
}
