using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using PayPalCheckoutSdk.Core;

namespace PayPalCheckoutSdk.Webhooks
{
    /// <summary>
    /// https://developer.paypal.com/docs/api/webhooks/v1/#definition-simulate_event
    /// </summary>
    [DataContract]
    public class EventSimulate
    {
        /// <summary>
        /// The ID of the webhook. If omitted, the URL is required.
        /// </summary>
        [DataMember(Name = "webhook_id", EmitDefaultValue = false)]
        public string? WebhookId { get; set; }

        /// <summary>
        /// The URL for the webhook endpoint. If omitted, the webhook ID is required.
        /// </summary>
        [DataMember(Name = "url", EmitDefaultValue = false)]
        public string? Url { get; set; }

        /// <summary>
        /// The event name. Specify one of the subscribed events. For each request, provide only one event.
        /// </summary>
        [DataMember(Name = "event_type", EmitDefaultValue = false)]
        public string? EventType { get; set; }

        /// <summary>
        /// The identifier for event type ex: 1.0/2.0 etc.
        /// </summary>
        [DataMember(Name = "resource_version", EmitDefaultValue = false)]
        public string? ResourceVersion { get; set; }


    }
}
