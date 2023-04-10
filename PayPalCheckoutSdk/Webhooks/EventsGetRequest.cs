
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using PayPalHttp;
using System.Text;

namespace PayPalCheckoutSdk.Webhooks
{
    /// <summary>
    /// https://developer.paypal.com/docs/api/webhooks/v1/#webhooks-events_list
    /// Gets <see cref="EventList"/> 
    /// </summary>
    public class EventsGetRequest : HttpRequest
    {
        /// <summary>
        /// Lists webhooks event notifications. Use query parameters to filter the response.
        /// </summary>
        /// <param name="endTime">Filters the webhook event notifications in the response to those created on or after the start_time and on or before this date and time. Both values are in Internet date and time format format. Example: end_time=2013-03-06T11:00:00Z.</param>
        /// <param name="eventType">Filters the response to a single event.</param>
        /// <param name="pageSize">The number of webhook event notifications to return in the response.</param>
        /// <param name="startTime">Filters the webhook event notifications in the response to those created on or after this date and time and on or before the end_time value. Both values are in Internet date and time format format. Example: start_time=2013-03-06T11:00:00Z.</param>
        /// <param name="transactionId">Filters the response to a single transaction, by ID.</param>
        public EventsGetRequest(string? endTime = null,
            string? eventType = null,
            int? pageSize = null,
            string? startTime = null,
            string? transactionId = null) : base("/v1/notifications/webhooks-events{params}", HttpMethod.Get, typeof(EventList))
        {
            try
            {
                string end_timeP = endTime != null ? $"&end_time={Uri.EscapeDataString(endTime)}" : string.Empty;
                string event_typeP = eventType != null ? $"&event_type={Uri.EscapeDataString(eventType)}" : string.Empty;
                string page_sizeP = pageSize != null ? $"&page_size={Uri.EscapeDataString(pageSize.Value.ToString())}" : string.Empty;
                string start_timeP = startTime != null ? $"&start_time={Uri.EscapeDataString(startTime)}" : string.Empty;
                string transaction_idP = transactionId != null ? $"&transaction_id={Uri.EscapeDataString(transactionId)}" : string.Empty;

                string param = $"?{end_timeP}{event_typeP}{page_sizeP}{start_timeP}{transaction_idP}".Replace("?&", "?");
                Path = Path.Replace("{params}", param.Length < 2 ? string.Empty : param);
            }
            catch (IOException) { }


            ContentType =  MimeTypeConstants.ApplicationJson;
        }
        
    }
}
