using Newtonsoft.Json;

namespace CossSharpLib.Models
{
    public class CossWebCoin
    {
        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("buy_limit")]
        public decimal BuyLimit { get; set; }

        [JsonProperty("sell_limit")]
        public decimal SellLimit { get; set; }

        [JsonProperty("usdt")]
        public decimal Usdt { get; set; }

        [JsonProperty("transaction_time_limit")]
        public decimal TransactionTimeLimit { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("withdrawn_fee")]
        public decimal? WithdrawnFee { get; set; }

        [JsonProperty("minimum_withdrawn_amount")]
        public decimal MinimumWithdrawnAmount { get; set; }

        [JsonProperty("minimum_deposit_amount")]
        public decimal MinimumDepositAmount { get; set; }

        [JsonProperty("minimum_order_amount")]
        public decimal MinimumOrderAmount { get; set; }

        [JsonProperty("decimal_format")]
        public string DecimalFormat { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("buy_at")]
        public decimal BuyAt { get; set; }

        [JsonProperty("sell_at")]
        public decimal SellAt { get; set; }

        [JsonProperty("min_rate")]
        public decimal MinRate { get; set; }

        [JsonProperty("max_rate")]
        public decimal MaxRate { get; set; }

        [JsonProperty("allow_withdrawn")]
        public bool AllowWithdrawn { get; set; }

        [JsonProperty("allow_deposit")]
        public bool AllowDeposit { get; set; }

        [JsonProperty("explorer_website_mainnet_link")]
        public string ExplorerWebsiteMainnetLink { get; set; }

        [JsonProperty("explorer_website_testnet_link")]
        public string ExplorerWebsiteTestnetLink { get; set; }

        [JsonProperty("deposit_block_confirmation")]
        public decimal? DepositBlockConfirmation { get; set; }

        [JsonProperty("withdraw_block_confirmation")]
        public decimal? WithdrawBlockConfirmation { get; set; }

        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }

        [JsonProperty("is_fiat")]
        public bool IsFiat { get; set; }

        [JsonProperty("allow_sell")]
        public bool AllowSell { get; set; }

        [JsonProperty("allow_buy")]
        public bool AllowBuy { get; set; }
    }
}
