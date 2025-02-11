using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using PayPalCheckoutSdk.Test;
using Xunit;
using Xunit.Abstractions;

namespace PayPalCheckoutSdk.Webhooks.Test
{
    [Collection("EventTypes")]
    public class EventTypesTests
    {
        private readonly ITestOutputHelper _output;

        public EventTypesTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task TestEventTypesAvailableRequest()
        {
            EventTypesAvailableGetRequest request = new EventTypesAvailableGetRequest();

            var response = await TestHarness.client().Execute(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            EventTypeList eventTypesList = response.Result<EventTypeList>();
            Assert.NotNull(eventTypesList?.EventTypes);
            Assert.True(eventTypesList?.EventTypes.Any());
            foreach (var eventType in eventTypesList.EventTypes)
            {
                _output.WriteLine(eventType.Name);
            }
        }

    }
}
