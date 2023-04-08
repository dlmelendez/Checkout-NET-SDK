using PayPalCheckoutSdk.Core;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PayPalCheckoutSdk.Subscriptions
{
    [DataContract]
    public class UpdatePricingSchemeRequest
    {
        /// <summary>
        /// The billing cycle sequence.
        /// </summary>
        [DataMember(Name = "billing_cycle_sequence", EmitDefaultValue = false)]
        public int? BillingCycleSequence { get; set; }

        /// <summary>
        /// The pricing scheme details.
        /// </summary>
        [DataMember(Name = "pricing_scheme", EmitDefaultValue = false)]
        public PricingScheme? PricingScheme { get; set; }

    }
}
