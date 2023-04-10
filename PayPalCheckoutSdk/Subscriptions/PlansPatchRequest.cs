
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
    /// Updates a plan with the CREATED or ACTIVE status. For an INACTIVE plan, you can make only status updates.
    /// https://developer.paypal.com/docs/api/subscriptions/v1/#plans_patch
    /// </summary>
    public class PlansPatchRequest<T> : HttpRequest
    {
        public PlansPatchRequest(string planId) : base("/v1/billing/plans/{id}?", new HttpMethod("PATCH"), typeof(void))
        {
            try {
                Path = Path.Replace("{id}", Uri.EscapeDataString(planId));
            } catch (IOException) {}
            
            ContentType =  MimeTypeConstants.ApplicationJson;
        }
        
        public PlansPatchRequest<T> RequestBody(List<Patch<T>> PatchRequest)
        {
            Body = PatchRequest;
            return this;
        }
    }
}
