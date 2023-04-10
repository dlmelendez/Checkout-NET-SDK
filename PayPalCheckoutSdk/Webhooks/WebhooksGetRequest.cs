
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
    /// https://developer.paypal.com/docs/api/webhooks/v1/#webhooks_list
    /// </summary>
    public class WebhooksGetRequest : HttpRequest
    {
        public WebhooksGetRequest(AnchorType? anchorType = null) : base("/v1/notifications/webhooks{params}", HttpMethod.Get, typeof(WebhookList))
        {
            try 
            {                
                Path = Path.Replace("{params}", anchorType != null ? $"?anchor_type={anchorType}" : string.Empty);
            } 
            catch (IOException) {}
            
            ContentType =  MimeTypeConstants.ApplicationJson;
        }
        
    }
}
