using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PayPalCheckoutSdk
{
    public static class DateTimeExtensions
    {
        public const string PaypalDateTimeFormatter = "yyyy-MM-ddTHH\\:mm\\:ssZ";
        /// <summary>
        /// The date and time when the webhook event notification was created, in Internet date and time format.
        /// https://www.rfc-editor.org/rfc/rfc3339#section-5.6
        /// To ISO 8601 [ISO8601] 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToPaypalString(this DateTime dateTime) 
        { 
            return dateTime.ToString(PaypalDateTimeFormatter);
        }

        /// <summary>
        /// Safe parser for DateTime ISO8601 strings, returns null if parsing fails.
        /// </summary>
        /// <param name="paypalIso8601FormattedDatetime"></param>
        /// <returns>returns null if parsing fails, otherwise a valid <see cref="DateTime"/></returns>
        public static DateTime? FromPaypalString(this string? paypalIso8601FormattedDatetime)
        {
            if (paypalIso8601FormattedDatetime != null)
            {
                if (DateTime.TryParseExact(paypalIso8601FormattedDatetime, PaypalDateTimeFormatter, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out DateTime parsedDateTime))
                {
                    return parsedDateTime;
                }
            }
            return null;
        }
    }
}
