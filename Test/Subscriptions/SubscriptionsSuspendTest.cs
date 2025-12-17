using System.Threading.Tasks;
using PayPalCheckoutSdk.Subscriptions;
using PayPalHttp;
using Xunit;

namespace Test.Subscriptions
{
    [Collection("Subscriptions")]
    public class SubscriptionsSuspendTest
    {

        [Theory]
        [InlineData(["ERRSUB059", "INTERNAL_SERVER_ERROR"])]
        [InlineData(["ERRSUB060", "NOT_AUTHORIZED"])]
        [InlineData(["ERRSUB061", "RESOURCE_NOT_FOUND"])]
        [InlineData(["ERRSUB062", "UNPROCESSABLE_ENTITY"])]
        public async Task TestSubscriptionsNegativeSuspend(string subscriptionId, string errorName)
        {
            // - Suspend Subscription
            SubscriptionsSuspendRequest suspendRequest = new SubscriptionsSuspendRequest(subscriptionId);
            suspendRequest.RequestBody(new SubscriptionSuspendRequest() 
            {
                Reason = "Need to suspend"
            });

            PayPalHttp.HttpException httpException = await Assert.ThrowsAsync<PayPalHttp.HttpException>(() => 
            {
                return TestHarness.client().Execute(suspendRequest);
            });

            Assert.Equal(errorName, httpException.GetError().Name);
            
        }
    }
}
