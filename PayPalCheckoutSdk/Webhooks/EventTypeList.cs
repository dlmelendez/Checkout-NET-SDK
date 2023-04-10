using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace PayPalCheckoutSdk.Webhooks
{
    /// <summary>
    /// https://developer.paypal.com/docs/api/webhooks/v1/#definition-event_type_list
    /// </summary>
    [DataContract]
    public class EventTypeList 
    {
        /// <summary>
        /// An array of webhook events. <see cref="EventType"/>
        /// </summary>
        [DataMember(Name = "event_types", EmitDefaultValue = false)]
        [JsonPropertyName("event_types")]
        public List<EventType>? EventTypes { get; set; }
    }
}
