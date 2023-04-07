using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PayPalCheckoutSdk.Webhooks
{
    /// <summary>
    /// https://developer.paypal.com/docs/api/webhooks/v1/#definition-resource_version
    /// </summary>
    [DataContract]
    public class ResourceVersion
    {
        /// <summary>
        /// The resource version in the webhook notification.
        /// Pattern: ^([0 - 9]+.[0-9]+)$.
        /// The ID for an event type. For example, 1.0 or 2.0.
        /// </summary>
        [DataMember(Name = "resource_version", EmitDefaultValue = false)]
        public string? Version { get; set; }
    }
}
