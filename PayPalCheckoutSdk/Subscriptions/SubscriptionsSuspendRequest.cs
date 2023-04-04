
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using PayPalHttp;


namespace PayPalCheckoutSdk.Subscriptions
{
    /// <summary>
    /// Suspends a subscription. 
    /// https://developer.paypal.com/docs/api/subscriptions/v1/#subscriptions_suspend
    /// </summary>
    public class SubscriptionsSuspendRequest : HttpRequest
    {
        public SubscriptionsSuspendRequest(string subscriptionId) : base("/v1/billing/subscriptions/{id}/suspend", HttpMethod.Post, typeof(void))
        {
            try
            {
                Path = Path.Replace("{id}", Uri.EscapeDataString(subscriptionId));
            }
            catch (IOException) { }

            ContentType = MimeTypeConstants.ApplicationJson;
        }
        
        public SubscriptionsSuspendRequest RequestBody(SubscriptionSuspendRequest subscription)
        {
            Body = subscription;
            return this;
        }
    }
}
