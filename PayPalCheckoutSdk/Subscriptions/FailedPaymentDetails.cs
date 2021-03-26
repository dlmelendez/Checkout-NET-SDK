using PayPalCheckoutSdk.Core;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PayPalCheckoutSdk.Subscriptions
{
    [DataContract]
    public class FailedPaymentDetails
    {
        /// <summary>
        /// The last payment amount.
        /// </summary>
        [DataMember(Name = "amount", EmitDefaultValue = false)]
        public Money Amount { get; set; }

        /// <summary>
        /// The date and time, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6). Seconds are required while fractional seconds are optional.<blockquote><strong>Note:</strong> The regular expression provides guidance but does not reject all invalid dates.</blockquote>
        /// </summary>
        [DataMember(Name = "time", EmitDefaultValue = false)]
        public string Time { get; set; }

        /// <summary>
        /// The reason code for the payment failure.
        /// The possible values are:
        /// PAYMENT_DENIED.PayPal declined the payment due to one or more customer issues.
        /// INTERNAL_SERVER_ERROR.An internal server error has occurred.
        /// PAYEE_ACCOUNT_RESTRICTED.The payee account is not in good standing and cannot receive payments.
        /// PAYER_ACCOUNT_RESTRICTED.The payer account is not in good standing and cannot make payments.
        /// PAYER_CANNOT_PAY.Payer cannot pay for this transaction.
        /// SENDING_LIMIT_EXCEEDED.The transaction exceeds the payer's sending limit.
        /// TRANSACTION_RECEIVING_LIMIT_EXCEEDED.The transaction exceeds the receiver's receiving limit.
        /// CURRENCY_MISMATCH.The transaction is declined due to a currency mismatch.
        /// </summary>
        [DataMember(Name = "reason_code", EmitDefaultValue = false)]
        public string ReasonCode { get; set; }

        /// <summary>
        /// The date and time, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6). Seconds are required while fractional seconds are optional.<blockquote><strong>Note:</strong> The regular expression provides guidance but does not reject all invalid dates.</blockquote>
        /// </summary>
        [DataMember(Name = "next_payment_retry_time", EmitDefaultValue = false)]
        public string NextPaymentRetryTime { get; set; }

    }
}
