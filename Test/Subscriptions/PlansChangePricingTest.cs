using System.Collections.Generic;
using System.Threading.Tasks;
using PayPalCheckoutSdk.Subscriptions;
using PayPalHttp;
using Xunit;

namespace Test.Subscriptions
{
    [Collection("Subscriptions")]
    public class PlansChangePricingTest
    {
        private static List<UpdatePricingSchemeRequest> buildRequestBody()
        {
            return  [ new UpdatePricingSchemeRequest()
            {

            }];
        }

        [Theory]
        [InlineData(["ERRSUB023", "INTERNAL_SERVER_ERROR"])]
        [InlineData(["ERRSUB024", "NOT_AUTHORIZED"])]
        [InlineData(["ERRSUB026", "RESOURCE_NOT_FOUND"])]
        [InlineData(["ERRSUB025", "INVALID_REQUEST"])]
        public async Task TestPlansNegativeChangePricing(string planId, string errorName)
        {
            // - Change Plan Pricing
            PlansChangePricingRequest patchRequest = new PlansChangePricingRequest(planId);
            patchRequest.RequestBody(buildRequestBody());

            PayPalHttp.HttpException httpException = await Assert.ThrowsAsync<PayPalHttp.HttpException>(() => 
            {
                return TestHarness.client().Execute(patchRequest);
            });

            Assert.Equal(errorName, httpException.GetError().Name);
            
        }
    }
}
