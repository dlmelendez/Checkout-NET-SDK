using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PayPalCheckoutSdk.Webhooks
{
    /// <summary>
    /// https://developer.paypal.com/docs/api/webhooks/v1/#definition-event_resend
    /// </summary>
    [DataContract]
    public class EventResend
    {
        /// <summary>
        /// An array of webhook account IDs.
        /// </summary>
        [DataMember(Name = "webhook_ids", EmitDefaultValue = false)]
        public List<string>? WebhookIds { get; set; }

    }
}
