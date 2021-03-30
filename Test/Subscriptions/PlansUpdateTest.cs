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

namespace PayPalCheckoutSdk.Subscriptions.Test
{
    [Collection("Subscriptions")]
    public class PlansUpdateTest
    {
        private List<Patch<string>> buildRequestBody()
        {
            return new List<Patch<string>>()
            {
                new Patch<string>()
                {
                    Op = "replace",
                    Path = "description",
                    Value = "added_description"
                }
            };
        }

        [Theory]
        [InlineData(new object[] { "ERRSUB011", "INTERNAL_SERVER_ERROR" })]
        [InlineData(new object[] { "ERRSUB012", "NOT_AUTHORIZED" })]
        [InlineData(new object[] { "ERRSUB013", "RESOURCE_NOT_FOUND" })]
        [InlineData(new object[] { "ERRSUB014", "INVALID_REQUEST" })]
        public async void TestPlansNegativeUpdate(string planId, string errorName)
        {
            // - Update Plan
            PlansPatchRequest<string> patchRequest = new PlansPatchRequest<string>(planId);
            patchRequest.RequestBody(buildRequestBody());

            PayPalHttp.HttpException httpException = await Assert.ThrowsAsync<PayPalHttp.HttpException>(() => 
            {
                return TestHarness.client().Execute(patchRequest);
            });

            Assert.Equal(errorName, httpException.GetError().Name);
            
        }
    }
}
