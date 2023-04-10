using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PayPalCheckoutSdk.Core
{
    /// <summary>
    /// The billing cycle details.
    /// </summary>
    [DataContract]
    public class BillingCycle
    {
        /// <summary>
        /// The active pricing scheme for this billing cycle. A free trial billing cycle does not require a pricing scheme.
        /// </summary>
        [DataMember(Name = "pricing_scheme", EmitDefaultValue = false)]
        [JsonPropertyName("pricing_scheme")]
        public PricingScheme? PricingScheme { get; set; }

        /// <summary>
        /// The frequency details for this billing cycle.
        /// </summary>
        [DataMember(Name = "frequency", EmitDefaultValue = false)]
        [JsonPropertyName("frequency")]
        public Frequency? Frequency { get; set; }

        /// <summary>
        /// The tenure type of the billing cycle. In case of a plan having trial cycle, only 2 trial cycles are allowed per plan.
        /// The possible values are:
        /// REGULAR.A regular billing cycle.
        /// TRIAL.A trial billing cycle.
        /// </summary>
        [DataMember(Name = "tenure_type", EmitDefaultValue = false)]
        [JsonPropertyName("tenure_type")]
        public string? TenureType { get; set; }

        /// <summary>
        /// The order in which this cycle is to run among other billing cycles. 
        /// For example, a trial billing cycle has a sequence of 1 while a regular billing cycle has a sequence of 2, 
        /// so that trial cycle runs before the regular cycle.
        /// </summary>
        [DataMember(Name = "sequence", EmitDefaultValue = false)]
        [JsonPropertyName("sequence")]
        public int? Sequence { get; set; }

        /// <summary>
        /// The number of times this billing cycle gets executed. Trial billing cycles can only be executed a finite number of times (value between 1 and 999 for total_cycles). 
        /// Regular billing cycles can be executed infinite times (value of 0 for total_cycles) or a finite number of times (value between 1 and 999 for total_cycles).
        /// </summary>
        [DataMember(Name = "total_cycles", EmitDefaultValue = false)]
        [JsonPropertyName("total_cycles")]
        public int? TotalCycles { get; set; }
    }
}
