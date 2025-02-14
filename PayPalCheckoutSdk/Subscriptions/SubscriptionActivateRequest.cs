﻿
using System.Runtime.Serialization;
using System.Collections.Generic;
using PayPalCheckoutSdk.Core;
using System.Text.Json.Serialization;

namespace PayPalCheckoutSdk.Subscriptions
{
    /// <summary>
    /// The SubscriptionActivateRequest.
    /// </summary>
    [DataContract]
    public class SubscriptionActivateRequest 
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public SubscriptionActivateRequest() { }

        /// <summary>
        /// The reason for activation of a subscription. Required to reactivate the subscription.
        /// </summary>
        [DataMember(Name = "reason", EmitDefaultValue = false)]
        [JsonPropertyName("reason")]
        public string? Reason { get; set; }
        
    }
}

