using System.Threading.Tasks;
using PayPalCheckoutSdk.Subscriptions;
using PayPalHttp;
using Xunit;

namespace Test.Subscriptions
{
    [Collection("Subscriptions")]
    public class PlansDeactivateTest
    {

        [Theory]
        [InlineData(["ERRSUB019", "INTERNAL_SERVER_ERROR"])]
        [InlineData(["ERRSUB020", "NOT_AUTHORIZED"])]
        [InlineData(["ERRSUB021", "RESOURCE_NOT_FOUND"])]
        [InlineData(["ERRSUB022", "UNPROCESSABLE_ENTITY"])]
        public async Task TestPlansNegativeDeactivate(string subscriptionId, string errorName)
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
