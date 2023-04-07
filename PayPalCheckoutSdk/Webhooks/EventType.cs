using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PayPalCheckoutSdk.Webhooks
{
    /// <summary>
    /// https://developer.paypal.com/docs/api/webhooks/v1/#definition-event_type
    /// </summary>
    [DataContract]
    public class EventType
    {
        public const string Wildcard = "*";
        /// <summary>
        /// The unique event name.
        /// Note: To subscribe to all events, including events as they are added, specify an * as the value to represent a wildcard.
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string? Name { get; set; }

        /// <summary>
        /// A human-readable description of the event.
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string? Description { get; set; }

        /// <summary>
        /// Identifier for the event type example: 1.0/2.0 etc.
        /// </summary>
        [DataMember(Name = "resource_versions", EmitDefaultValue = false)]
        public List<ResourceVersion>? ResourceVersions { get; set; } 

        /// <summary>
        /// The status of a webhook event.
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        public string? Status { get; set; }
    }
}
