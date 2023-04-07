
using System.Runtime.Serialization;
using System.Collections.Generic;
using PayPalCheckoutSdk.Core;

namespace PayPalCheckoutSdk.Subscriptions
{
    /// <summary>
    /// The SubscriptionSaveRequest.
    /// </summary>
    [DataContract]
    public class SubscriptionSaveRequest
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public SubscriptionSaveRequest() { }

        /// <summary>
        /// The identifier of session for which subscription needs to be saved.
        /// </summary>
        [DataMember(Name = "token_id", EmitDefaultValue = false)]
        public string? TokenId { get; set; }
        
    }
}

