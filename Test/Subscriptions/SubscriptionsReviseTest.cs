using System.Threading.Tasks;
using PayPalCheckoutSdk.Subscriptions;
using PayPalHttp;
using Xunit;

namespace Test.Subscriptions
{
    [Collection("Subscriptions")]
    public class SubscriptionsReviseTest
    {

        [Theory]
        [InlineData(["ERRSUB053", "INTERNAL_SERVER_ERROR"])]
        [InlineData(["ERRSUB054", "NOT_AUTHORIZED"])]
        [InlineData(["ERRSUB055", "INVALID_REQUEST"])]
        [InlineData(["ERRSUB056", "UNPROCESSABLE_ENTITY"])]
        public async Task TestSubscriptionsNegativeRevise(string subscriptionId, string errorName)
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
