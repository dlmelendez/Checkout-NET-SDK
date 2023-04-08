// This class was generated on Tue, 04 Sep 2018 12:18:45 PDT by version 0.1.0-dev+904328-dirty of Braintree SDK Generator

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using PayPalHttp;


namespace PayPalCheckoutSdk.Subscriptions
{
    /// <summary>
    /// Creates an plan. Supports only plans with one purchase unit.
    /// </summary>
    public class PlansCreateRequest : HttpRequest
    {
        public PlansCreateRequest() : base("/v1/billing/plans", HttpMethod.Post, typeof(Plan))
        {
            
            ContentType =  MimeTypeConstants.ApplicationJson;
        }
        public PlansCreateRequest PayPalPartnerAttributionId(string PayPalPartnerAttributionId) 
        {
            Headers.Add(HeaderNameConstants.PayPalPartnerAttributionId, PayPalPartnerAttributionId);
            return this;
        }
        
        public PlansCreateRequest Prefer(string Prefer) 
        {
            Headers.Add(HeaderNameConstants.Prefer, Prefer);
            return this;
        }
        
        
        public PlansCreateRequest RequestBody(PlanRequest Plan)
        {
            Body = Plan;
            return this;
        }
    }
}
