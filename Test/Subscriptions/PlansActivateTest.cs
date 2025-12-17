using System.Threading.Tasks;
using PayPalCheckoutSdk.Subscriptions;
using PayPalHttp;
using Xunit;

namespace Test.Subscriptions
{
    [Collection("Subscriptions")]
    public class PlansActivateTest
    {

        [Theory]
        [InlineData(["ERRSUB015", "INTERNAL_SERVER_ERROR"])]
        [InlineData(["ERRSUB016", "NOT_AUTHORIZED"])]
        [InlineData(["ERRSUB017", "RESOURCE_NOT_FOUND"])]
        [InlineData(["ERRSUB018", "UNPROCESSABLE_ENTITY"])]
        public async Task TestPlansNegativeActivate(string subscriptionId, string errorName)
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
