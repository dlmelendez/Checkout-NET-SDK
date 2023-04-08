using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPalCheckoutSdk.Core
{
    /// <summary>
    /// The Taxes details.
    /// </summary>
    [DataContract]
    public class Taxes
    {
        /// <summary>
        /// The tax percentage on the billing amount.
        /// Pattern: ^((-?[0-9]+)|(-?([0 - 9]+)?[.] [0-9]+))$.
        /// </summary>
        [DataMember(Name = "percentage", EmitDefaultValue = false)]
        public string? Percentage { get; set; }

        /// <summary>
        /// Indicates whether the tax was already included in the billing amount.
        /// </summary>
        [DataMember(Name = "inclusive", EmitDefaultValue = false)]
        public bool? Inclusive { get; set; }      

    }
}
