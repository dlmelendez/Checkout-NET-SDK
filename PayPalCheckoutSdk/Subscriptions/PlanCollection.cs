using System.Runtime.Serialization;
using System.Collections.Generic;
using PayPalCheckoutSdk.Core;

namespace PayPalCheckoutSdk.Subscriptions
{
    /// <summary>
    /// The Plan_collection.
    /// </summary>
    [DataContract]
    public class PlanCollection
    {
        /// <summary>
        /// An array of plans.
        /// </summary>
        [DataMember(Name = "plans", EmitDefaultValue = false)]
        public List<Plan> Plans { get; set; }

        /// <summary>
        /// The total number of items.
        /// Maximum value: 500000000.
        /// </summary>
        [DataMember(Name = "total_items", EmitDefaultValue = false)]
        public int? TotalItems { get; set; }

        /// <summary>
        /// The total number of pages.
        /// Maximum value: 100000000.
        /// </summary>
        [DataMember(Name = "total_pages", EmitDefaultValue = false)]
        public int? TotalPages { get; set; }

        /// <summary>
        /// An array of request-related [HATEOAS links](/docs/api/reference/api-responses/#hateoas-links). To complete payer approval, use the `approve` link with the `GET` method.
        /// </summary>
        [DataMember(Name = "links", EmitDefaultValue = false)]
        public List<LinkDescription> Links { get; set; }

    }
}
