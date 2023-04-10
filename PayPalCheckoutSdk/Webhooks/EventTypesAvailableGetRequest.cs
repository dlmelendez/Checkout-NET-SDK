
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
    /// https://developer.paypal.com/docs/api/webhooks/v1/#webhooks-event-types_list
    /// Gets <see cref="EventTypeList"/> all avaliable event types
    /// </summary>
    public class EventTypesAvailableGetRequest : HttpRequest
    {
        public EventTypesAvailableGetRequest() : base("/v1/notifications/webhooks-event-types", HttpMethod.Get, typeof(EventTypeList))
        {
            
            ContentType =  MimeTypeConstants.ApplicationJson;
        }
        
    }
}
