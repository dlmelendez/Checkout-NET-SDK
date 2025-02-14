﻿using System.Collections.Generic;
using System.Threading.Tasks;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Test;
using Xunit;

namespace PayPalCheckoutSdk.Orders.Test
{
    [Collection("Orders")]
    public class OrdersPatchTest
    {
        private static List<Patch<string>> buildRequestBody()
        {
            return
            [
                new Patch<string>()
                {
                    Op = "add",
                    Path = "/purchase_units/@reference_id=='test_ref_id1'/description",
                    Value = "added_description"
                }
            ];
        }

        [Fact]
        public async Task TestOrdersPatchRequest()
        {   
            var response = await OrdersCreateTest.CreateOrder();
            Order createdOrder = response.Result<Order>();
            OrdersPatchRequest<string> request = new OrdersPatchRequest<string>(createdOrder.Id);
            request.RequestBody(buildRequestBody());

            response = await TestHarness.client().Execute(request);
            Assert.Equal(204, (int) response.StatusCode);

            response = await TestHarness.client().Execute(new OrdersGetRequest(createdOrder.Id));
            Assert.Equal(200, (int) response.StatusCode);

            Order getOrder = response.Result<Order>();

            PurchaseUnit firstPurchaseUnit = getOrder.PurchaseUnits[0];
            Assert.Equal("test_ref_id1", firstPurchaseUnit.ReferenceId);
            Assert.Equal("USD", firstPurchaseUnit.AmountWithBreakdown.CurrencyCode);
            Assert.Equal("100.00", firstPurchaseUnit.AmountWithBreakdown.Value);
            Assert.Equal("added_description", firstPurchaseUnit.Description);

        }
    }
}
