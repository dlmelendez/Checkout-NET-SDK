
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
    /// Shows details for a product, by ID.
    /// </summary>
    public class ProductsGetRequest : HttpRequest
    {
        public ProductsGetRequest(
            int pageSize = 20,
            int page = 1,
            bool totalRequired = true) : base("/v1/catalogs/products?{queryParms}", HttpMethod.Get, typeof(ProductCollection))
        {
            try 
            {
                StringBuilder queryParms = new StringBuilder();
                queryParms.Append("page_size=");
                queryParms.Append(pageSize);
                queryParms.Append("&");

                queryParms.Append("page=");
                queryParms.Append(page);
                queryParms.Append("&");

                queryParms.Append("total_required=");
                queryParms.Append(totalRequired);

                Path = Path.Replace("{queryParms}", queryParms.ToString());
            } 
            catch (IOException) {}
            
            ContentType =  "application/json";
        }
        
    }
}
