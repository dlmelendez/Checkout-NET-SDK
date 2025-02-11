using System.Threading.Tasks;
using PayPalCheckoutSdk.Test;
using PayPalHttp;
using Xunit;


namespace PayPalCheckoutSdk.Orders.Test
{
    [Collection("Orders")]
    public class OrdersCaptureTest
    {

        [Fact(Skip = "This test is an example. In production, you will need payer approval")]
        public async Task TestOrdersCaptureRequest()
        {   
            var orderResponse = await OrdersCreateTest.CreateOrder();
            var orderId = orderResponse.Result<Order>().Id;
            OrdersCaptureRequest request = new OrdersCaptureRequest(orderId);
            request.RequestBody(new OrderActionRequest());

            HttpResponse response = await TestHarness.client().Execute(request);
            Assert.Equal(201, (int) response.StatusCode);
            Assert.NotNull(response.Result<Order>());
        }
    }
}
