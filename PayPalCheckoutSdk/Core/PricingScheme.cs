using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPalCheckoutSdk.Core
{
    /// <summary>
    /// The Pricing Scheme details.
    /// </summary>
    [DataContract]
    public class PricingScheme
    {
        /// <summary>
        /// The version of the pricing scheme.
        /// </summary>
        [DataMember(Name = "version", EmitDefaultValue = false)]
        public int? Version { get; set; }

        /// <summary>
        /// The fixed amount to charge for the subscription. 
        /// The changes to fixed amount are applicable to both existing and future subscriptions. 
        /// For existing subscriptions, payments within 10 days of price change are not affected.
        /// </summary>
        [DataMember(Name = "fixed_price", EmitDefaultValue = false)]
        public Money? FixedPrice { get; set; }

        /// <summary>
        /// The pricing model for tiered plan. The tiers parameter is required.
        /// The possible values are:
        /// VOLUME.A volume pricing model.
        /// TIERED.A tiered pricing model.
        /// </summary>
        [DataMember(Name = "pricing_model", EmitDefaultValue = false)]
        public string? PricingModel { get; set; }

        /// <summary>
        /// An array of pricing tiers which are used for billing volume/tiered plans. pricing_model field has to be specified.
        /// </summary>
        [DataMember(Name = "tiers", EmitDefaultValue = false)]
        public List<PricingTier>? Tiers { get; set; }

        /// <summary>
        /// The date and time, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6). Seconds are required while fractional seconds are optional.<blockquote><strong>Note:</strong> The regular expression provides guidance but does not reject all invalid dates.</blockquote>
        /// </summary>
        [DataMember(Name = "create_time", EmitDefaultValue = false)]
        public string? CreateTime { get; set; }

        /// <summary>
        /// The date and time, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6). Seconds are required while fractional seconds are optional.<blockquote><strong>Note:</strong> The regular expression provides guidance but does not reject all invalid dates.</blockquote>
        /// </summary>
        [DataMember(Name = "update_time", EmitDefaultValue = false)]
        public string? UpdateTime { get; set; }
    }
}
