
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using PayPalHttp;


namespace PayPalCheckoutSdk.Subscriptions
{
    /// <summary>
    /// Shows transactions for an subscription, by ID.
    /// https://developer.paypal.com/docs/api/subscriptions/v1/#subscriptions_transactions
    /// </summary>
    public class SubscriptionsGetTransactionsRequest : HttpRequest
    {
        /// <summary>
        /// Get transactions by subscription id and start/end dates
        /// </summary>
        /// <param name="subscriptionId">subscription id</param>
        /// <param name="startTime"> The date and time, in Internet date and time format. https://tools.ietf.org/html/rfc3339#section-5.6 Seconds are required while fractional seconds are optional.</param>
        /// <param name="endTime"> The date and time, in Internet date and time format. https://tools.ietf.org/html/rfc3339#section-5.6 Seconds are required while fractional seconds are optional.</param>
        public SubscriptionsGetTransactionsRequest(string subscriptionId, string startTime, string endTime) 
            : base("/v1/billing/subscriptions/{id}/transactions?start_time={start_time}&end_time={end_time}", HttpMethod.Get, typeof(TransactionList))
        {
            try {
                Path = Path.Replace("{id}", Uri.EscapeDataString(subscriptionId))
                    .Replace("{start_time}", Uri.EscapeDataString(startTime))
                    .Replace("{end_time}", Uri.EscapeDataString(endTime));
            } catch (IOException) {}
            
            ContentType =  MimeTypeConstants.ApplicationJson;
        }
        
    }
}
