using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using PayPalCheckoutSdk.Orders;
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
        public async Task TestEventsRequest()
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

            Capture capture = simulateResult.GetResource<Capture>();
            Assert.NotNull(capture);
            Assert.False(string.IsNullOrWhiteSpace(capture.Id));
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
                    WebhookIds =
                    [
                        createWebhookResult.Id
                    ]
                });
                var resendResponse = await TestHarness.client().Execute(resendRequest);
                //Resource Invalid Exception here
                //
            }
            catch (PayPalHttp.HttpException ppEx)
                when (ppEx.GetError()?.Name == "INVALID_RESOURCE_ID" || ppEx.GetError()?.Name == "INTERNAL_SERVICE_ERROR")
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
        // Retiring this test as it is not possible to setup a positive test.
        // Paypal remote certificate is expired.
        //[Fact]
        //public async Task TestVerifySignatureEventCertNegative()
        //{
        //    var verifySignature = new VerifyWebhookSignature()
        //    {
        //        CertUrl = "https://api.sandbox.paypal.com/v1/notifications/certs/CERT-360caa42-fca2a594-2d7ab011",
        //        AuthAlgo = "SHA256withRSA",
        //        TransmissionId = "d0a19f40-e46b-11ed-af6d-5d1995803275",
        //        TransmissionSig = "Tg9131sVOAPVYn5XjQsR8C/tcOWuPkc//VkifmPX7TZD24\u002BkuRLIZ\u002BzfbMxkeuS0er1EzLHw4MRG83xkYoEGLe9QWD4nfvg/HIAvXDNgEZCG2BrPIwPaiFrA9G0SX22\u002BvpOiy4\u002BbWNrKAFZdt/gobEairdaqVe1unsCxCJQT6czTFiOBBAn85yDCSIhctk6RbEkprxjwTrgLDf1Cq41AgxZ72RwVuZlJHbMQF5Dl/cRQ9pU38I0HOq0DRXiiaJwrp7UJXkLRdu3ge4ivN3Th1Wq8D\u002BL/0xYrub9lFB0TKI2a7XBKlaua9aT7XrtuwZeI1cNz/jr0luz7K6JYdiZSlQ==",
        //        TransmissionTime = "2023-04-26T19:52:03Z",
        //        WebhookId = "3RY87287BU229431J",
        //        WebhookEventRequestBody = "{\r\n    \"create_time\": \"2023-04-26T19:51:57.324Z\",\r\n    \"event_type\": \"BILLING.SUBSCRIPTION.ACTIVATED\",\r\n    \"event_version\": \"1.0\",\r\n    \"id\": \"WH-2GA799794C526164B-4HC631101W386110B\",\r\n    \"links\": [\r\n      {\r\n        \"encType\": null,\r\n        \"href\": \"https://api.sandbox.paypal.com/v1/notifications/webhooks-events/WH-2GA799794C526164B-4HC631101W386110B\",\r\n        \"mediaType\": null,\r\n        \"method\": \"GET\",\r\n        \"rel\": \"self\",\r\n        \"title\": null\r\n      },\r\n      {\r\n        \"encType\": null,\r\n        \"href\": \"https://api.sandbox.paypal.com/v1/notifications/webhooks-events/WH-2GA799794C526164B-4HC631101W386110B/resend\",\r\n        \"mediaType\": null,\r\n        \"method\": \"POST\",\r\n        \"rel\": \"resend\",\r\n        \"title\": null\r\n      }\r\n    ],\r\n    \"resource\": {\r\n      \"quantity\": \"1\",\r\n      \"subscriber\": {\r\n        \"email_address\": \"davem-buyer@opticnerve.ai\",\r\n        \"payer_id\": \"P2DZ2LMXC5SY2\",\r\n        \"name\": {\r\n          \"given_name\": \"test\",\r\n          \"surname\": \"buyer\"\r\n        },\r\n        \"shipping_address\": {\r\n          \"address\": {\r\n            \"address_line_1\": \"1 Main St\",\r\n            \"admin_area_2\": \"San Jose\",\r\n            \"admin_area_1\": \"CA\",\r\n            \"postal_code\": \"95131\",\r\n            \"country_code\": \"US\"\r\n          }\r\n        }\r\n      },\r\n      \"create_time\": \"2023-04-26T19:51:53Z\",\r\n      \"plan_overridden\": false,\r\n      \"shipping_amount\": {\r\n        \"currency_code\": \"USD\",\r\n        \"value\": \"0.0\"\r\n      },\r\n      \"start_time\": \"2023-04-26T19:51:38Z\",\r\n      \"update_time\": \"2023-04-26T19:51:53Z\",\r\n      \"billing_info\": {\r\n        \"outstanding_balance\": {\r\n          \"currency_code\": \"USD\",\r\n          \"value\": \"0.0\"\r\n        },\r\n        \"cycle_executions\": [\r\n          {\r\n            \"tenure_type\": \"TRIAL\",\r\n            \"sequence\": 1,\r\n            \"cycles_completed\": 1,\r\n            \"cycles_remaining\": 0,\r\n            \"current_pricing_scheme_version\": 1,\r\n            \"total_cycles\": 1\r\n          },\r\n          {\r\n            \"tenure_type\": \"REGULAR\",\r\n            \"sequence\": 2,\r\n            \"cycles_completed\": 0,\r\n            \"cycles_remaining\": 0,\r\n            \"current_pricing_scheme_version\": 1,\r\n            \"total_cycles\": 0\r\n          }\r\n        ],\r\n        \"next_billing_time\": \"2023-05-10T10:00:00Z\",\r\n        \"failed_payments_count\": 0\r\n      },\r\n      \"links\": [\r\n        {\r\n          \"href\": \"https://api.sandbox.paypal.com/v1/billing/subscriptions/I-B9YUUVSYXFX3/cancel\",\r\n          \"rel\": \"cancel\",\r\n          \"method\": \"POST\",\r\n          \"encType\": \"application/json\"\r\n        },\r\n        {\r\n          \"href\": \"https://api.sandbox.paypal.com/v1/billing/subscriptions/I-B9YUUVSYXFX3\",\r\n          \"rel\": \"edit\",\r\n          \"method\": \"PATCH\",\r\n          \"encType\": \"application/json\"\r\n        },\r\n        {\r\n          \"href\": \"https://api.sandbox.paypal.com/v1/billing/subscriptions/I-B9YUUVSYXFX3\",\r\n          \"rel\": \"self\",\r\n          \"method\": \"GET\",\r\n          \"encType\": \"application/json\"\r\n        },\r\n        {\r\n          \"href\": \"https://api.sandbox.paypal.com/v1/billing/subscriptions/I-B9YUUVSYXFX3/suspend\",\r\n          \"rel\": \"suspend\",\r\n          \"method\": \"POST\",\r\n          \"encType\": \"application/json\"\r\n        },\r\n        {\r\n          \"href\": \"https://api.sandbox.paypal.com/v1/billing/subscriptions/I-B9YUUVSYXFX3/capture\",\r\n          \"rel\": \"capture\",\r\n          \"method\": \"POST\",\r\n          \"encType\": \"application/json\"\r\n        }\r\n      ],\r\n      \"id\": \"I-B9YUUVSYXFX3\",\r\n      \"plan_id\": \"P-11V96330AW144370PMBGAOEA\",\r\n      \"status\": \"ACTIVE\",\r\n      \"status_update_time\": \"2023-04-26T19:51:53Z\"\r\n    },\r\n    \"resource_type\": \"subscription\",\r\n    \"resource_version\": \"2.0\",\r\n    \"summary\": \"Subscription activated\"\r\n  }",
        //    };

        //    Stopwatch stopwatch = Stopwatch.StartNew();
        //    bool verified = await VerifyWebhookEvent.ValidateReceivedEventAsync(verifySignature);
        //    stopwatch.Stop();
        //    _output.WriteLine($"1st ValidateReceivedEventAsync {stopwatch.Elapsed.TotalMilliseconds} ms");
        //    stopwatch.Restart();
        //    verified = await VerifyWebhookEvent.ValidateReceivedEventAsync(verifySignature);
        //    stopwatch.Stop();
        //    _output.WriteLine($"2nd ValidateReceivedEventAsync {stopwatch.Elapsed.TotalMilliseconds} ms");
        //    //
        //    // Unfortunately, we it is too difficult to setup a positive test.
        //    // We are mainly checking for any exceptions during validation
        //    Assert.False(verified);

        //}
    }
}
