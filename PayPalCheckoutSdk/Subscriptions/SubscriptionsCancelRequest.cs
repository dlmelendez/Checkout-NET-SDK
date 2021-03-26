
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using PayPalHttp;


namespace PayPalCheckoutSdk.Subscriptions
{
    /// <summary>
    /// Cancels a subscription. 
    /// https://developer.paypal.com/docs/api/subscriptions/v1/#subscriptions_cancel
    /// </summary>
    public class SubscriptionsCancelRequest : HttpRequest
    {
        public SubscriptionsCancelRequest(string subscriptionId) : base("/v1/billing/subscriptions/{id}/cancel", HttpMethod.Get, typeof(void))
        {
            try
            {
                this.Path = this.Path.Replace("{id}", Uri.EscapeDataString(subscriptionId));
            }
            catch (IOException) { }

            this.ContentType = "application/json";
        }
        
        public SubscriptionsCancelRequest RequestBody(SubscriptionCancelRequest subscription)
        {
            this.Body = subscription;
            return this;
        }
    }
}
