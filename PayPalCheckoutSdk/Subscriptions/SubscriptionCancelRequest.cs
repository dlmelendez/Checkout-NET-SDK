
using System.Runtime.Serialization;
using System.Collections.Generic;
using PayPalCheckoutSdk.Core;
using System.Text.Json.Serialization;

namespace PayPalCheckoutSdk.Subscriptions
{
    /// <summary>
    /// The SubscriptionCancelRequest.
    /// </summary>
    [DataContract]
    public class SubscriptionCancelRequest 
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public SubscriptionCancelRequest() { }

        /// <summary>
        /// The reason for activation of a subscription. Required to reactivate the subscription.
        /// </summary>
        [DataMember(Name = "reason", EmitDefaultValue = false)]
        [JsonPropertyName("reason")]
        public string? Reason { get; set; }
        
    }
}

