using System.Runtime.Serialization;
using System.Collections.Generic;
using PayPalCheckoutSdk.Core;

namespace PayPalCheckoutSdk.Subscriptions
{
    [DataContract]
    public class SubscriptionBillingInfo
    {
        /// <summary>
        /// The total pending bill amount, to be paid by the subscriber.
        /// </summary>
        [DataMember(Name = "outstanding_balance", EmitDefaultValue = false)]
        public Money? OutstandingBalance { get; set; }

        /// <summary>
        /// The trial and regular billing executions.
        /// </summary>
        [DataMember(Name = "cycle_executions", EmitDefaultValue = false)]
        public List<CycleExecution>? CycleExecutions { get; set; }

        /// <summary>
        /// The total pending bill amount, to be paid by the subscriber.
        /// </summary>
        [DataMember(Name = "last_payment", EmitDefaultValue = false)]
        public LastPaymentDetails? LastPayment { get; set; }

        /// <summary>
        /// The date and time, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6). Seconds are required while fractional seconds are optional.<blockquote><strong>Note:</strong> The regular expression provides guidance but does not reject all invalid dates.</blockquote>
        /// </summary>
        [DataMember(Name = "next_billing_time", EmitDefaultValue = false)]
        public string? NextBillingTime { get; set; }

        /// <summary>
        /// The date and time, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6). Seconds are required while fractional seconds are optional.<blockquote><strong>Note:</strong> The regular expression provides guidance but does not reject all invalid dates.</blockquote>
        /// </summary>
        [DataMember(Name = "final_payment_time", EmitDefaultValue = false)]
        public string? FinalPaymentTime { get; set; }

        /// <summary>
        /// The number of consecutive payment failures. 
        /// Resets to 0 after a successful payment. If this reaches the payment_failure_threshold value, the subscription updates to the SUSPENDED state.
        /// </summary>
        [DataMember(Name = "failed_payments_count", EmitDefaultValue = false)]
        public int? FailedPaymentsCount { get; set; }

        /// <summary>
        /// The details for the last failed payment of the subscription.
        /// </summary>
        [DataMember(Name = "last_failed_payment", EmitDefaultValue = false)]
        public FailedPaymentDetails? LastFailedPayment { get; set; }
    }
}
