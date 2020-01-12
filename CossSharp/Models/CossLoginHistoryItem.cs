using Newtonsoft.Json;

namespace CossSharp.Models
{
    public class CossLoginHistoryItem
    {
        [JsonProperty("id")]
        public CossLoginHistoryItemId Id { get; set; }

        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("nick_name")]
        public string NickName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }

        [JsonProperty("login_at")]
        public long LoginAt { get; set; }

        [JsonProperty("os_name")]
        public string OsName { get; set; }

        [JsonProperty("browser_name")]
        public string BrowserName { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("sentEmail")]
        public bool SentEmail { get; set; }
    }
}
