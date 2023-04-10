using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PayPalCheckoutSdk.Core
{
    /// <summary>
    /// The Payment Preferences details.
    /// </summary>
    [DataContract]
    public class PaymentPreferences
    {
        /// <summary>
        /// Indicates whether to automatically bill the outstanding amount in the next billing cycle.
        /// </summary>
        [DataMember(Name = "auto_bill_outstanding", EmitDefaultValue = false)]
        [JsonPropertyName("auto_bill_outstanding")]
        public bool? AutoBillOutstanding { get; set; }

        /// <summary>
        /// The initial set-up fee for the service.
        /// </summary>
        [DataMember(Name = "setup_fee", EmitDefaultValue = false)]
        [JsonPropertyName("setup_fee")]
        public Money? SetupFee { get; set; }

        /// <summary>
        /// The action to take on the subscription if the initial payment for the setup fails.
        /// The possible values are:
        /// CONTINUE.Continues the subscription if the initial payment for the setup fails.
        /// CANCEL.Cancels the subscription if the initial payment for the setup fails.
        /// Minimum length: 1.
        /// Maximum length: 24.
        /// Pattern: ^[A-Z_]+$.
        /// </summary>
        [DataMember(Name = "setup_fee_failure_action", EmitDefaultValue = false)]
        [JsonPropertyName("setup_fee_failure_action")]
        public string? SetupFeeFailureAction { get; set; }

        /// <summary>
        /// The maximum number of payment failures before a subscription is suspended. 
        /// For example, if payment_failure_threshold is 2, the subscription automatically updates to the SUSPEND state if two consecutive payments fail.
        /// Maximum value: 999.
        /// </summary>
        [DataMember(Name = "payment_failure_threshold", EmitDefaultValue = false)]
        [JsonPropertyName("payment_failure_threshold")]
        public int? PaymentFailureThreshold { get; set; }
    }
}
