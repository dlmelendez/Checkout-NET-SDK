
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
    /// https://developer.paypal.com/docs/api/webhooks/v1/#webhooks-lookup_list
    /// </summary>
    public class LookupsGetRequest : HttpRequest
    {
        public LookupsGetRequest() : base("/v1/notifications/webhooks-lookup", HttpMethod.Get, typeof(LookupList))
        {
            ContentType =  MimeTypeConstants.ApplicationJson;
        }
        
    }
}
