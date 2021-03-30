
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using PayPalHttp;
using System.Text;

namespace PayPalCheckoutSdk.Products
{
    /// <summary>
    /// Shows details for product, by ID.
    /// </summary>
    public class ProductGetRequest : HttpRequest
    {
        public ProductGetRequest(string productId) : base("/v1/catalogs/products/{id}", HttpMethod.Get, typeof(Product))
        {
            try 
            {                
                this.Path = this.Path.Replace("{id}", Uri.EscapeDataString(productId));
            } 
            catch (IOException) {}
            
            this.ContentType =  "application/json";
        }
        
    }
}
