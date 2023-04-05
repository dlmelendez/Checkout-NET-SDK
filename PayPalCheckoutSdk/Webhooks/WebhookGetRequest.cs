
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
    /// https://developer.paypal.com/docs/api/webhooks/v1/#webhooks_get
    /// </summary>
    public class WebhookGetRequest : HttpRequest
    {
        public WebhookGetRequest(string webhookId) : base("/v1/notifications/webhooks/{webhook_id}", HttpMethod.Get, typeof(Webhook))
        {
            try 
            {                
                Path = Path.Replace("{webhook_id}", Uri.EscapeUriString(webhookId));
            } 
            catch (IOException) {}
            
            ContentType =  MimeTypeConstants.ApplicationJson;
        }
        
    }
}
