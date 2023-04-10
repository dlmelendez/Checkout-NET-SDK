
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using PayPalHttp;
using System.Text;

namespace PayPalCheckoutSdk.Webhooks
{
    /// <summary>
    /// https://developer.paypal.com/docs/api/webhooks/v1/#webhooks_delete
    /// </summary>
    public class WebhookDeleteRequest : HttpRequest
    {
        public WebhookDeleteRequest(string webhookId) : base("/v1/notifications/webhooks/{webhook_id}", HttpMethod.Delete)
        {
            try 
            {                
                Path = Path.Replace("{webhook_id}", Uri.EscapeDataString(webhookId));
            } 
            catch (IOException) {}
            
            ContentType =  MimeTypeConstants.ApplicationJson;
        }
        
    }
}
