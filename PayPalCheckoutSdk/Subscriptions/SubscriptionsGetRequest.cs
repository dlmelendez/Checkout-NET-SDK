
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using PayPalHttp;


namespace PayPalCheckoutSdk.Subscriptions
{
    /// <summary>
    /// Shows details for an subscription, by ID.
    /// https://developer.paypal.com/docs/api/subscriptions/v1/#subscriptions_get
    /// </summary>
    public class SubscriptionsGetRequest : HttpRequest
    {
        public SubscriptionsGetRequest(string subscriptionId) : base("/v1/billing/subscriptions/{id}", HttpMethod.Get, typeof(Subscription))
        {
            try {
                this.Path = this.Path.Replace("{id}", Uri.EscapeDataString(subscriptionId));
            } catch (IOException) {}
            
            this.ContentType =  "application/json";
        }
        
    }
}
