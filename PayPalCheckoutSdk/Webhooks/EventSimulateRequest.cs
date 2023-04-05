using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using PayPalHttp;


namespace PayPalCheckoutSdk.Webhooks
{
    /// <summary>
    /// https://developer.paypal.com/docs/api/webhooks/v1/#simulate-event_post
    /// Simulates a webhook event. In the JSON request body, specify a sample payload.
    /// </summary>
    public class EventSimulateRequest : HttpRequest
    {

        public EventSimulateRequest() : base("/v1/notifications/simulate-event", HttpMethod.Post, typeof(Event))
        {            
            ContentType =  MimeTypeConstants.ApplicationJson;
        }

        public EventSimulateRequest PayPalPartnerAttributionId(string PayPalPartnerAttributionId) 
        {
            Headers.Add("PayPal-Partner-Attribution-Id", PayPalPartnerAttributionId);
            return this;
        }
        
        /// <summary>
        /// The preferred server response upon successful completion of the request. Value is:
        /// return=minimal.The server returns a minimal response to optimize communication between the API caller and the server.A minimal response includes the id, status and HATEOAS links.
        /// return=representation.The server returns a complete resource representation, including the current state of the resource.
        /// </summary>
        /// <param name="Prefer"></param>
        /// <returns></returns>
        public EventSimulateRequest Prefer(string Prefer) 
        {
            Headers.Add("Prefer", Prefer);
            return this;
        }

        /// <summary>
        /// https://developer.paypal.com/docs/business/develop/idempotency/#usage-notes
        /// The PayPal-Request-Id header value must be unique for both each request and an API call type. For example, authorize payment and capture authorized payment.
        /// PayPal recommends that you use the UUID standard for the PayPal-Request-Id header value because it meets the 38 single-byte character limit.
        /// PayPal provides the status of a request at the current time and not the status of the original request.
        /// </summary>
        /// <param name="payPalRequestId"></param>
        /// <returns></returns>
        public EventSimulateRequest PayPalRequestId(string payPalRequestId)
        {
            Headers.Add("PayPal-Request-Id", payPalRequestId);
            return this;
        }

        public EventSimulateRequest RequestBody(Webhook body)
        {
            Body = body;
            return this;
        }
    }
}
