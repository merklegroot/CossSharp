using Newtonsoft.Json;

namespace CossSharp.Models
{
    public class CossLoginHistoryItemId
    {
        [JsonProperty("timestamp")]
        public long TimeStamp { get; set; }

        [JsonProperty("machineIdentifier")]
        public long MachineIdentifier { get; set; }

        [JsonProperty("processIdentifier")]
        public long ProcessIdentifier { get; set; }

        [JsonProperty("counter")]
        public long Counter { get; set; }

        [JsonProperty("timeSecond")]
        public long TimeSecond { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("date")]
        public long Date { get; set; }
    }
}
