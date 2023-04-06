using System;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Collections.Generic;
using PayPalHttp;
using Xunit;
using PayPalCheckoutSdk.Test;
using static PayPalCheckoutSdk.Test.TestHarness;
using System.Threading.Tasks;
using PayPalCheckoutSdk.Products;
using Xunit.Sdk;

namespace PayPalCheckoutSdk.Webhooks.Test
{
    [Collection("Webhooks")]
    public class WebhooksTests
    {
        [Theory]
        [InlineData(AnchorType.APPLICATION)]
        [InlineData(AnchorType.ACCOUNT)]
        public async void TestWebhooksGetEmptyRequest(AnchorType anchor)
        {
            WebhooksGetRequest request = new WebhooksGetRequest(anchor);

            var response = await TestHarness.client().Execute(request);
            Assert.Equal(200, (int)response.StatusCode);

            WebhookList webhookList = response.Result<WebhookList>();
            Assert.NotNull(webhookList);
        }

        [Fact]
        public async Task TestCreateGetDeleteWebhooksRequest()
        {
            //TODO: Tests

        }
    }
}
