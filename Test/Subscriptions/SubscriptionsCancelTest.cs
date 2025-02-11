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
    public class SubscriptionsCancelTest
    {

        [Theory]
        [InlineData(["ERRSUB063", "INTERNAL_SERVER_ERROR"])]
        [InlineData(["ERRSUB064", "NOT_AUTHORIZED"])]
        [InlineData(["ERRSUB065", "RESOURCE_NOT_FOUND"])]
        public async Task TestSubscriptionsNegativeCancel(string subscriptionId, string errorName)
        {
            // - Cancel Subscription
            SubscriptionsCancelRequest cancelRequest = new SubscriptionsCancelRequest(subscriptionId);
            cancelRequest.RequestBody(new SubscriptionCancelRequest() 
            {
                 Reason = "Cancel reason"
            });

            PayPalHttp.HttpException httpException = await Assert.ThrowsAsync<PayPalHttp.HttpException>(() => 
            {
                return TestHarness.client().Execute(cancelRequest);
            });

            Assert.Equal(errorName, httpException.GetError().Name);
            
        }
    }
}
