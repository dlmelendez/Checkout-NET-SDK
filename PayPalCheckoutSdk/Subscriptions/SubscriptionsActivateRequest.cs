
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using PayPalHttp;


namespace PayPalCheckoutSdk.Subscriptions
{
    /// <summary>
    /// Activates a subscription. 
    /// https://developer.paypal.com/docs/api/subscriptions/v1/#subscriptions_activate
    /// </summary>
    public class SubscriptionsActivateRequest : HttpRequest
    {
        public SubscriptionsActivateRequest(string subscriptionId) : base("/v1/billing/subscriptions/{id}/activate", HttpMethod.Get, typeof(void))
        {
            try
            {
                this.Path = this.Path.Replace("{id}", Uri.EscapeDataString(subscriptionId));
            }
            catch (IOException) { }

            this.ContentType = "application/json";
        }
        
        public SubscriptionsActivateRequest RequestBody(SubscriptionActivateRequest subscription)
        {
            this.Body = subscription;
            return this;
        }
    }
}
