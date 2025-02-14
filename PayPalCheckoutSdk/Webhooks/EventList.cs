﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using PayPalCheckoutSdk.Core;
using System.Text.Json.Serialization;

namespace PayPalCheckoutSdk.Webhooks
{
    /// <summary>
    /// https://developer.paypal.com/docs/api/webhooks/v1/#definition-event_list
    /// </summary>
    [DataContract]
    public class EventList 
    {
        [DataMember(Name = "count", EmitDefaultValue = false)]
        [JsonPropertyName("count")]
        public int? Count { get; set; }

        /// <summary>
        /// An array of <see cref="Event"/>.An array of webhooks events.
        /// </summary>
        [DataMember(Name = "events", EmitDefaultValue = false)]
        [JsonPropertyName("events")]
        public List<Event>? Events { get; set; }

        /// <summary>
        /// An array of request-related [HATEOAS links](/docs/api/reference/api-responses/#hateoas-links). To complete payer approval, use the `approve` link with the `GET` method.
        /// </summary>
        [DataMember(Name = "links", EmitDefaultValue = false)]
        [JsonPropertyName("links")]
        public List<LinkDescription>? Links { get; set; }

    }
}
