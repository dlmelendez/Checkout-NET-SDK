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
    public class SubscriptionsActivateTest
    {

        [Theory]
        [InlineData(["ERRSUB066", "INTERNAL_SERVER_ERROR"])]
        [InlineData(["ERRSUB067", "NOT_AUTHORIZED"])]
        [InlineData(["ERRSUB068", "RESOURCE_NOT_FOUND"])]
        [InlineData(["ERRSUB069", "UNPROCESSABLE_ENTITY"])]
        [InlineData(["ERRSUB070", "UNPROCESSABLE_ENTITY"])]
        public async Task TestSubscriptionsNegativeActivate(string subscriptionId, string errorName)
        {
            // - Activate Subscription
            SubscriptionsActivateRequest activateRequest = new SubscriptionsActivateRequest(subscriptionId);
            activateRequest.RequestBody(new SubscriptionActivateRequest() 
            {
                Reason = "Need to activate"
            });

            PayPalHttp.HttpException httpException = await Assert.ThrowsAsync<PayPalHttp.HttpException>(() => 
            {
                return TestHarness.client().Execute(activateRequest);
            });

            Assert.Equal(errorName, httpException.GetError().Name);
            
        }
    }
}
