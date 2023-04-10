using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using PayPalHttp;

namespace PayPalCheckoutSdk.Webhooks
{
    public class VerifyWebhookSignatureRequest : HttpRequest
    {

        public VerifyWebhookSignatureRequest() : base("/v1/notifications/verify-webhook-signature", HttpMethod.Post, typeof(VerifyWebhookSignatureResponse))
        {

            ContentType = MimeTypeConstants.ApplicationJson;
        }
        public VerifyWebhookSignatureRequest PayPalPartnerAttributionId(string PayPalPartnerAttributionId)
        {
            Headers.Add(HeaderNameConstants.PayPalPartnerAttributionId, PayPalPartnerAttributionId);
            return this;
        }

        /// <summary>
        /// The preferred server response upon successful completion of the request. Value is:
        /// return=minimal.The server returns a minimal response to optimize communication between the API caller and the server.A minimal response includes the id, status and HATEOAS links.
        /// return=representation.The server returns a complete resource representation, including the current state of the resource.
        /// </summary>
        /// <param name="Prefer"></param>
        /// <returns></returns>
        public VerifyWebhookSignatureRequest Prefer(string Prefer)
        {
            Headers.Add(HeaderNameConstants.Prefer, Prefer);
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
        public VerifyWebhookSignatureRequest PayPalRequestId(string payPalRequestId)
        {
            Headers.Add(HeaderNameConstants.PayPalRequestId, payPalRequestId);
            return this;
        }

        public VerifyWebhookSignatureRequest RequestBody(VerifyWebhookSignature body)
        {
            Body = body;
            return this;
        }
    }
}
