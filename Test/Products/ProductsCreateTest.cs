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


namespace PayPalCheckoutSdk.Products.Test
{
    [Collection("Products")]
    public class ProductsCreateTest
    {
        private static ProductRequest buildRequestBody()
        {
            string id = Guid.NewGuid().ToString();
            var product = new ProductRequest()
            {
                Category = "COMPUTER_AND_DATA_PROCESSING_SERVICES",
                Type = "SERVICE",
                Description = "Offering 1",
                Id = id,
                Name = "Offering " + id,
                ImageUrl = "https://i5.walmartimages.com/asr/2be09608-5a66-4344-b7ec-d45b4811cccf.978952928c95e91ad7de02bee365dd7d.jpeg?odnWidth=612&odnHeight=612&odnBg=ffffff",
                HomeUrl = "http://www.example.com"
            };
            return product;
        }
        public async static Task<HttpResponse> CreateProduct() 
        {
            var request = new ProductsCreateRequest();
            request.Prefer("return=representation");
            request.RequestBody(buildRequestBody());
            return await TestHarness.client().Execute(request);
        }

        [Fact]
        public async void TestProductsCreateRequest()
        {
            var response = await CreateProduct();

            Assert.Equal(201, (int) response.StatusCode);
            Assert.NotNull(response.Result<Product>());

            Product createdProduct = response.Result<Product>();
            Assert.NotNull(createdProduct.Id);

            Assert.NotNull(createdProduct.CreateTime);

            Assert.NotNull(createdProduct.Links);
            bool foundApproveURL = false;
            foreach (var linkDescription in createdProduct.Links) 
            {
                if ("edit".Equals(linkDescription.Rel)) 
                {
                    foundApproveURL = true;
                    Assert.NotNull(linkDescription.Href);
                    Assert.Equal("PATCH", linkDescription.Method);
                    Console.WriteLine(linkDescription.Href);
                }
            }

            Console.WriteLine(createdProduct.Id);
            Assert.True(foundApproveURL);
        }
    }
}
