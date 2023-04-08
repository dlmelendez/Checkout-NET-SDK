using PayPalCheckoutSdk.Core;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PayPalCheckoutSdk.Subscriptions
{
    [DataContract]
    public class Transaction
    {
        /// <summary>
        /// The status of the captured payment.
        /// The possible values are:
        /// COMPLETED. The funds for this captured payment were credited to the payee's PayPal account.
        /// DECLINED. The funds could not be captured.
        /// PARTIALLY_REFUNDED. An amount less than this captured payment's amount was partially refunded to the payer.
        /// PENDING. The funds for this captured payment was not yet credited to the payee's PayPal account. For more information, see status.details.
        /// REFUNDED. An amount greater than or equal to this captured payment's amount was refunded to the payer.
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public string? Status { get; set; }

        /// <summary>
        /// The PayPal-generated transaction ID.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string? Id { get; set; }

        /// <summary>
        /// The breakdown details for the amount. Includes the gross, tax, fee, and shipping amounts.
        /// </summary>
        [DataMember(Name = "amount_with_breakdown", EmitDefaultValue = false)]
        public AmountWithBreakdown? AmountWithBreakdown { get; set; }

        /// <summary>
        /// The name of the customer.
        /// </summary>
        [DataMember(Name = "payer_name", EmitDefaultValue = false)]
        public Name? PayerName { get; set; }

        /// <summary>
        /// The PayPal-generated transaction ID.
        /// </summary>
        [DataMember(Name = "payer_email", EmitDefaultValue = false)]
        public string? PayerEmail { get; set; }

        /// <summary>
        /// The date and time, in Internet date and time format. https://tools.ietf.org/html/rfc3339#section-5.6 Seconds are required while fractional seconds are optional.
        /// </summary>
        [DataMember(Name = "time", EmitDefaultValue = false)]
        public string? Time { get; set; }

    }
}
