using System.Runtime.Serialization;
using System.Collections.Generic;
using PayPalCheckoutSdk.Core;

namespace PayPalCheckoutSdk.Subscriptions
{
    [DataContract]
    public class CycleExecution
    {
        /// <summary>
        /// The type of the billing cycle.
        /// The possible values are:
        /// REGULAR.A regular billing cycle.
        /// TRIAL.A trial billing cycle.
        /// </summary>
        [DataMember(Name = "tenure_type", EmitDefaultValue = false)]
        public string? TenureType { get; set; }

        /// <summary>
        /// The order in which to run this cycle among other billing cycles.
        /// </summary>
        [DataMember(Name = "sequence", EmitDefaultValue = false)]
        public int? Sequence { get; set; }

        /// <summary>
        /// The number of billing cycles that have completed.
        /// </summary>
        [DataMember(Name = "cycles_completed", EmitDefaultValue = false)]
        public int? CyclesCompleted { get; set; }

        /// <summary>
        /// For a finite billing cycle, cycles_remaining is the number of remaining cycles. 
        /// For an infinite billing cycle, cycles_remaining is set as 0.
        /// </summary>
        [DataMember(Name = "cycles_remaining", EmitDefaultValue = false)]
        public int? CyclesRemaining { get; set; }

        /// <summary>
        /// The active pricing scheme version for the billing cycle.
        /// </summary>
        [DataMember(Name = "current_pricing_scheme_version", EmitDefaultValue = false)]
        public int? CurrentPricingSchemeVersion { get; set; }

        /// <summary>
        /// The number of times this billing cycle gets executed. 
        /// Trial billing cycles can only be executed a finite number of times (value between 1 and 999 for total_cycles). 
        /// Regular billing cycles can be executed infinite times (value of 0 for total_cycles) or a finite number of times (value between 1 and 999 for total_cycles).
        /// </summary>
        [DataMember(Name = "total_cycles", EmitDefaultValue = false)]
        public int? TotalCycles { get; set; }

    }
}
