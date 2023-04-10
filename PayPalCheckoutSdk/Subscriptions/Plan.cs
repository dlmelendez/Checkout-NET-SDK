
using System.Runtime.Serialization;
using System.Collections.Generic;
using PayPalCheckoutSdk.Core;
using System.Text.Json.Serialization;

namespace PayPalCheckoutSdk.Subscriptions
{
    /// <summary>
    /// The Plan.
    /// </summary>
    [DataContract]
    public class Plan 
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Plan() { }
 
        /// <summary>
        /// The ID of the order.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// The Product ID of the order.
        /// </summary>
        [DataMember(Name = "product_id", EmitDefaultValue = false)]
        [JsonPropertyName("product_id")]
        public string? ProductId { get; set; }

        /// <summary>
        /// The plan name.
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// The plan status.
        /// The possible values are:
        /// CREATED.The plan was created.You cannot create subscriptions for a plan in this state.
        /// INACTIVE.The plan is inactive.
        /// ACTIVE.The plan is active.You can only create subscriptions for a plan in this state.
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        /// <summary>
        /// The detailed description of the plan.
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// An array of billing cycles for trial billing and regular billing. A plan can have at most two trial cycles and only one regular cycle.
        /// </summary>
        [DataMember(Name = "billing_cycles", EmitDefaultValue = false)]
        [JsonPropertyName("billing_cycles")]
        public List<BillingCycle>? BillingCycles { get; set; }

        /// <summary>
        /// The payment preferences for a subscription.
        /// </summary>
        [DataMember(Name = "payment_preferences", EmitDefaultValue = false)]
        [JsonPropertyName("payment_preferences")]
        public PaymentPreferences? PaymentPreferences { get; set; }

        /// <summary>
        /// The tax details.
        /// </summary>
        [DataMember(Name = "taxes", EmitDefaultValue = false)]
        [JsonPropertyName("taxes")]
        public Taxes? Taxes { get; set; }

        /// <summary>
        /// Indicates whether you can subscribe to this plan by providing a quantity for the goods or service.
        /// </summary>
        [DataMember(Name = "quantity_supported", EmitDefaultValue = false)]
        [JsonPropertyName("quantity_supported")]
        public bool? QuantitySupported { get; set; }

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

