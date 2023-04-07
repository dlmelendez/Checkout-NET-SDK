
using System.Runtime.Serialization;
using System.Collections.Generic;
using PayPalCheckoutSdk.Core;

namespace PayPalCheckoutSdk.Subscriptions
{
    /// <summary>
    /// The SubscriptionSuspendRequest.
    /// </summary>
    [DataContract]
    public class SubscriptionSuspendRequest
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public SubscriptionSuspendRequest() { }

        /// <summary>
        /// The reason for suspenson of the subscription.
        /// </summary>
        [DataMember(Name = "reason", EmitDefaultValue = false)]
        public string? Reason { get; set; }
        
    }
}

