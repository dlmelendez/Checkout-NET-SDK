
using System.Runtime.Serialization;
using System.Collections.Generic;
using PayPalCheckoutSdk.Core;

namespace PayPalCheckoutSdk.Subscriptions
{
    /// <summary>
    /// The Plan.
    /// </summary>
    [DataContract]
    public class PlanRequest
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public PlanRequest() { }
 
        /// <summary>
        /// The Product ID of the order.
        /// </summary>
        [DataMember(Name = "product_id", EmitDefaultValue = false)]
        public string? ProductId { get; set; }

        /// <summary>
        /// The plan name.
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string? Name { get; set; }

        /// <summary>
        /// The plan status.
        /// The possible values are:
        /// CREATED.The plan was created.You cannot create subscriptions for a plan in this state.
        /// INACTIVE.The plan is inactive.
        /// ACTIVE.The plan is active.You can only create subscriptions for a plan in this state.
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public string? Status { get; set; }

        /// <summary>
        /// The detailed description of the plan.
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string? Description { get; set; }

        /// <summary>
        /// An array of billing cycles for trial billing and regular billing. A plan can have at most two trial cycles and only one regular cycle.
        /// </summary>
        [DataMember(Name = "billing_cycles", EmitDefaultValue = false)]
        public List<BillingCycle>? BillingCycles { get; set; }

        /// <summary>
        /// The payment preferences for a subscription.
        /// </summary>
        [DataMember(Name = "payment_preferences", EmitDefaultValue = false)]
        public PaymentPreferences? PaymentPreferences { get; set; }

        /// <summary>
        /// The tax details.
        /// </summary>
        [DataMember(Name = "taxes", EmitDefaultValue = false)]
        public Taxes? Taxes { get; set; }

        /// <summary>
        /// Indicates whether you can subscribe to this plan by providing a quantity for the goods or service.
        /// </summary>
        [DataMember(Name = "quantity_supported", EmitDefaultValue = false)]
        public bool? QuantitySupported { get; set; }
        
    }
}

