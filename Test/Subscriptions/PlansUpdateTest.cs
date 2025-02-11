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
            return
            [
                new Patch<string>()
                {
                    Op = "replace",
                    Path = "description",
                    Value = "added_description"
                }
            ];
        }

        [Theory]
        [InlineData(["ERRSUB011", "INTERNAL_SERVER_ERROR"])]
        [InlineData(["ERRSUB012", "NOT_AUTHORIZED"])]
        [InlineData(["ERRSUB013", "RESOURCE_NOT_FOUND"])]
        [InlineData(["ERRSUB014", "INVALID_REQUEST"])]
        public async Task TestPlansNegativeUpdate(string planId, string errorName)
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
