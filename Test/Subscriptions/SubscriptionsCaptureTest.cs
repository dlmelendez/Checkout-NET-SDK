using System;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayPalHttp;
using Xunit;
using Xunit.Abstractions;
using PayPalCheckoutSdk.Test;
using static PayPalCheckoutSdk.Test.TestHarness;
using System.Diagnostics;
using PayPalCheckoutSdk.Core;
using System.Linq;
using PayPalCheckoutSdk.Products;
using PayPalCheckoutSdk.Products.Test;

namespace PayPalCheckoutSdk.Subscriptions.Test
{
    [Collection("Subscriptions")]
    public class SubscriptionsCaptureTest
    {

        [Theory]
        [InlineData(["ERRSUB071", "INTERNAL_SERVER_ERROR"])]
        [InlineData(["ERRSUB072", "NOT_AUTHORIZED"])]
        [InlineData(["ERRSUB073", "RESOURCE_NOT_FOUND"])]
        [InlineData(["ERRSUB074", "INVALID_REQUEST"])]
        [InlineData(["ERRSUB075", "INVALID_REQUEST"])]
        public async Task TestSubscriptionsNegativeCapture(string subscriptionId, string errorName)
        {
            // - Capture Subscription
            SubscriptionsCaptureRequest captureRequest = new SubscriptionsCaptureRequest(subscriptionId);
            captureRequest.RequestBody(new SubscriptionCaptureRequest() 
            {
                 Note = "This is a note"
            });

            PayPalHttp.HttpException httpException = await Assert.ThrowsAsync<PayPalHttp.HttpException>(() => 
            {
                return TestHarness.client().Execute(captureRequest);
            });

            Assert.Equal(errorName, httpException.GetError().Name);
            
        }
    }
}
