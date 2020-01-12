using Newtonsoft.Json;
using System.Collections.Generic;

namespace CossSharp.Models
{
    public class CossGetOpenOrdersResponseMessage
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("list")]
        public List<CossOpenOrder> List { get; set; }
    }
}
