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
        [InlineData(new object[] { "ERRSUB066", "INTERNAL_SERVER_ERROR" })]
        [InlineData(new object[] { "ERRSUB067", "NOT_AUTHORIZED" })]
        [InlineData(new object[] { "ERRSUB068", "RESOURCE_NOT_FOUND" })]
        [InlineData(new object[] { "ERRSUB069", "UNPROCESSABLE_ENTITY" })]
        [InlineData(new object[] { "ERRSUB070", "UNPROCESSABLE_ENTITY" })]
        public async void TestSubscriptionsNegativeActivate(string subscriptionId, string errorName)
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
