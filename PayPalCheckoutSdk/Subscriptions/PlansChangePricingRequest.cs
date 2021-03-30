
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using PayPalHttp;
using PayPalCheckoutSdk.Core;

namespace PayPalCheckoutSdk.Subscriptions
{
    /// <summary>
    /// Updates pricing for a plan. For example, you can update a regular billing cycle from $5 per month to $7 per month.
    /// https://developer.paypal.com/docs/api/subscriptions/v1/#plans_update-pricing-schemes
    /// </summary>
    public class PlansChangePricingRequest : HttpRequest
    {
        public PlansChangePricingRequest(string planId) : base("/v1/billing/plans/{id}/update-pricing-schemes", HttpMethod.Post, typeof(void))
        {
            try {
                this.Path = this.Path.Replace("{id}", Uri.EscapeDataString(planId));
            } catch (IOException) {}
            
            this.ContentType =  "application/json";
        }
        
        public PlansChangePricingRequest RequestBody(List<UpdatePricingSchemeRequest> updatePricingRequest)
        {
            this.Body = updatePricingRequest;
            return this;
        }
    }
}
