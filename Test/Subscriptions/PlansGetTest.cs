using System;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Collections.Generic;
using PayPalHttp;
using Xunit;
using PayPalCheckoutSdk.Test;
using static PayPalCheckoutSdk.Test.TestHarness;


namespace PayPalCheckoutSdk.Subscriptions.Test
{
    [Collection("Subscriptions")]
    public class PlansGetTest
    {
        [Fact]
        public async void TestPlansGetRequest()
        {
            //var response = await OrdersCreateTest.CreateOrder();
            //Order createdOrder = response.Result<Order>();

            PlansGetRequest request = new PlansGetRequest();

            var response = await TestHarness.client().Execute(request);
            Assert.Equal(200, (int) response.StatusCode);
            
            PlanCollection retrievedPlanCollection = response.Result<PlanCollection>();
            Assert.NotNull(retrievedPlanCollection);
            //Assert.Equal(retrievedPlanCollection.Id, createdOrder.Id);
            //Assert.NotNull(retrievedPlanCollection.PurchaseUnits);
            //Assert.Equal(retrievedPlanCollection.PurchaseUnits.Count, createdOrder.PurchaseUnits.Count);

            //for (int count = 0; count < retrievedPlanCollection.PurchaseUnits.Count; count++) {
            //    PurchaseUnit retrievedOrderPurchaseUnit = retrievedPlanCollection.PurchaseUnits[count];
            //    PurchaseUnit createdOrderPurchaseUnit = createdOrder.PurchaseUnits[count];
            //    Assert.Equal(retrievedOrderPurchaseUnit.ReferenceId, createdOrderPurchaseUnit.ReferenceId);
            //    Assert.Equal(retrievedOrderPurchaseUnit.AmountWithBreakdown.CurrencyCode, createdOrderPurchaseUnit.AmountWithBreakdown.CurrencyCode);
            //    Assert.Equal(retrievedOrderPurchaseUnit.AmountWithBreakdown.Value, createdOrderPurchaseUnit.AmountWithBreakdown.Value);
            //}

            //Assert.NotNull(retrievedPlanCollection.CreateTime);

            Assert.NotNull(retrievedPlanCollection.Links);
            //bool foundApproveURL = false;
            //foreach (var linkDescription in retrievedPlanCollection.Links) {
            //    if ("approve".Equals(linkDescription.Rel)) {
            //        foundApproveURL = true;
            //        Assert.NotNull(linkDescription.Href);
            //        Assert.Equal("GET", linkDescription.Method);
            //        Console.WriteLine(linkDescription.Href);
            //    }
            //}

            //Console.WriteLine(createdOrder.Id);
            //Assert.True(foundApproveURL);
            //Assert.Equal("CREATED", createdOrder.Status);

        }
    }
}
