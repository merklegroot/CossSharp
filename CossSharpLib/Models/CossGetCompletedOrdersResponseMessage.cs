using Newtonsoft.Json;
using System.Collections.Generic;

namespace CossSharpLib.Models
{
    public class CossGetCompletedOrdersResponseMessage
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("list")]
        public List<CossCompletedOrder> List { get; set; }
    }
}
