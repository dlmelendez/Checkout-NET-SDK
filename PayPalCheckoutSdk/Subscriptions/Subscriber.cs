using System.Runtime.Serialization;
using System.Collections.Generic;
using PayPalCheckoutSdk.Core;

namespace PayPalCheckoutSdk.Subscriptions
{
    [DataContract]
    public class Subscriber
    {
        /// <summary>
        /// The name of the payer. Supports only the given_name and surname properties.
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public Name Name { get; set; }

        /// <summary>
        /// The email address of the payer.
        /// </summary>
        [DataMember(Name = "email_address", EmitDefaultValue = false)]
        public string EmailAddress { get; set; }

        /// <summary>
        /// The PayPal-assigned ID for the payer.
        /// </summary>
        [DataMember(Name = "payer_id", EmitDefaultValue = false)]
        public string PayerId { get; set; }

        /// <summary>
        /// The phone number of the customer. 
        /// Available only when you enable the Contact Telephone Number option in the Profile & Settings for the merchant's PayPal account. 
        /// The phone.phone_number supports only national_number.
        /// </summary>
        [DataMember(Name = "phone", EmitDefaultValue = false)]
        public PhoneWithType Phone { get; set; }

        /// <summary>
        /// The shipping details.
        /// </summary>
        [DataMember(Name = "shipping_address", EmitDefaultValue = false)]
        public ShippingDetail ShippingAddress { get; set; }

        /// <summary>
        /// The payment source used to fund the payment.
        /// </summary>
        [DataMember(Name = "payment_source", EmitDefaultValue = false)]
        public PaymentSource PaymentSource { get; set; }
    }
}
