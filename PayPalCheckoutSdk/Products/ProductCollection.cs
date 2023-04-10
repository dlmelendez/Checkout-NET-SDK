using System.Runtime.Serialization;
using System.Collections.Generic;
using PayPalCheckoutSdk.Core;
using System.Text.Json.Serialization;

namespace PayPalCheckoutSdk.Products
{
    /// <summary>
    /// The Plan_collection.
    /// </summary>
    [DataContract]
    public class ProductCollection 
    {
        /// <summary>
        /// An array of products.
        /// </summary>
        [DataMember(Name = "products", EmitDefaultValue = false)]
        [JsonPropertyName("products")]
        public List<Product>? Products { get; set; }

        /// <summary>
        /// The total number of items.
        /// Maximum value: 500000000.
        /// </summary>
        [DataMember(Name = "total_items", EmitDefaultValue = false)]
        [JsonPropertyName("total_items")]
        public int? TotalItems { get; set; }

        /// <summary>
        /// The total number of pages.
        /// Maximum value: 100000000.
        /// </summary>
        [DataMember(Name = "total_pages", EmitDefaultValue = false)]
        [JsonPropertyName("total_pages")]
        public int? TotalPages { get; set; }

        /// <summary>
        /// An array of request-related [HATEOAS links](/docs/api/reference/api-responses/#hateoas-links). To complete payer approval, use the `approve` link with the `GET` method.
        /// </summary>
        [DataMember(Name = "links", EmitDefaultValue = false)]
        [JsonPropertyName("links")]
        public List<LinkDescription>? Links { get; set; }

    }
}
