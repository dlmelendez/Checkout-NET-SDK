using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using PayPalCheckoutSdk.Core;

namespace PayPalCheckoutSdk.Webhooks
{
    /// <summary>
    /// The Webhook.
    /// https://developer.paypal.com/docs/api/webhooks/v1/#definition-webhook
    /// </summary>
    [DataContract]
    public class Webhook 
    {
        /// <summary>
        /// The ID of the webhook.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// The Internet accessible URL configured to listen for incoming POST notification messages containing event information.
        /// </summary>
        [DataMember(Name = "url", EmitDefaultValue = false)]
        public string Url { get; set; }

        /// <summary>
        /// An array of request-related HATEOAS links.
        /// </summary>
        [DataMember(Name = "links", EmitDefaultValue = false)]
        public List<LinkDescription> Links { get; set; }

        /// <summary>
        /// An array of events to which to subscribe your webhook. 
        /// To subscribe to all events, including events as they are added, specify the asterisk wild card. 
        /// To replace the event_types array, specify the asterisk wild card. To list all supported events, list available events.
        /// </summary>
        [DataMember(Name = "event_types", EmitDefaultValue = false)]
        public object EventTypesObject { get; set; }

        [IgnoreDataMember]
        public bool IsEventTypesWildcard
        {
            get
            {
                return EventTypesObject is not null
                    && EventTypesObject is string
                    && EventTypesObject.ToString() == EventType.Wildcard;
            }
            set
            {
                if (value)
                {
                    EventTypesObject = EventType.Wildcard;
                }
            }
        }

        [IgnoreDataMember]
        public IEnumerable<EventType> EventTypes 
        {
            get
            {
                if (EventTypesObject is IEnumerable<EventType> et)
                {
                    return et;
                }
                return Array.Empty<EventType>();
            }
            set
            {
                if (value != null)
                {
                    EventTypesObject = value;
                }
            }
        }

    }
}
