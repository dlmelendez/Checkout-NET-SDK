using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using PayPalHttp;


namespace PayPalCheckoutSdk.Webhooks
{
    /// <summary>
    /// https://developer.paypal.com/docs/api/webhooks/v1/#webhooks_post
    /// </summary>
    public class WebhookCreateRequest : HttpRequest
    {

        public WebhookCreateRequest() : base("/v1/notifications/webhooks", HttpMethod.Post, typeof(Webhook))
        {
            
            ContentType =  MimeTypeConstants.ApplicationJson;
        }
        public WebhookCreateRequest PayPalPartnerAttributionId(string PayPalPartnerAttributionId) 
        {
            Headers.Add(HeaderNameConstants.PayPalPartnerAttributionId, PayPalPartnerAttributionId);
            return this;
        }
        
        /// <summary>
        /// The preferred server response upon successful completion of the request. Value is:
        /// return=minimal.The server returns a minimal response to optimize communication between the API caller and the server.A minimal response includes the id, status and HATEOAS links.
        /// return=representation.The server returns a complete resource representation, including the current state of the resource.
        /// </summary>
        /// <param name="prefer"></param>
        /// <returns></returns>
        public WebhookCreateRequest Prefer(string prefer) 
        {
            Headers.Add(HeaderNameConstants.Prefer, prefer);
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
        public WebhookCreateRequest PayPalRequestId(string payPalRequestId)
        {
            Headers.Add(HeaderNameConstants.PayPalRequestId, payPalRequestId);
            return this;
        }

        public WebhookCreateRequest RequestBody(Webhook webhook)
        {
            Body = webhook;
            return this;
        }
    }
}
