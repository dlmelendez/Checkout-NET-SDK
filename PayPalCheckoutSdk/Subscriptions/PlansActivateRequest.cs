
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using PayPalHttp;


namespace PayPalCheckoutSdk.Subscriptions
{
    /// <summary>
    /// Activates a plan. 
    /// https://developer.paypal.com/docs/api/subscriptions/v1/#plans_activate
    /// </summary>
    public class PlansActivateRequest : HttpRequest
    {
        public PlansActivateRequest(string subscriptionId) : base("/v1/billing/plans/{id}/activate", HttpMethod.Post, typeof(void))
        {
            try
            {
                Path = Path.Replace("{id}", Uri.EscapeDataString(subscriptionId));
            }
            catch (IOException) { }

            ContentType = "application/json";
        }
        
    }
}
