using Newtonsoft.Json;

namespace CossSharp.Models
{
    public class CossExchangeFee
    {
        [JsonProperty("fee_type")]
        public string FeeType { get; set; }

        [JsonProperty("fee_name")]
        public string FeeName { get; set; }

        [JsonProperty("standard_fee")]
        public decimal? StandardFee { get; set; }

        [JsonProperty("discount_fee")]
        public decimal? DiscountFee { get; set; }

        [JsonProperty("maker_fee")]
        public decimal? MakerFee { get; set; }

        [JsonProperty("taker_fee")]
        public decimal? TakerFee { get; set; }

        [JsonProperty("maker_sale_off_fee")]
        public decimal? MakerSaleOffFee { get; set; }

        [JsonProperty("taker_sale_off_fee")]
        public decimal? TakerSaleOffFee { get; set; }

        [JsonProperty("volume_from")]
        public decimal? VolumeFrom { get; set; }

        [JsonProperty("volume_to")]
        public decimal? VolumeTo { get; set; }
    }
}
