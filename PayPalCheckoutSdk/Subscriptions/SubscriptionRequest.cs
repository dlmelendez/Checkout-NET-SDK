﻿
using System.Runtime.Serialization;
using System.Collections.Generic;
using PayPalCheckoutSdk.Core;
using System.Text.Json.Serialization;

namespace PayPalCheckoutSdk.Subscriptions
{
    /// <summary>
    /// The SubscriptionRequest.
    /// </summary>
    [DataContract]
    public class SubscriptionRequest 
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public SubscriptionRequest() { }
 
        /// <summary>
        /// The Plan ID of the order.
        /// </summary>
        [DataMember(Name = "plan_id", EmitDefaultValue = false)]
        [JsonPropertyName("plan_id")]
        public string? PlanId { get; set; }

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
        /// Customizes the payer experience during the approval process for the payment with PayPal.<blockquote><strong>Note:</strong> Partners and Marketplaces might configure <code>brand_name</code> and <code>shipping_preference</code> during partner account setup, which overrides the request values.</blockquote>
        /// </summary>
        [DataMember(Name = "application_context", EmitDefaultValue = false)]
        [JsonPropertyName("application_context")]
        public ApplicationContext? ApplicationContext { get; set; }

        /// <summary>
        /// The custom id for the subscription. Can be invoice id.
        /// </summary>
        [DataMember(Name = "custom_id", EmitDefaultValue = false)]
        [JsonPropertyName("custom_id")]
        public string? CustomId { get; set; }

        /// <summary>
        /// Inline plan details.
        /// </summary>
        [DataMember(Name = "plan", EmitDefaultValue = false)]
        [JsonPropertyName("plan")]
        public Plan? Plan { get; set; }

        

    }
}

