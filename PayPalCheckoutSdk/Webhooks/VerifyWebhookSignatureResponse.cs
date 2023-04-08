using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PayPalCheckoutSdk.Webhooks
{
    /// <summary>
    /// https://developer.paypal.com/docs/api/webhooks/v1/#definition-verify_webhook_signature_response
    /// </summary>
    [DataContract]
    public class VerifyWebhookSignatureResponse
    {
        public const string Success = "SUCCESS";
        public const string Failure = "FAILURE";
        /// <summary>
        /// The status of the signature verification.
        /// Possible values: SUCCESS,FAILURE.
        /// </summary>
        [DataMember(Name = "verification_status", EmitDefaultValue = false)]
        public string? VerificationStatus { get; set; }

        [IgnoreDataMember]
        public bool ValidSignature => VerificationStatus == Success;
    }
}
