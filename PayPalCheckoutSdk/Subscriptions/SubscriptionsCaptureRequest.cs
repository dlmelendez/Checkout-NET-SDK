
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using PayPalHttp;


namespace PayPalCheckoutSdk.Subscriptions
{
    /// <summary>
    /// Captures a subscription. 
    /// https://developer.paypal.com/docs/api/subscriptions/v1/#subscriptions_capture
    /// </summary>
    public class SubscriptionsCaptureRequest : HttpRequest
    {
        public SubscriptionsCaptureRequest(string subscriptionId) : base("/v1/billing/subscriptions/{id}/capture", HttpMethod.Post, typeof(Transaction))
        {
            try
            {
                Path = Path.Replace("{id}", Uri.EscapeDataString(subscriptionId));
            }
            catch (IOException) { }

            ContentType = MimeTypeConstants.ApplicationJson;
        }

        /// <summary>
        /// https://developer.paypal.com/docs/business/develop/idempotency/#usage-notes
        /// The PayPal-Request-Id header value must be unique for both each request and an API call type. For example, authorize payment and capture authorized payment.
        /// PayPal recommends that you use the UUID standard for the PayPal-Request-Id header value because it meets the 38 single-byte character limit.
        /// PayPal provides the status of a request at the current time and not the status of the original request.
        /// </summary>
        /// <param name="payPalRequestId"></param>
        /// <returns></returns>
        public SubscriptionsCaptureRequest PayPalRequestId(string payPalRequestId)
        {
            Headers.Add(HeaderNameConstants.PayPalRequestId, payPalRequestId);
            return this;
        }

        public SubscriptionsCaptureRequest RequestBody(SubscriptionCaptureRequest subscription)
        {
            Body = subscription;
            return this;
        }
    }
}
