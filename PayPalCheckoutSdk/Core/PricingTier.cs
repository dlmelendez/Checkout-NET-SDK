using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPalCheckoutSdk.Core
{
    /// <summary>
    /// The Pricing Tier details.
    /// </summary>
    [DataContract]
    public class PricingTier
    {
        /// <summary>
        /// The starting quantity for the tier.
        /// Minimum length: 1.
        /// Maximum length: 32.
        /// Pattern: ^([0 - 9]+|([0 - 9]+)?[.] [0-9]+)$.
        /// </summary>
        [DataMember(Name = "starting_quantity", EmitDefaultValue = false)]
        public string? StartingQuantity { get; set; }

        /// <summary>
        /// The ending quantity for the tier. Optional for the last tier.
        /// Minimum length: 1.
        /// Maximum length: 32.
        /// Pattern: ^([0 - 9]+|([0 - 9]+)?[.] [0-9]+)$.
        /// </summary>
        [DataMember(Name = "ending_quantity", EmitDefaultValue = false)]
        public string? EndingQuantity { get; set; }

        /// <summary>
        /// The pricing model for tiered plan. The tiers parameter is required.
        /// The possible values are:
        /// VOLUME.A volume pricing model.
        /// TIERED.A tiered pricing model.
        /// </summary>
        [DataMember(Name = "amount", EmitDefaultValue = false)]
        public Money? Amount { get; set; }

    }
}
