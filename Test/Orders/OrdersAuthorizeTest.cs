using System.Threading.Tasks;
using PayPalCheckoutSdk.Orders;
using PayPalHttp;
using Xunit;


namespace Test.Orders
{
    [Collection("Orders")]
    public class OrdersAuthorizeTest
    {
        [Fact(Skip = "This test is an example. In production, you will need payer approval")]
        public async Task TestOrdersAuthorizeRequest()
        {
            OrdersAuthorizeRequest request = new OrdersAuthorizeRequest("ORDER-ID");

            HttpResponse response = await TestHarness.client().Execute(request);
            Assert.Equal(200,(int) response.StatusCode);
            Assert.NotNull(response.Result<Order>());
        }
    }
}
