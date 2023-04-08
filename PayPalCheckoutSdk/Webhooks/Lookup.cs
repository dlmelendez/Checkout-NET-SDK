using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using PayPalCheckoutSdk.Core;

namespace PayPalCheckoutSdk.Webhooks
{
    /// <summary>
    /// The WebhookLookup.
    /// https://developer.paypal.com/docs/api/webhooks/v1/#definition-webhooks_lookup
    /// </summary>
    [DataContract]
    public class Lookup
    {
        /// <summary>
        /// The ID of the webhook lookup.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string? Id { get; set; }

        /// <summary>
        /// The application client ID.
        /// </summary>
        [DataMember(Name = "client_id", EmitDefaultValue = false)]
        public string? ClientId { get; set; }

        /// <summary>
        /// An array of request-related HATEOAS links.
        /// </summary>
        [DataMember(Name = "links", EmitDefaultValue = false)]
        public List<LinkDescription>? Links { get; set; }

    }
}
