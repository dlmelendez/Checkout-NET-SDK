using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace PayPalCheckoutSdk.Core
{
    [DataContract]
    public class Error
    {
        /// <summary>
        /// The human-readable, unique name of the error.
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// The message that describes the error.
        /// </summary>
        [DataMember(Name = "message", EmitDefaultValue = false)]
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        /// <summary>
        /// The PayPal internal ID. Used for correlation purposes.
        /// </summary>
        [DataMember(Name = "debug_id", EmitDefaultValue = false)]
        [JsonPropertyName("debug_id")]
        public string? DebugId { get; set; }

        /// <summary>
        /// The information link, or URI, that shows detailed information about this error for the developer.
        /// </summary>
        [DataMember(Name = "information_link", EmitDefaultValue = false)]
        [JsonPropertyName("information_link")]
        public string? InformationLink { get; set; }

        /// <summary>
        /// An array of additional details about the error.
        /// </summary>
        [DataMember(Name = "details", EmitDefaultValue = false)]
        [JsonPropertyName("details")]
        public List<ErrorDetails>? Details { get; set; }

        /// <summary>
        /// An array of request-related [HATEOAS links](/docs/api/reference/api-responses/#hateoas-links). To complete payer approval, use the `approve` link with the `GET` method.
        /// </summary>
        [DataMember(Name = "links", EmitDefaultValue = false)]
        [JsonPropertyName("links")]
        public List<LinkDescription>? Links { get; set; }

    }
}
