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
    public class PlansActivateTest
    {

        [Theory]
        [InlineData(new object[] { "ERRSUB015", "INTERNAL_SERVER_ERROR" })]
        [InlineData(new object[] { "ERRSUB016", "NOT_AUTHORIZED" })]
        [InlineData(new object[] { "ERRSUB017", "RESOURCE_NOT_FOUND" })]
        [InlineData(new object[] { "ERRSUB018", "UNPROCESSABLE_ENTITY" })]
        public async void TestPlansNegativeActivate(string subscriptionId, string errorName)
        {
            // - Activate Plan
            PlansActivateRequest activateRequest = new PlansActivateRequest(subscriptionId);

            PayPalHttp.HttpException httpException = await Assert.ThrowsAsync<PayPalHttp.HttpException>(() => 
            {
                return TestHarness.client().Execute(activateRequest);
            });

            Assert.Equal(errorName, httpException.GetError().Name);
            
        }
    }
}
