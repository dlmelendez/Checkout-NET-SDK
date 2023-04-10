
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PayPalCheckoutSdk.Core
{
    /// <summary>
    /// The customer and merchant payment preferences.
    /// </summary>
    [DataContract]
    public class PaymentMethod
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public PaymentMethod() {}

        /// <summary>
        /// The merchant-preferred payment sources.
        /// </summary>
        [DataMember(Name = "payee_preferred", EmitDefaultValue = false)]
        [JsonPropertyName("payee_preferred")]
        public string? PayeePreferred
        {
            get; set;
        }

        /// <summary>
        /// The customer-selected payment method on the merchant site.
        /// </summary>
        [DataMember(Name = "payer_selected", EmitDefaultValue = false)]
        [JsonPropertyName("payer_selected")]
        public string? PayerSelected
        {
            get; set;
        }
    }
}

