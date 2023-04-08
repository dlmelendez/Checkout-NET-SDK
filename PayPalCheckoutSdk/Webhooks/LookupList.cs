using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

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
        public List<Lookup>? WebhookLookups { get; set; } 
    }
}
