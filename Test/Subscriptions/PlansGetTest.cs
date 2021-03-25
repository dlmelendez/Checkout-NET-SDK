using System;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Collections.Generic;
using PayPalHttp;
using Xunit;
using PayPalCheckoutSdk.Test;
using static PayPalCheckoutSdk.Test.TestHarness;
using PayPalCheckoutSdk.Products.Test;
using PayPalCheckoutSdk.Products;
using System.Linq;

namespace PayPalCheckoutSdk.Subscriptions.Test
{
    [Collection("Subscriptions")]
    public class PlansGetTest
    {
        [Fact]
        public async void TestPlansGetRequest()
        {
            var createProductResponse = await ProductsCreateTest.CreateProduct();
            Product product1 = createProductResponse.Result<Product>();
            var plan1Response = await PlansCreateTest.CreatePlan(product1.Id, false, false);
            Plan plan1 = plan1Response.Result<Plan>();
            var plan2Response = await PlansCreateTest.CreatePlan(product1.Id, true, true);
            Plan plan2 = plan2Response.Result<Plan>();

            List<string> planIds = new List<string>() { plan1.Id, plan2.Id };
            Console.WriteLine(planIds[0] + " " + planIds[1]);

            PlansGetRequest request = new PlansGetRequest(product1.Id);

            var response = await TestHarness.client().Execute(request);
            Assert.Equal(200, (int) response.StatusCode);
            
            PlanCollection retrievedPlanCollection = response.Result<PlanCollection>();
            Assert.NotNull(retrievedPlanCollection);
            Assert.NotEmpty(retrievedPlanCollection.Plans);
            Assert.Equal(2, retrievedPlanCollection.Plans.Count);
            Assert.NotNull(retrievedPlanCollection.Plans.FirstOrDefault(f => f.Id == plan1.Id));
            Assert.NotNull(retrievedPlanCollection.Plans.FirstOrDefault(f => f.Id == plan2.Id));


            Assert.NotNull(retrievedPlanCollection.Links);            

        }       

    }
}
