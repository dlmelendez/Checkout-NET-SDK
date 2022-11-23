
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
        /// <summary>
        /// Shows details for a subscription, by ID.
        /// </summary>
        /// <param name="subscriptionId">subscription id</param>
        /// <param name="fields">List of fields that are to be returned in the response. Possible value for fields are last_failed_payment and plan.</param>
        public SubscriptionsGetRequest(string subscriptionId, string fields = null) : base("/v1/billing/subscriptions/{id}", HttpMethod.Get, typeof(Subscription))
        {
            try 
            {
                Path = Path.Replace("{id}", Uri.EscapeDataString(subscriptionId));
                if(fields != null)
                {
                    Path = Path + "?fields=" + Uri.EscapeDataString(fields);
                }

            } catch (IOException) {}
            
            ContentType =  "application/json";
        }
        
    }
}
