using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PayPalCheckoutSdk.Webhooks
{
    /// <summary>
    /// https://developer.paypal.com/docs/api/webhooks/v1/#definition-webhook_list
    /// </summary>
    [DataContract]
    public class WebhookList
    {
        /// <summary>
        /// An array of <see cref="Webhook"/>.
        /// </summary>
        [DataMember(Name = "webhooks", EmitDefaultValue = false)]
        public List<Webhook> Webhooks { get; set; } 
    }
}
