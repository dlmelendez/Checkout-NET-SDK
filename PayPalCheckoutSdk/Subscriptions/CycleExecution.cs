using System.Runtime.Serialization;
using System.Collections.Generic;
using PayPalCheckoutSdk.Core;
using System.Text.Json.Serialization;

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
        [JsonPropertyName("tenure_type")]
        public string? TenureType { get; set; }

        /// <summary>
        /// The order in which to run this cycle among other billing cycles.
        /// </summary>
        [DataMember(Name = "sequence", EmitDefaultValue = false)]
        [JsonPropertyName("sequence")]
        public int? Sequence { get; set; }

        /// <summary>
        /// The number of billing cycles that have completed.
        /// </summary>
        [DataMember(Name = "cycles_completed", EmitDefaultValue = false)]
        [JsonPropertyName("cycles_completed")]
        public int? CyclesCompleted { get; set; }

        /// <summary>
        /// For a finite billing cycle, cycles_remaining is the number of remaining cycles. 
        /// For an infinite billing cycle, cycles_remaining is set as 0.
        /// </summary>
        [DataMember(Name = "cycles_remaining", EmitDefaultValue = false)]
        [JsonPropertyName("cycles_remaining")]
        public int? CyclesRemaining { get; set; }

        /// <summary>
        /// The active pricing scheme version for the billing cycle.
        /// </summary>
        [DataMember(Name = "current_pricing_scheme_version", EmitDefaultValue = false)]
        [JsonPropertyName("current_pricing_scheme_version")]
        public int? CurrentPricingSchemeVersion { get; set; }

        /// <summary>
        /// The number of times this billing cycle gets executed. 
        /// Trial billing cycles can only be executed a finite number of times (value between 1 and 999 for total_cycles). 
        /// Regular billing cycles can be executed infinite times (value of 0 for total_cycles) or a finite number of times (value between 1 and 999 for total_cycles).
        /// </summary>
        [DataMember(Name = "total_cycles", EmitDefaultValue = false)]
        [JsonPropertyName("total_cycles")]
        public int? TotalCycles { get; set; }

    }
}
