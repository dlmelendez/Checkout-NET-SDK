using System.Threading.Tasks;
using PayPalCheckoutSdk.Subscriptions;
using PayPalHttp;
using Xunit;

namespace Test.Subscriptions
{
    [Collection("Subscriptions")]
    public class SubscriptionsCancelTest
    {

        [Theory]
        [InlineData(["ERRSUB063", "INTERNAL_SERVER_ERROR"])]
        [InlineData(["ERRSUB064", "NOT_AUTHORIZED"])]
        [InlineData(["ERRSUB065", "RESOURCE_NOT_FOUND"])]
        public async Task TestSubscriptionsNegativeCancel(string subscriptionId, string errorName)
        {
            // - Cancel Subscription
            SubscriptionsCancelRequest cancelRequest = new SubscriptionsCancelRequest(subscriptionId);
            cancelRequest.RequestBody(new SubscriptionCancelRequest() 
            {
                 Reason = "Cancel reason"
            });

            PayPalHttp.HttpException httpException = await Assert.ThrowsAsync<PayPalHttp.HttpException>(() => 
            {
                return TestHarness.client().Execute(cancelRequest);
            });

            Assert.Equal(errorName, httpException.GetError().Name);
            
        }
    }
}
