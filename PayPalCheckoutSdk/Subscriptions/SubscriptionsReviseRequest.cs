
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using PayPalHttp;


namespace PayPalCheckoutSdk.Subscriptions
{
    /// <summary>
    /// Revises a subscription. 
    /// https://developer.paypal.com/docs/api/subscriptions/v1/#subscriptions_revise
    /// </summary>
    public class SubscriptionsReviseRequest : HttpRequest
    {
        public SubscriptionsReviseRequest(string subscriptionId) : base("/v1/billing/subscriptions/{id}/revise", HttpMethod.Post, typeof(SubscriptionReviseResponse))
        {
            try
            {
                Path = Path.Replace("{id}", Uri.EscapeDataString(subscriptionId));
            }
            catch (IOException) { }

            ContentType = MimeTypeConstants.ApplicationJson;
        }
        
        public SubscriptionsReviseRequest RequestBody(SubscriptionReviseRequest subscription)
        {
            Body = subscription;
            return this;
        }
    }
}
