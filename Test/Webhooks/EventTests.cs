using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using PayPalCheckoutSdk.Test;
using PayPalHttp;
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

        [Fact]
        public async Task TestSimulateEvent()
        {
            EventSimulateRequest simulateRequest = new EventSimulateRequest();
            simulateRequest.Prefer(HeaderValueConstants.PreferValueRepresentation);
            var simulate = new EventSimulate()
            {
                Url = "https://example.com/65432123456-3467678768768",
                EventType = "PAYMENT.CAPTURE.COMPLETED"
            };
            simulateRequest.RequestBody(simulate);

            var simulateResponse = await TestHarness.client().Execute(simulateRequest);
            var simulateResult = simulateResponse.Result<Event>();
            Assert.Equal(HttpStatusCode.Accepted, simulateResponse.StatusCode);

            Assert.NotNull(simulateResult);
            Assert.False(string.IsNullOrWhiteSpace(simulateResult.Id));
        }

        [Fact]
        public async Task TestResendNegative()
        {
            WebhookCreateRequest createWebhookRequest = new WebhookCreateRequest();
            createWebhookRequest.Prefer(HeaderValueConstants.PreferValueRepresentation);
            var webhook = new Webhook()
            {
                Url = "https://example.com/65432123456-787887adsf23333",
            };
            webhook.EventTypes.Add(new EventType() { Name = EventType.Wildcard });
            createWebhookRequest.RequestBody(webhook);

            var createWebhookResponse = await TestHarness.client().Execute(createWebhookRequest);
            var createWebhookResult = createWebhookResponse.Result<Webhook>();
            Assert.Equal(HttpStatusCode.Created, createWebhookResponse.StatusCode);

            Assert.NotNull(createWebhookResult);
            Assert.False(string.IsNullOrWhiteSpace(createWebhookResult.Id));
            _output.WriteLine($"webhookId: {createWebhookResult.Id}");

            try
            {
                //Simulate Event
                EventSimulateRequest simulateRequest = new EventSimulateRequest();
                simulateRequest.Prefer(HeaderValueConstants.PreferValueRepresentation);
                var simulate = new EventSimulate()
                {
                    WebhookId = createWebhookResult.Id,
                    EventType = "PAYMENT.CAPTURE.COMPLETED"
                };
                simulateRequest.RequestBody(simulate);

                var simulateResponse = await TestHarness.client().Execute(simulateRequest);
                var simulateResult = simulateResponse.Result<Event>();
                Assert.Equal(HttpStatusCode.Accepted, simulateResponse.StatusCode);

                Assert.NotNull(simulateResult);
                Assert.False(string.IsNullOrWhiteSpace(simulateResult.Id));
                _output.WriteLine($"simulateEventId: {simulateResult.Id}");

                //
                // Resend Event by Webhook
                var resendRequest = new EventResendRequest(simulateResult.Id);
                resendRequest.RequestBody(new EventResend()
                {
                    WebhookIds = new List<string>()
                    {
                        createWebhookResult.Id
                    }
                });
                var resendResponse = await TestHarness.client().Execute(resendRequest);
                //Resource Invalid Exception here
                //
            }
            catch (PayPalHttp.HttpException ppEx)
                when (ppEx.GetError()?.Name == "INVALID_RESOURCE_ID")
            {
                // noop
                //Ignore Invalid Resource Id message because resend doesn't work with simulated events
                //Pattern can be used by valid events.
            }
            finally
            {
                var deleteRequest = new WebhookDeleteRequest(createWebhookResult.Id);
                var deleteResponse = await TestHarness.client().Execute(deleteRequest);
                Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
            }

        }

        [Fact]
        public async Task TestVerifySignatureEventNegative()
        {
            VerifyWebhookSignatureRequest simulateRequest = new VerifyWebhookSignatureRequest();
            
            var verifySignature = new VerifyWebhookSignature()
            {
                CertUrl = "https://example.com/65432123456-3467678768768",
                AuthAlgo = Guid.NewGuid().ToString("N"),
                TransmissionId = Guid.NewGuid().ToString("N"),
                TransmissionSig = Guid.NewGuid().ToString("N"),
                TransmissionTime = DateTime.UtcNow.ToPaypalString(),
                WebhookId = "3RD03749806828333",
                WebhookEvent = new Event() { Id = Guid.NewGuid().ToString(), EventType = "PAYMENT.CAPTURE.COMPLETED" }
            };
            simulateRequest.RequestBody(verifySignature);

            var createResponse = await TestHarness.client().Execute(simulateRequest);
            var createResult = createResponse.Result<VerifyWebhookSignatureResponse>();
            Assert.Equal(HttpStatusCode.OK, createResponse.StatusCode);

            Assert.False(createResult.ValidSignature);
        }
    }
}
