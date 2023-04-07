using System.Runtime.Serialization;

namespace PayPalCheckoutSdk.Webhooks
{
    /// <summary>
    /// https://developer.paypal.com/docs/api/webhooks/v1/#definition-webhook_id
    /// </summary>
    [DataContract]
    public class WebhookId
    {
        [DataMember(Name = "webhook_id", EmitDefaultValue = false)]
        public string? Webhook_Id { get; set; }
    }
}
