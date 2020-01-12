using Newtonsoft.Json;

namespace CossSharp.Models
{
    public class CossAccountDetails
    {
        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("revenue_share_guid")]
        public string RevenueShareGuid { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("enable_google_2fa")]
        public bool EnableGoogle2fa { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("create_at")]
        public long CreateAt { get; set; }

        [JsonProperty("nick_name")]
        public string NickName { get; set; }

        [JsonProperty("chat_id")]
        public string ChatId { get; set; }

        [JsonProperty("chat_password")]
        public string ChatPassword { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("kyc_status")]
        public string KycStatus { get; set; }

        [JsonProperty("kyc_level")]
        public string KycLevel { get; set; }

        [JsonProperty("last_login_history")]
        public CossLoginHistoryItem LastLoginHistory { get; set; }

        //"commission_status": true,
        [JsonProperty("commission_status")]
        public bool CommissionStatus { get; set; }

        [JsonProperty("account_kyc")]
        public CossAccountKyc AccountKyc { get; set; }

        [JsonProperty("allow_order")]
        public int AllowOrder { get; set; }

        [JsonProperty("disable_withdraw")]
        public int DisableWithdraw { get; set; }

        [JsonProperty("disable_deposit")]
        public int DisableDeposit { get; set; }

        [JsonProperty("referral_id")]
        public string ReferralId { get; set; }

        [JsonProperty("chat_server")]
        public string ChatServer { get; set; }

        [JsonProperty("exchange_fee")]
        public CossExchangeFee ExchangeFee { get; set; }

        [JsonProperty("trading_fee")]
        public decimal? TradingFee { get; set; }

        [JsonProperty("enabled_api")]
        public bool EnabledApi { get; set; }

        [JsonProperty("allow_buy")]
        public bool AllowBuy { get; set; }

        [JsonProperty("allow_sell")]
        public bool AllowSell { get; set; }

        [JsonProperty("preffered_fiat")]
        public string PrefferedFiat { get; set; }

        [JsonProperty("preffered_pair")]
        public string PrefferedPair { get; set; }

        [JsonProperty("starting_page")]
        public string StartingPage { get; set; }

        [JsonProperty("account_type")]
        public string AccountType { get; set; }
    }
}
