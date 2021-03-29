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
    public class SubscriptionsCreateTest
    {

        private static SubscriptionRequest buildRequestBody(string planId)
        {
            //"2018-11-01T00:00:00Z"
            string startTime = DateTime.UtcNow.AddDays(1).ToString("O");
            var subscription = new SubscriptionRequest()
            {
                PlanId = planId,
                StartTime = startTime,
                Quantity = "2",
                ShippingAmount = new Money
                {
                    CurrencyCode = "USD",
                    Value = "10.00"
                },
                Subscriber = new Subscriber
                {
                    Name = new Name
                    {
                        GivenName = "John",
                        Surname = "Doe"
                    },
                    EmailAddress = "customer@example.com",
                    ShippingAddress = new ShippingDetail
                    {
                        Name = new Name
                        {
                            FullName = "John Doe"
                        },
                        Address = new AddressPortable
                        {
                            AddressLine1 = "2211 N First Street",
                            AddressLine2 = "Building 17",
                            AdminArea2 = "San Jose",
                            AdminArea1 = "CA",
                            PostalCode = "95131",
                            CountryCode = "US"
                        }
                    }
                },
                ApplicationContext = new ApplicationContext()
                {
                    BrandName = "walmart",
                    Locale = "en-US",
                    ShippingPreference = "SET_PROVIDED_ADDRESS",
                    UserAction = "SUBSCRIBE_NOW",
                    PaymentMethod = new PaymentMethod
                    {
                        PayerSelected = "PAYPAL",
                        PayeePreferred = "IMMEDIATE_PAYMENT_REQUIRED"
                    },
                    ReturnUrl = "https://example.com/returnUrl",
                    CancelUrl = "https://example.com/cancelUrl"
                }
            };
            return subscription;
        }

        public async static Task<HttpResponse> CreateSubscription(string planId)
        {
            var request = new SubscriptionsCreateRequest();
            request.Prefer("return=representation");
            request.RequestBody(buildRequestBody(planId));
            return await TestHarness.client().Execute(request);
        }       

        [Fact]
        public async void TestSubscriptionsCreateRequest()
        {
            Product product2 = await ProductsCreateTest.CreateProductIfNotExists(ProductsCreateTest.ProductId2);

            var planResponse = await PlansCreateTest.CreatePlan(product2.Id, freeTrial: true, qtySupported: true);
            Assert.Equal(201, (int)planResponse.StatusCode);
            Assert.NotNull(planResponse.Result<Plan>());
            Plan createdPlan = planResponse.Result<Plan>();

            var response = await CreateSubscription(createdPlan.Id);

            Assert.Equal(201, (int)response.StatusCode);
            Assert.NotNull(response.Result<Subscription>());

            Subscription createdSubscription = response.Result<Subscription>();
            Assert.NotNull(createdSubscription.Id);

            Assert.NotNull(createdSubscription.CreateTime);

            Assert.NotNull(createdSubscription.Links);
            bool foundApproveURL = false;
            foreach (var linkDescription in createdSubscription.Links)
            {
                if ("edit".Equals(linkDescription.Rel))
                {
                    foundApproveURL = true;
                    Assert.NotNull(linkDescription.Href);
                    Assert.Equal("PATCH", linkDescription.Method);
                    Console.WriteLine(linkDescription.Href);
                }
            }

            Console.WriteLine(createdSubscription.Id);
            Assert.True(foundApproveURL);

            // - Get Subscription
            SubscriptionsGetRequest getRequest = new SubscriptionsGetRequest(createdSubscription.Id, fields: "last_failed_payment,plan") ;
            var getResponse = await TestHarness.client().Execute(getRequest);

            Assert.Equal(200, (int)getResponse.StatusCode);
            Subscription getSubscription = getResponse.Result<Subscription>();
            Assert.NotNull(getSubscription);
            Assert.NotNull(getSubscription.Plan);
           
        }
    }
}
