using System;
using System.Text.Json.Serialization;

namespace Russkyc.GumroadLicensing.NetStandard
{
    public class LicenseInfo
    {
        // Order and Transaction Information
        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;

        [JsonPropertyName("order_number")]
        public int OrderNumber { get; set; }

        [JsonPropertyName("sale_id")]
        public string SaleId { get; set; } = null!;

        [JsonPropertyName("sale_timestamp")]
        public DateTime SaleTimestamp { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime? CreatedAt { get; set; }

        // Subscription Information
        [JsonPropertyName("subscription_ended_at"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? SubscriptionEndedAt { get; set; }
        
        [JsonPropertyName("subscription_cancelled_at"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? SubscriptionCancelledAt { get; set; }
        
        [JsonPropertyName("subscription_failed_at"), JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? SubscriptionFailedAt { get; set; }
        
        // Product Information
        [JsonPropertyName("product_id")]
        public string ProductId { get; set; } = null!;

        [JsonPropertyName("product_name")]
        public string ProductName { get; set; } = null!;

        [JsonPropertyName("short_product_id")]
        public string ShortProductId { get; set; } = null!;

        [JsonPropertyName("permalink")]
        public string Permalink { get; set; } = null!;

        [JsonPropertyName("product_permalink")]
        public string ProductPermalink { get; set; } = null!;

        [JsonPropertyName("variants")]
        public string Variants { get; set; } = string.Empty;

        // License Information
        [JsonPropertyName("license_key")]
        public string LicenseKey { get; set; } = null!;

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
        
        [JsonPropertyName("uses")]
        public int Uses { get; set; }

        // Pricing and Currency
        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; } = null!;

        [JsonPropertyName("gumroad_fee")]
        public decimal GumroadFee { get; set; }

        // Buyer Information
        [JsonPropertyName("email")]
        public string Email { get; set; } = null!;

        [JsonPropertyName("purchaser_id")]
        public string PurchaserId { get; set; } = null!;

        [JsonPropertyName("ip_country")]
        public string IpCountry { get; set; } = null!;

        // Seller Information
        [JsonPropertyName("seller_id")]
        public string SellerId { get; set; } = null!;

        // Purchase Status and Flags
        [JsonPropertyName("refunded")]
        public bool Refunded { get; set; }

        [JsonPropertyName("disputed")]
        public bool Disputed { get; set; }

        [JsonPropertyName("dispute_won")]
        public bool DisputeWon { get; set; }

        [JsonPropertyName("chargebacked")]
        public bool Chargebacked { get; set; }

        [JsonPropertyName("is_gift_receiver_purchase")]
        public bool IsGiftReceiverPurchase { get; set; }

        [JsonPropertyName("test")]
        public bool Test { get; set; }

        // Marketing and Communication
        [JsonPropertyName("referrer")]
        public string Referrer { get; set; } = null!;

        [JsonPropertyName("can_contact")]
        public bool CanContact { get; set; }

        [JsonPropertyName("discover_fee_charged")]
        public bool DiscoverFeeCharged { get; set; }
    }
}