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
    public class SubscriptionsSuspendTest
    {

        [Theory]
        [InlineData(["ERRSUB059", "INTERNAL_SERVER_ERROR"])]
        [InlineData(["ERRSUB060", "NOT_AUTHORIZED"])]
        [InlineData(["ERRSUB061", "RESOURCE_NOT_FOUND"])]
        [InlineData(["ERRSUB062", "UNPROCESSABLE_ENTITY"])]
        public async Task TestSubscriptionsNegativeSuspend(string subscriptionId, string errorName)
        {
            // - Suspend Subscription
            SubscriptionsSuspendRequest suspendRequest = new SubscriptionsSuspendRequest(subscriptionId);
            suspendRequest.RequestBody(new SubscriptionSuspendRequest() 
            {
                Reason = "Need to suspend"
            });

            PayPalHttp.HttpException httpException = await Assert.ThrowsAsync<PayPalHttp.HttpException>(() => 
            {
                return TestHarness.client().Execute(suspendRequest);
            });

            Assert.Equal(errorName, httpException.GetError().Name);
            
        }
    }
}
