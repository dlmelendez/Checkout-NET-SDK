using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using PayPalCheckoutSdk.Test;
using Xunit;
using Xunit.Abstractions;

namespace PayPalCheckoutSdk.Webhooks.Test
{
    [Collection("Webhooks")]
    public class WebhooksTests
    {
        private readonly ITestOutputHelper _output;

        public WebhooksTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Theory]
        [InlineData(AnchorType.APPLICATION)]
        [InlineData(AnchorType.ACCOUNT)]
        public async void TestWebhooksGetEmptyRequest(AnchorType anchor)
        {
            WebhooksGetRequest request = new WebhooksGetRequest(anchor);

            var response = await TestHarness.client().Execute(request);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            WebhookList webhookList = response.Result<WebhookList>();
            Assert.NotNull(webhookList);
        }

        [Fact]
        public async Task TestCreateGetDeleteWebhooksRequest()
        {
            WebhookCreateRequest request = new WebhookCreateRequest();
            request.Prefer(HeaderValueConstants.PreferValueRepresentation);
            var webhook = new Webhook()
            {
                Url = "https://example.com/65432123456",
            };
            webhook.EventTypes.Add(new EventType() { Name = EventType.Wildcard });
            request.RequestBody(webhook);
            
            var createResponse = await TestHarness.client().Execute(request);
            var createResult = createResponse.Result<Webhook>();
            Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);

            Assert.NotNull(createResult);
            Assert.False(string.IsNullOrWhiteSpace(createResult.Id));
            _output.WriteLine($"webhookId: {createResult.Id}");

            try
            {
                //Get Webhook Details
                var getDetailsRequest = new WebhookGetRequest(createResult.Id);
                var getResponse = await TestHarness.client().Execute(getDetailsRequest);
                Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);

                var getDetailsResult = getResponse.Result<Webhook>();
                var eventType = getDetailsResult.EventTypes.FirstOrDefault(f => f.Name == EventType.Wildcard);
                Assert.NotNull(eventType);
                Assert.Equal<string>(createResult.Url, getDetailsResult.Url, StringComparer.OrdinalIgnoreCase);
                Assert.Equal<string>(createResult.Id, getDetailsResult.Id, StringComparer.OrdinalIgnoreCase);
                //
                // Get Event Types by Webhook
                var getEventTypesRequest = new EventTypesGetRequest(createResult.Id);
                var getEventTypesResponse = await TestHarness.client().Execute(getEventTypesRequest);
                Assert.Equal(HttpStatusCode.OK, getResponse.StatusCode);

                var getEventTypesResult = getEventTypesResponse.Result<EventTypeList>();
                var eventType2 = getEventTypesResult.EventTypes.FirstOrDefault(f => f.Name == EventType.Wildcard);
                Assert.NotNull(eventType2);
                //
            }
            finally
            {
                var deleteRequest = new WebhookDeleteRequest(createResult.Id);
                var deleteResponse = await TestHarness.client().Execute(deleteRequest);
                Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
            }

        }
    }
}
