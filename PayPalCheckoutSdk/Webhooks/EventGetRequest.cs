
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
    /// https://developer.paypal.com/docs/api/webhooks/v1/#webhooks-events_get
    /// Gets <see cref="Event"/> shows details for a webhooks event notification, by ID.
    /// </summary>    
    public class EventGetRequest : HttpRequest
    {
        /// <summary>
        /// Shows details for a webhooks event notification, by ID.
        /// </summary>
        /// <param name="eventId">The ID of the webhook event notification for which to show details.</param>
        public EventGetRequest(string eventId) : base("/v1/notifications/webhooks-events/{event_id}", HttpMethod.Get, typeof(Event))
        {
            try 
            {                
                Path = Path.Replace("{event_id}", Uri.EscapeUriString(eventId));
            } 
            catch (IOException) {}
            
            ContentType =  MimeTypeConstants.ApplicationJson;
        }
        
    }
}
