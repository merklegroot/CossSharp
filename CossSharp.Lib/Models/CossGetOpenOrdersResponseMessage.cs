using Newtonsoft.Json;
using System.Collections.Generic;

namespace CossSharp.Lib.Models
{
    public class CossGetOpenOrdersResponseMessage
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("list")]
        public List<CossOpenOrder> List { get; set; }
    }
}
