using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace PayPalCheckoutSdk.Webhooks
{
    /// <summary>
    /// https://developer.paypal.com/docs/api/webhooks/v1/#definition-WebhookLookupList
    /// </summary>
    [DataContract]
    public class LookupList 
    {
        /// <summary>
        /// An array of <see cref="Lookup"/>.
        /// </summary>
        [DataMember(Name = "webhooks_lookups", EmitDefaultValue = false)]
        [JsonPropertyName("webhooks_lookups")]
        public List<Lookup>? WebhookLookups { get; set; } 
    }
}
