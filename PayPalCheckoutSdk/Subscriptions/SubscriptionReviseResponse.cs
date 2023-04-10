
using System.Runtime.Serialization;
using System.Collections.Generic;
using PayPalCheckoutSdk.Core;
using System.Text.Json.Serialization;

namespace PayPalCheckoutSdk.Subscriptions
{
    /// <summary>
    /// The SubscriptionReviseResponse.
    /// </summary>
    [DataContract]
    public class SubscriptionReviseResponse 
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public SubscriptionReviseResponse() { }
 
        /// <summary>
        /// The Plan ID of the order.
        /// </summary>
        [DataMember(Name = "plan_id", EmitDefaultValue = false)]
        [JsonPropertyName("plan_id")]
        public string? PlanId { get; set; }

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
        /// The date and time, in Internet date and time format. https://tools.ietf.org/html/rfc3339#section-5.6 Seconds are required while fractional seconds are optional.
        /// </summary>
        [DataMember(Name = "effective_time", EmitDefaultValue = false)]
        [JsonPropertyName("effective_time")]
        public string? EffectiveTime { get; set; }

        /// <summary>
        /// The currency and amount for a financial transaction, such as a balance or payment due.
        /// </summary>
        [DataMember(Name = "shipping_amount", EmitDefaultValue = false)]
        [JsonPropertyName("shipping_amount")]
        public Money? ShippingAmount { get; set; }

        /// <summary>
        /// The subscriber response information.
        /// </summary>
        [DataMember(Name = "shipping_address", EmitDefaultValue = false)]
        [JsonPropertyName("shipping_address")]
        public ShippingDetail? ShippingAddress { get; set; }

        /// <summary>
        /// Inline plan details.
        /// </summary>
        [DataMember(Name = "plan", EmitDefaultValue = false)]
        [JsonPropertyName("plan")]
        public Plan? Plan { get; set; }

        /// <summary>
        /// Indicates whether the subscription has overridden any plan attributes.
        /// </summary>
        [DataMember(Name = "plan_overridden", EmitDefaultValue = false)]
        [JsonPropertyName("plan_overridden")]
        public bool? PlanOverridden { get; set; }

        /// <summary>
        /// An array of request-related [HATEOAS links](/docs/api/reference/api-responses/#hateoas-links). To complete payer approval, use the `approve` link with the `GET` method.
        /// </summary>
        [DataMember(Name = "links", EmitDefaultValue = false)]
        [JsonPropertyName("links")]
        public List<LinkDescription>? Links { get; set; }

    }
}

