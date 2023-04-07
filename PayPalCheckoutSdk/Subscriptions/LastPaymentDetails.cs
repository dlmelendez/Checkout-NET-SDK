using PayPalCheckoutSdk.Core;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PayPalCheckoutSdk.Subscriptions
{
    [DataContract]
    public class LastPaymentDetails
    {
        /// <summary>
        /// The status of the captured payment.
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public string? Status { get; set; }

        /// <summary>
        /// The last payment amount.
        /// </summary>
        [DataMember(Name = "amount", EmitDefaultValue = false)]
        public Money? Amount { get; set; }

        /// <summary>
        /// The date and time, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6). Seconds are required while fractional seconds are optional.<blockquote><strong>Note:</strong> The regular expression provides guidance but does not reject all invalid dates.</blockquote>
        /// </summary>
        [DataMember(Name = "time", EmitDefaultValue = false)]
        public string? Time { get; set; }

    }
}
