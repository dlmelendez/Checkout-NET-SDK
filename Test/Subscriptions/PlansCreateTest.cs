using System;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using PayPalHttp;
using Xunit;
using Xunit.Abstractions;
using PayPalCheckoutSdk.Test;
using static PayPalCheckoutSdk.Test.TestHarness;
using System.Diagnostics;
using PayPalCheckoutSdk.Core;
using System.Linq;
using PayPalCheckoutSdk.Products;
using PayPalCheckoutSdk.Products.Test;

namespace PayPalCheckoutSdk.Subscriptions.Test
{
    [Collection("Subscriptions")]
    public class PlansCreateTest
    {
        public const string PlanId1 = "test-plan1";
        public const string PlanId2 = "test-plan2";

        private static PlanRequest buildRequestBody(string productId, bool freeTrial = true, bool qtySupported = true)
        {
            string id = Guid.NewGuid().ToString();
            var cycles = new List<BillingCycle>()
                {
                    new BillingCycle()
                    {
                         Frequency = new Frequency()
                         {
                             IntervalCount = 14,
                             IntervalUnit = "DAY"
                         },
                         PricingScheme = new PricingScheme()
                         {
                              FixedPrice = new Money()
                              {
                                    CurrencyCode= "USD",
                                    Value = "30"
                              }
                         },
                         Sequence = 1,
                         TenureType = "TRIAL",
                         TotalCycles = 1
                    },
                     new BillingCycle()
                    {
                         Frequency = new Frequency()
                         {
                             IntervalCount = 1,
                             IntervalUnit = "MONTH"
                         },
                         PricingScheme = new PricingScheme()
                         {
                              FixedPrice = new Money()
                              {
                                   CurrencyCode= "USD",
                                    Value = "60"
                              }
                         },
                         Sequence = 2,
                         TenureType = "REGULAR",
                         TotalCycles = 0
                    }
                };

            var plan = new PlanRequest()
            {
                ProductId = productId,
                Name = "Test Plan-" + id,
                Description = "Test Plan " + (freeTrial ? "with" : "without") + " trial period",
                Status = "ACTIVE",
                QuantitySupported = qtySupported,
                Taxes = new Taxes()
                {
                    Percentage = "8.9"
                },
                PaymentPreferences = new PaymentPreferences()
                {
                    AutoBillOutstanding = true,
                    PaymentFailureThreshold = 2,
                    SetupFee = new Money()
                    {
                        CurrencyCode = "USD",
                        Value = "0"
                    },
                    SetupFeeFailureAction = "CONTINUE"
                },
                BillingCycles = freeTrial ? cycles : new List<BillingCycle>() { cycles.Last() },
            };
            if (!freeTrial)
            {
                plan.BillingCycles[0].Sequence = 1;
            }
            return plan;
        }
        public async static Task<HttpResponse> CreatePlan(string productId, bool freeTrial, bool qtySupported)
        {
            var request = new PlansCreateRequest();
            request.Prefer("return=representation");
            request.RequestBody(buildRequestBody(productId, freeTrial, qtySupported));
            return await TestHarness.client().Execute(request);
        }       

        [Fact]
        public async void TestPlansCreateRequest()
        {
            Product product1 = await ProductsCreateTest.CreateProductIfNotExists(ProductsCreateTest.ProductId1);

            var response = await CreatePlan(product1.Id, freeTrial: true, qtySupported: true);

            Assert.Equal(201, (int)response.StatusCode);
            Assert.NotNull(response.Result<Plan>());

            Plan createdPlan = response.Result<Plan>();
            Assert.NotNull(createdPlan.Id);

            Assert.NotNull(createdPlan.CreateTime);

            Assert.NotNull(createdPlan.Links);
            bool foundApproveURL = false;
            foreach (var linkDescription in createdPlan.Links)
            {
                if ("edit".Equals(linkDescription.Rel))
                {
                    foundApproveURL = true;
                    Assert.NotNull(linkDescription.Href);
                    Assert.Equal("PATCH", linkDescription.Method);
                    Console.WriteLine(linkDescription.Href);
                }
            }

            Console.WriteLine(createdPlan.Id);
            Assert.True(foundApproveURL);
        }
    }
}
