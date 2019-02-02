using Newtonsoft.Json;
using System.Collections.Generic;

namespace CossSharp.Lib.Models
{
    public class CossGetCompletedOrdersResponseMessage
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("list")]
        public List<CossCompletedOrder> List { get; set; }
    }
}
