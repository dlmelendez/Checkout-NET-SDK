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
    public class SubscriptionsReviseTest
    {

        [Theory]
        [InlineData(new object[] { "ERRSUB053", "INTERNAL_SERVER_ERROR" })]
        [InlineData(new object[] { "ERRSUB054", "NOT_AUTHORIZED" })]
        [InlineData(new object[] { "ERRSUB055", "INVALID_REQUEST" })]
        [InlineData(new object[] { "ERRSUB056", "UNPROCESSABLE_ENTITY" })]
        public async void TestSubscriptionsNegativeRevise(string subscriptionId, string errorName)
        {
            // - Revise Subscription
            SubscriptionsReviseRequest reviseRequest = new SubscriptionsReviseRequest(subscriptionId);
            reviseRequest.RequestBody(new SubscriptionReviseRequest() 
            {
                 
            });

            PayPalHttp.HttpException httpException = await Assert.ThrowsAsync<PayPalHttp.HttpException>(() => 
            {
                return TestHarness.client().Execute(reviseRequest);
            });

            Assert.Equal(errorName, httpException.GetError().Name);
            
        }
    }
}
