
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using PayPalHttp;
using PayPalCheckoutSdk.Core;

namespace PayPalCheckoutSdk.Products
{
    /// <summary>
    /// Updates a product, by ID. You can patch these attributes and objects:
    /// https://developer.paypal.com/docs/api/catalog-products/v1/#products_patch 
    /// </summary>
    public class ProductsPatchRequest<T> : HttpRequest
    {
        public ProductsPatchRequest(string productId) : base("/v1/catalogs/products/{id}", new HttpMethod("PATCH"), typeof(void))
        {
            try {
                this.Path = this.Path.Replace("{id}", Uri.EscapeDataString(productId));
            } catch (IOException) {}
            
            this.ContentType =  "application/json";
        }
        
        public ProductsPatchRequest<T> RequestBody(List<Patch<T>> patchRequest)
        {
            this.Body = patchRequest;
            return this;
        }
    }
}
