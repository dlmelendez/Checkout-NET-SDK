using System;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Collections.Generic;
using PayPalHttp;
using Xunit;
using PayPalCheckoutSdk.Test;
using static PayPalCheckoutSdk.Test.TestHarness;
using System.Threading.Tasks;

namespace PayPalCheckoutSdk.Products.Test
{
    [Collection("Products")]
    public class ProductsGetTest
    {
        [Fact]
        public async void TestProductsGetRequest()
        {
            var products = await ProductsCreateTest.CreateDefaultProductsIfNotExitsAsync();
            int pageSize = 2;
            ProductsGetRequest request = new ProductsGetRequest(page:1, pageSize: pageSize, totalRequired:true);

            var response = await TestHarness.client().Execute(request);
            Assert.Equal(200, (int) response.StatusCode);
            
            ProductCollection retrievedProductCollection = response.Result<ProductCollection>();
            Assert.NotNull(retrievedProductCollection);
            Assert.Equal(pageSize, retrievedProductCollection.Products.Count);
            Assert.True(retrievedProductCollection.TotalItems.Value > pageSize);

            Assert.NotNull(retrievedProductCollection.Links);
            

        }


        [Fact]
        public async void TestProductsGetEmptyRequest()
        {
            int pageSize = 2;
            ProductsGetRequest request = new ProductsGetRequest(page: 1, pageSize: pageSize, totalRequired: true);

            var response = await TestHarness.client().Execute(request);
            Assert.Equal(200, (int)response.StatusCode);

            ProductCollection retrievedProductCollection = response.Result<ProductCollection>();
            Assert.NotNull(retrievedProductCollection);

        }

        [Fact]
        public async Task TestProductGetDetailsRequest()
        {
            var product = await ProductsCreateTest.CreateProductIfNotExists(ProductsCreateTest.ProductId1);
            ProductGetRequest request = new ProductGetRequest(product.Id);

            var response = await TestHarness.client().Execute(request);
            Assert.Equal(200, (int)response.StatusCode);

            Product retrievedProduct = response.Result<Product>();
            Assert.NotNull(retrievedProduct);

            Assert.NotNull(retrievedProduct.Links);

        }
    }
}
