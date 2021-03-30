
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using PayPalHttp;


namespace PayPalCheckoutSdk.Subscriptions
{
    /// <summary>
    /// Deactivates a plan. 
    /// https://developer.paypal.com/docs/subscriptions/testing/#deactivate-plan
    /// </summary>
    public class PlansDeactivateRequest : HttpRequest
    {
        public PlansDeactivateRequest(string subscriptionId) : base("/v1/billing/plans/{id}/deactivate", HttpMethod.Post, typeof(void))
        {
            try
            {
                this.Path = this.Path.Replace("{id}", Uri.EscapeDataString(subscriptionId));
            }
            catch (IOException) { }

            this.ContentType = "application/json";
        }
        
    }
}
