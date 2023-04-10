using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
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
        [JsonPropertyName("create_time")]
        public string? CreateTime { get; set; }

        /// <summary>
        /// The event that triggered the webhook event notification.
        /// </summary>
        [DataMember(Name = "event_type", EmitDefaultValue = false)]
        [JsonPropertyName("event_type")]
        public string? EventType { get; set; }

        /// <summary>
        /// The event version in the webhook notification.
        /// Pattern: ^([0 - 9]+.[0-9]+)$.
        /// </summary>
        [DataMember(Name = "event_version", EmitDefaultValue = false)]
        [JsonPropertyName("event_version")]
        public string? EventVersion { get; set; }

        /// <summary>
        /// The ID of the webhook event notification.
        /// </summary>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [DataMember(Name = "links", EmitDefaultValue = false)]
        [JsonPropertyName("links")]
        public List<LinkDescription>? Links { get; set; }

        /// <summary>
        /// https://developer.paypal.com/docs/api/webhooks/v1/#definition-resource
        /// </summary>
        [DataMember(Name = "resource", EmitDefaultValue = false)]
        [JsonPropertyName("resource")]
        public object? Resource { get; set; }

        /// <summary>
        /// The name of the resource related to the webhook notification event.
        /// </summary>
        [DataMember(Name = "resource_type", EmitDefaultValue = false)]
        [JsonPropertyName("resource_type")]
        public string? ResourceType { get; set; }

        /// <summary>
        /// The resource version in the webhook notification.
        /// Pattern: ^([0 - 9]+.[0-9]+)$.
        /// </summary>
        [DataMember(Name = "resource_version", EmitDefaultValue = false)]
        [JsonPropertyName("resource_version")]
        public string? ResourceVersion { get; set; }

        /// <summary>
        /// A summary description for the event notification.
        /// </summary>
        [DataMember(Name = "summary", EmitDefaultValue = false)]
        [JsonPropertyName("summary")]
        public string? Summary { get; set; }


        public T? GetResource<T>()
        {
            return System.Text.Json.JsonSerializer.Deserialize<T>(System.Text.Json.JsonSerializer.Serialize(Resource), SystemTextJsonSerializer.JsonWebOptions);
        }
    }
}
