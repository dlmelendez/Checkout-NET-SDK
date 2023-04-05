using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using PayPalCheckoutSdk.Core;

namespace PayPalCheckoutSdk.Webhooks
{
    /// <summary>
    /// https://developer.paypal.com/docs/api/webhooks/v1/#definition-event
    /// </summary>
    [DataContract]
    public class Event
    {
        /// <summary>
        /// The date and time when the webhook event notification was created, in Internet date and time format.
        /// </summary>
        [DataMember(Name = "create_time", EmitDefaultValue = false)]
        public string CreateTime { get; set; }

        /// <summary>
        /// The event that triggered the webhook event notification.
        /// </summary>
        [DataMember(Name = "event_type", EmitDefaultValue = false)]
        public string EventType { get; set; }

        /// <summary>
        /// The event version in the webhook notification.
        /// Pattern: ^([0 - 9]+.[0-9]+)$.
        /// </summary>
        [DataMember(Name = "event_version", EmitDefaultValue = false)]
        public string EventVersion { get; set; }

        /// <summary>
        /// The ID of the webhook event notification.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(Name = "links", EmitDefaultValue = false)]
        public List<LinkDescription> Links { get; set; }

        /// <summary>
        /// https://developer.paypal.com/docs/api/webhooks/v1/#definition-resource
        /// </summary>
        [DataMember(Name = "resource", EmitDefaultValue = false)]
        public object Resource { get; set; }

        /// <summary>
        /// The name of the resource related to the webhook notification event.
        /// </summary>
        [DataMember(Name = "resource_type", EmitDefaultValue = false)]
        public string ResourceType { get; set; }

        /// <summary>
        /// The resource version in the webhook notification.
        /// Pattern: ^([0 - 9]+.[0-9]+)$.
        /// </summary>
        [DataMember(Name = "resource_version", EmitDefaultValue = false)]
        public string ResourceVersion { get; set; }

        /// <summary>
        /// A summary description for the event notification.
        /// </summary>
        [DataMember(Name = "summary", EmitDefaultValue = false)]
        public string Summary { get; set; }

    }
}
