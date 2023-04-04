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
            
            ContentType =  MimeTypeConstants.ApplicationJson;
        }
        public ProductsCreateRequest PayPalPartnerAttributionId(string PayPalPartnerAttributionId) 
        {
            Headers.Add("PayPal-Partner-Attribution-Id", PayPalPartnerAttributionId);
            return this;
        }
        
        public ProductsCreateRequest Prefer(string Prefer) 
        {
            Headers.Add("Prefer", Prefer);
            return this;
        }
        
        
        public ProductsCreateRequest RequestBody(ProductRequest Plan)
        {
            Body = Plan;
            return this;
        }
    }
}
