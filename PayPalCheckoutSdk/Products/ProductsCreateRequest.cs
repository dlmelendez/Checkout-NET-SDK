using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using PayPalHttp;


namespace PayPalCheckoutSdk.Products
{
    /// <summary>
    /// Creates a product. 
    /// </summary>
    public class ProductsCreateRequest : HttpRequest
    {
        public ProductsCreateRequest() : base("/v1/catalogs/products", HttpMethod.Post, typeof(Product))
        {
            
            this.ContentType =  "application/json";
        }
        public ProductsCreateRequest PayPalPartnerAttributionId(string PayPalPartnerAttributionId) 
        {
            this.Headers.Add("PayPal-Partner-Attribution-Id", PayPalPartnerAttributionId);
            return this;
        }
        
        public ProductsCreateRequest Prefer(string Prefer) 
        {
            this.Headers.Add("Prefer", Prefer);
            return this;
        }
        
        
        public ProductsCreateRequest RequestBody(ProductRequest Plan)
        {
            this.Body = Plan;
            return this;
        }
    }
}
