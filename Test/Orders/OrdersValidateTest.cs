using System.Threading.Tasks;
using PayPalCheckoutSdk.Test;
using PayPalHttp;
using Xunit;


namespace PayPalCheckoutSdk.Orders.Test
{
    [Collection("Orders")]
    public class OrdersValidateTest
    {
        [Fact(Skip = "This test is an example. In production, you will need payer approval")]
        public async Task TestOrdersValidateRequest()
        {
            OrdersValidateRequest request = new OrdersValidateRequest("ORDER-ID");

            HttpResponse response = await TestHarness.client().Execute(request);
            Assert.Equal(200, (int) response.StatusCode);
            Assert.NotNull(response.Result<Order>());
        }
    }
}
