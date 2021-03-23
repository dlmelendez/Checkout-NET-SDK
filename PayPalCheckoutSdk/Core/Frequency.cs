using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPalCheckoutSdk.Core
{
    /// <summary>
    /// The Pricing Tier details.
    /// </summary>
    [DataContract]
    public class Frequency
    {
        /// <summary>
        /// The interval at which the subscription is charged or billed.
        /// The possible values are:
        /// DAY.A daily billing cycle.
        /// WEEK.A weekly billing cycle.
        /// MONTH.A monthly billing cycle.
        /// YEAR.A yearly billing cycle.
        /// Minimum length: 1.
        /// Maximum length: 24.
        /// Pattern: ^[A-Z_]+$.
        /// </summary>
        [DataMember(Name = "interval_unit", EmitDefaultValue = false)]
        public string IntervalUnit { get; set; }

        /// <summary>
        /// The number of intervals after which a subscriber is billed. 
        /// For example, if the interval_unit is DAY with an interval_count of 2, the subscription is billed once every two days. 
        /// The following table lists the maximum allowed values for the interval_count for each interval_unit:
        /// DAY	365
        /// WEEK	52
        /// MONTH	12
        /// YEAR	1
        /// Minimum value: 1.
        /// Maximum value: 365.
        /// </summary>
        [DataMember(Name = "interval_count", EmitDefaultValue = false)]
        public int? IntervalCount { get; set; }

    }
}
