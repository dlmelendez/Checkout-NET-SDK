﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace PayPalCheckoutSdk.Core
{
    [DataContract]
    public class ErrorDetails
    {
        /// <summary>
        /// The field that caused the error. If this field is in the body, set this value to the field's JSON pointer value. Required for client-side errors.
        /// </summary>
        [DataMember(Name = "field", EmitDefaultValue = false)]
        [JsonPropertyName("field")]
        public string? Field { get; set; }

        /// <summary>
        /// The value of the field that caused the error.
        /// </summary>
        [DataMember(Name = "value", EmitDefaultValue = false)]
        [JsonPropertyName("value")]
        public string? Value { get; set; }

        /// <summary>
        /// The location of the field that caused the error. Value is body, path, or query.
        /// </summary>
        [DataMember(Name = "location", EmitDefaultValue = false)]
        [JsonPropertyName("location")]
        public string? Location { get; set; }

        /// <summary>
        /// The unique, fine-grained application-level error code.
        /// </summary>
        [DataMember(Name = "issue", EmitDefaultValue = false)]
        [JsonPropertyName("issue")]
        public string? Issue { get; set; }

        /// <summary>
        /// The human-readable description for an issue. The description can change over the lifetime of an API, so clients must not depend on this value.
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false)]
        [JsonPropertyName("description")]
        public string? Description { get; set; }

    }
}
