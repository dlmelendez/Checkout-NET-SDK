using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace PayPalCheckoutSdk.Core
{
    [DataContract]
    public class PhoneWithType
    {
        /// <summary>
        /// The phone type.
        /// Possible values: FAX,HOME,MOBILE,OTHER,PAGER.
        /// </summary>
        [DataMember(Name = "phone_type", EmitDefaultValue = false)]
        [JsonPropertyName("phone_type")]
        public string? PhoneType { get; set; }

        /// <summary>
        /// The phone type.
        /// Possible values: FAX,HOME,MOBILE,OTHER,PAGER.
        /// </summary>
        [DataMember(Name = "phone_number", EmitDefaultValue = false)]
        [JsonPropertyName("phone_number")]
        public PhoneWithTypePhone? PhoneNumber { get; set; }
    }
}
