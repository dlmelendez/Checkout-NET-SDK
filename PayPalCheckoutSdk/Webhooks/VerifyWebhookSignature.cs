using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

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
        [JsonPropertyName("auth_algo")]
        public string? AuthAlgo { get; set; }

        /// <summary>
        /// The X.509 public key certificate. 
        /// Download the certificate from this URL and use it to verify the signature. 
        /// Extract this value from the PAYPAL-CERT-URL response header, which is received with the webhook notification.
        /// </summary>
        [DataMember(Name = "cert_url", EmitDefaultValue = false)]
        [JsonPropertyName("cert_url")]
        public string? CertUrl { get; set; }

        /// <summary>
        /// The ID of the HTTP transmission. Contained in the PAYPAL-TRANSMISSION-ID header of the notification message.
        /// </summary>
        [DataMember(Name = "transmission_id", EmitDefaultValue = false)]
        [JsonPropertyName("transmission_id")]
        public string? TransmissionId { get; set; }

        /// <summary>
        /// The PayPal-generated asymmetric signature. Appears in the PAYPAL-TRANSMISSION-SIG header of the notification message.
        /// </summary>
        [DataMember(Name = "transmission_sig", EmitDefaultValue = false)]
        [JsonPropertyName("transmission_sig")]
        public string? TransmissionSig { get; set; }

        /// <summary>
        /// The date and time of the HTTP transmission, in Internet date and time format. Appears in the PAYPAL-TRANSMISSION-TIME header of the notification message.
        /// </summary>
        [DataMember(Name = "transmission_time", EmitDefaultValue = false)]
        [JsonPropertyName("transmission_time")]
        public string? TransmissionTime { get; set; }

        /// <summary>
        /// A webhook event notification.
        /// </summary>
        [Obsolete("Please use the WebhooEventRequestBody property instead with VerifyWebhookEvent.ValidateReceivedEventAsync")]
        [DataMember(Name = "webhook_event", EmitDefaultValue = false)]
        [JsonPropertyName("webhook_event")]
        public Event? WebhookEvent { get; set; }

        /// <summary>
        /// Add the entire request body from the webhook post as a string
        /// e.g. StreamReader.ReadToEnd() from the request body stream
        /// </summary>
        [JsonIgnore]
        public string? WebhookEventRequestBody { get; set; }

        /// <summary>
        /// The ID of the webhook as configured in your Developer Portal account.
        /// </summary>
        [DataMember(Name = "webhook_id", EmitDefaultValue = false)]
        [JsonPropertyName("webhook_id")]
        public string? WebhookId { get; set; }

    }
}
