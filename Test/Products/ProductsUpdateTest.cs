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

namespace PayPalCheckoutSdk.Products.Test
{
    [Collection("Products")]
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
        [InlineData(["ERRCAT011", "INTERNAL_SERVER_ERROR"])]
        [InlineData(["ERRCAT012", "NOT_AUTHORIZED"])]
        [InlineData(["ERRCAT013", "INVALID_REQUEST"])]
        [InlineData(["ERRCAT014", "UNPROCESSABLE_ENTITY"])]
        public async Task TestProductsNegativeUpdate(string productId, string errorName)
        {
            // - Update Product
            ProductsPatchRequest<string> patchRequest = new ProductsPatchRequest<string>(productId);
            patchRequest.RequestBody(buildRequestBody());

            PayPalHttp.HttpException httpException = await Assert.ThrowsAsync<PayPalHttp.HttpException>(() => 
            {
                return TestHarness.client().Execute(patchRequest);
            });

            Assert.Equal(errorName, httpException.GetError().Name);
            
        }
    }
}
