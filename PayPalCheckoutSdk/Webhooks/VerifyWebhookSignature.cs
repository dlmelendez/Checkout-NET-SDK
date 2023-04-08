using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PayPalCheckoutSdk.Webhooks
{
    /// <summary>
    /// https://developer.paypal.com/docs/api/webhooks/v1/#definition-verify_webhook_signature
    /// </summary>
    [DataContract]
    public class VerifyWebhookSignature
    {
        /// <summary>
        /// The algorithm that PayPal uses to generate the signature and that you can use to verify the signature. 
        /// Extract this value from the PAYPAL-AUTH-ALGO response header, which is received with the webhook notification.
        /// </summary>
        [DataMember(Name = "auth_algo", EmitDefaultValue = false)]
        public string? AuthAlgo { get; set; }

        /// <summary>
        /// The X.509 public key certificate. 
        /// Download the certificate from this URL and use it to verify the signature. 
        /// Extract this value from the PAYPAL-CERT-URL response header, which is received with the webhook notification.
        /// </summary>
        [DataMember(Name = "cert_url", EmitDefaultValue = false)]
        public string? CertUrl { get; set; }

        /// <summary>
        /// The ID of the HTTP transmission. Contained in the PAYPAL-TRANSMISSION-ID header of the notification message.
        /// </summary>
        [DataMember(Name = "transmission_id", EmitDefaultValue = false)]
        public string? TransmissionId { get; set; }

        /// <summary>
        /// The PayPal-generated asymmetric signature. Appears in the PAYPAL-TRANSMISSION-SIG header of the notification message.
        /// </summary>
        [DataMember(Name = "transmission_sig", EmitDefaultValue = false)]
        public string? TransmissionSig { get; set; }

        /// <summary>
        /// The date and time of the HTTP transmission, in Internet date and time format. Appears in the PAYPAL-TRANSMISSION-TIME header of the notification message.
        /// </summary>
        [DataMember(Name = "transmission_time", EmitDefaultValue = false)]
        public string? TransmissionTime { get; set; }

        /// <summary>
        /// A webhook event notification.
        /// </summary>
        [DataMember(Name = "webhook_event", EmitDefaultValue = false)]
        public Event? WebhookEvent { get; set; }

        /// <summary>
        /// The ID of the webhook as configured in your Developer Portal account.
        /// </summary>
        [DataMember(Name = "webhook_id", EmitDefaultValue = false)]
        public string? WebhookId { get; set; }

    }
}
