
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
    /// Gets <see cref="EventTypeList"/> for a webhook id.
    /// </summary>
    public class EventTypesGetRequest : HttpRequest
    {
        public EventTypesGetRequest(string webhookId) : base("/v1/notifications/webhooks/{webhook_id}/event-types", HttpMethod.Get, typeof(EventTypeList))
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
