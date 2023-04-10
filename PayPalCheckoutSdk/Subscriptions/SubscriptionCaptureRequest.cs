
using System.Runtime.Serialization;
using System.Collections.Generic;
using PayPalCheckoutSdk.Core;
using System.Text.Json.Serialization;

namespace PayPalCheckoutSdk.Subscriptions
{
    /// <summary>
    /// The SubscriptionCaptureRequest.
    /// </summary>
    [DataContract]
    public class SubscriptionCaptureRequest 
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public SubscriptionCaptureRequest() { }

        /// <summary>
        /// The reason or note for the subscription charge.
        /// </summary>
        [DataMember(Name = "note", EmitDefaultValue = false)]
        [JsonPropertyName("note")]
        public string? Note { get; set; }

        /// <summary>
        /// The type of capture.
        /// The possible values are:
        /// OUTSTANDING_BALANCE.The outstanding balance that the subscriber must clear.
        /// </summary>
        [DataMember(Name = "capture_type", EmitDefaultValue = false)]
        [JsonPropertyName("capture_type")]
        public string? CaptureType { get; set; }

        /// <summary>
        /// The amount of the outstanding balance. This value cannot be greater than the current outstanding balance amount.
        /// </summary>
        [DataMember(Name = "amount", EmitDefaultValue = false)]
        [JsonPropertyName("amount")]
        public Money? Amount { get; set; }
    }
}

