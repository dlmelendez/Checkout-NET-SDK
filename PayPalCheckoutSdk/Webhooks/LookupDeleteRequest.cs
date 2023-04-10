
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
    /// https://developer.paypal.com/docs/api/webhooks/v1/#webhooks-lookup_delete
    /// </summary>
    public class LookupDeleteRequest : HttpRequest
    {
        public LookupDeleteRequest(string webhookLookupId) : base("/v1/notifications/webhooks-lookup/{webhook_lookup_id}", HttpMethod.Delete)
        {
            try 
            {                
                Path = Path.Replace("{webhook_lookup_id}", Uri.EscapeDataString(webhookLookupId));
            } 
            catch (IOException) {}
            
            ContentType =  MimeTypeConstants.ApplicationJson;
        }
        
    }
}
