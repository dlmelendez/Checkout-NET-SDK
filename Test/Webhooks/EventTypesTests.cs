using System.Net;
using System.Threading.Tasks;
using PayPalCheckoutSdk.Webhooks;
using Xunit;
using Xunit.Abstractions;

namespace Test.Webhooks
{
    [Collection("EventTypes")]
    public class EventTypesTests(ITestOutputHelper output)
    {
        private readonly ITestOutputHelper _output = output;

        [Fact]
        public async Task TestEventTypesAvailableRequest()
        {
            EventTypesAvailableGetRequest request = new EventTypesAvailableGetRequest();

            var response = await TestHarness.client().Execute(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            EventTypeList eventTypesList = response.Result<EventTypeList>();
            Assert.NotNull(eventTypesList?.EventTypes);
            Assert.NotEmpty(eventTypesList.EventTypes);
            foreach (var eventType in eventTypesList.EventTypes)
            {
                _output.WriteLine(eventType.Name);
            }
        }

    }
}
