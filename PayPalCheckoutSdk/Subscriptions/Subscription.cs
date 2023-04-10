
using System.Runtime.Serialization;
using System.Collections.Generic;
using PayPalCheckoutSdk.Core;
using System.Text.Json.Serialization;

namespace PayPalCheckoutSdk.Subscriptions
{
    /// <summary>
    /// The Subscription.
    /// </summary>
    [DataContract]
    public class Subscription 
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Subscription() { }
 
        /// <summary>
        /// The ID of the order.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// The Plan ID of the order.
        /// </summary>
        [DataMember(Name = "plan_id", EmitDefaultValue = false)]
        [JsonPropertyName("plan_id")]
        public string? PlanId { get; set; }

        /// <summary>
        /// The status of the subscription.
        /// The possible values are:
        /// APPROVAL_PENDING.The subscription is created but not yet approved by the buyer.
        /// APPROVED.The buyer has approved the subscription.
        /// ACTIVE.The subscription is active.
        /// SUSPENDED.The subscription is suspended.
        /// CANCELLED.The subscription is cancelled.
        /// EXPIRED.The subscription is expired.
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        /// <summary>
        /// The reason or notes for the status of the subscription.
        /// </summary>
        [DataMember(Name = "status_change_note", EmitDefaultValue = false)]
        [JsonPropertyName("status_change_note")]
        public string? StatusChangeNote { get; set; }

        /// <summary>
        /// The date and time, in Internet date and time format. https://tools.ietf.org/html/rfc3339#section-5.6 Seconds are required while fractional seconds are optional.
        /// </summary>
        [DataMember(Name = "status_update_time", EmitDefaultValue = false)]
        [JsonPropertyName("status_update_time")]
        public string? StatusUpdateTime { get; set; }

        /// <summary>
        /// The date and time, in Internet date and time format. https://tools.ietf.org/html/rfc3339#section-5.6 Seconds are required while fractional seconds are optional.
        /// </summary>
        [DataMember(Name = "start_time", EmitDefaultValue = false)]
        [JsonPropertyName("start_time")]
        public string? StartTime { get; set; }

        /// <summary>
        /// The quantity of the product in the subscription.
        /// Minimum length: 1.
        /// Maximum length: 32.
        /// Pattern: ^([0 - 9]+|([0 - 9]+)?[.] [0-9]+)$.
        /// </summary>
        [DataMember(Name = "quantity", EmitDefaultValue = false)]
        [JsonPropertyName("quantity")]
        public string? Quantity { get; set; }

        /// <summary>
        /// The currency and amount for a financial transaction, such as a balance or payment due.
        /// </summary>
        [DataMember(Name = "shipping_amount", EmitDefaultValue = false)]
        [JsonPropertyName("shipping_amount")]
        public Money? ShippingAmount { get; set; }

        /// <summary>
        /// The subscriber response information.
        /// </summary>
        [DataMember(Name = "subscriber", EmitDefaultValue = false)]
        [JsonPropertyName("subscriber")]
        public Subscriber? Subscriber { get; set; }

        /// <summary>
        /// The tax details.
        /// </summary>
        [DataMember(Name = "billing_info", EmitDefaultValue = false)]
        [JsonPropertyName("billing_info")]
        public SubscriptionBillingInfo? BillingInfo { get; set; }

        /// <summary>
        /// The custom id for the subscription. Can be invoice id.
        /// </summary>
        [DataMember(Name = "custom_id", EmitDefaultValue = false)]
        [JsonPropertyName("custom_id")]
        public string? CustomId { get; set; }

        /// <summary>
        /// Indicates whether the subscription has overridden any plan attributes.
        /// </summary>
        [DataMember(Name = "plan_overridden", EmitDefaultValue = false)]
        [JsonPropertyName("plan_overridden")]
        public bool? PlanOverridden { get; set; }

        /// <summary>
        /// Inline plan details.
        /// </summary>
        [DataMember(Name = "plan", EmitDefaultValue = false)]
        [JsonPropertyName("plan")]
        public Plan? Plan { get; set; }

        /// <summary>
        /// The date and time, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6). Seconds are required while fractional seconds are optional.<blockquote><strong>Note:</strong> The regular expression provides guidance but does not reject all invalid dates.</blockquote>
        /// </summary>
        [DataMember(Name = "create_time", EmitDefaultValue = false)]
        [JsonPropertyName("create_time")]
        public string? CreateTime { get; set; }
  
        /// <summary>
        /// The date and time, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6). Seconds are required while fractional seconds are optional.<blockquote><strong>Note:</strong> The regular expression provides guidance but does not reject all invalid dates.</blockquote>
        /// </summary>
        [DataMember(Name = "update_time", EmitDefaultValue = false)]
        [JsonPropertyName("update_time")]
        public string? UpdateTime { get; set; }

        /// <summary>
        /// An array of request-related [HATEOAS links](/docs/api/reference/api-responses/#hateoas-links). To complete payer approval, use the `approve` link with the `GET` method.
        /// </summary>
        [DataMember(Name = "links", EmitDefaultValue = false)]
        [JsonPropertyName("links")]
        public List<LinkDescription>? Links { get; set; }

    }
}

