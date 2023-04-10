using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace PayPalCheckoutSdk.Core
{
    [DataContract]
    public class PhoneWithTypePhone
    {
        /// <summary>
        /// The national number, in its canonical international E.164 numbering plan format. 
        /// The combined length of the country calling code (CC) and the national number must not be greater than 15 digits. 
        /// The national number consists of a national destination code (NDC) and subscriber number (SN).
        /// </summary>
        [DataMember(Name = "national_number", EmitDefaultValue = false)]
        [JsonPropertyName("national_number")]
        public string? NationalNumber { get; set; }
    }
}
