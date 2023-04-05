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

namespace PayPalCheckoutSdk.Webhooks.Test
{
    [Collection("Webhooks")]
    public class WebhooksTests
    {
        [Fact]
        public async void TestWebhooksGetEmptyRequest()
        {
            //TODO: Tests
        }

        [Fact]
        public async Task TestCreateGetDeleteWebhooksRequest()
        {
            //TODO: Tests

        }
    }
}
