using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using PayPalCheckoutSdk.Test;
using Xunit;
using Xunit.Abstractions;

namespace PayPalCheckoutSdk.Webhooks.Test
{
    [Collection("Event")]
    public class EventTests
    {
        private readonly ITestOutputHelper _output;

        public EventTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async void TestEventsRequest()
        {
            DateTime endDt1 = DateTime.UtcNow;
            string endTime = endDt1.ToPaypalString();
            string startTime = DateTime.UtcNow.AddDays(-10).ToPaypalString();
            string eventType = "BILLING.SUBSCRIPTION.CREATED";
            int pageSize = 15;

            DateTime? endDt = endTime.FromPaypalString();
            Assert.NotNull(endDt);
            Assert.Equal(endTime, endDt.Value.ToPaypalString());
            Assert.Equal(endDt1.Year, endDt.Value.Year);
            Assert.Equal(endDt1.Month, endDt.Value.Month);
            Assert.Equal(endDt1.Day, endDt.Value.Day);
            Assert.Equal(endDt1.Hour, endDt.Value.Hour);
            Assert.Equal(endDt1.Minute, endDt.Value.Minute);
            Assert.Equal(endDt1.Second, endDt.Value.Second);

            _output.WriteLine($"{startTime}, {endTime}, {eventType}, {pageSize}", startTime, endTime, eventType, pageSize);
            EventsGetRequest request = new EventsGetRequest(endTime: endTime, eventType: eventType, pageSize: pageSize, startTime: startTime);

            var response = await TestHarness.client().Execute(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            EventList eventsList = response.Result<EventList>();
            Assert.NotNull(eventsList);
        }

    }
}
