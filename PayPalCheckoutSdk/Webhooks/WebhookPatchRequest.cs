using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using PayPalHttp;
using PayPalCheckoutSdk.Core;

namespace PayPalCheckoutSdk.Webhooks
{
    /// <summary>
    /// Updates a webhook to replace webhook fields with new values. Supports only the replace operation. 
    /// Pass a json_patch object with replace operation and path, which is /url for a URL or /event_types for events. 
    /// The value is either the URL or a list of events.
    /// https://developer.paypal.com/docs/api/webhooks/v1/#webhooks_update
    /// </summary>
    public class WebhookPatchRequest<T> : HttpRequest
    {
        public WebhookPatchRequest(string webhookId) : base("/v1/notifications/webhooks/{webhook_id}", new HttpMethod("PATCH"), typeof(Webhook))
        {
            try {
                Path = Path.Replace("{webhook_id}", Uri.EscapeDataString(webhookId));
            } catch (IOException) {}
            
            ContentType =  MimeTypeConstants.ApplicationJson;
        }
        
        public WebhookPatchRequest<T> RequestBody(List<Patch<T>> PatchRequest)
        {
            Body = PatchRequest;
            return this;
        }
    }
}
