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
    public class PlansDeactivateTest
    {

        [Theory]
        [InlineData(new object[] { "ERRSUB019", "INTERNAL_SERVER_ERROR" })]
        [InlineData(new object[] { "ERRSUB020", "NOT_AUTHORIZED" })]
        [InlineData(new object[] { "ERRSUB021", "RESOURCE_NOT_FOUND" })]
        [InlineData(new object[] { "ERRSUB022", "UNPROCESSABLE_ENTITY" })]
        public async void TestPlansNegativeDeactivate(string subscriptionId, string errorName)
        {
            // - Deactivate Plan
            PlansDeactivateRequest deactivateRequest = new PlansDeactivateRequest(subscriptionId);

            PayPalHttp.HttpException httpException = await Assert.ThrowsAsync<PayPalHttp.HttpException>(() => 
            {
                return TestHarness.client().Execute(deactivateRequest);
            });

            Assert.Equal(errorName, httpException.GetError().Name);
            
        }
    }
}
