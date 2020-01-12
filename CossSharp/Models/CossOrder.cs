using Newtonsoft.Json;
using System.Collections.Generic;

namespace CossSharp.Models
{
    public class CossOrder : List<decimal>
    {
        [JsonIgnore]
        public decimal Price
        {
            get
            {
                return this[0];
            }
        }

        [JsonIgnore]
        public decimal Quantity
        {
            get
            {
                return this[1];
            }
        }
    }
}
