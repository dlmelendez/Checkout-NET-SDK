﻿// This class was generated on Tue, 04 Sep 2018 12:18:45 PDT by version 0.1.0-dev+904328-dirty of Braintree SDK Generator
// OrdersValidateRequest.cs
// @version 0.1.0-dev+904328-dirty
// @type request
// @data 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
// DO NOT EDIT
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using PayPalHttp;


namespace PayPalCheckoutSdk.Orders
{
    /// <summary>
    /// Validates a payment method and checks it for contingencies.
    /// </summary>
    public class OrdersValidateRequest : HttpRequest
    {
        public OrdersValidateRequest(string OrderId) : base("/v2/checkout/orders/{order_id}/validate-payment-method?", HttpMethod.Post, typeof(Order))
        {
            try {
                Path = Path.Replace("{order_id}", Uri.EscapeDataString(Convert.ToString(OrderId) ));
            } catch (IOException) {}
            
            ContentType =  MimeTypeConstants.ApplicationJson;
        }
        public OrdersValidateRequest PayPalClientMetadataId(string PayPalClientMetadataId) 
        {
            Headers.Add("PayPal-Client-Metadata-Id", PayPalClientMetadataId);
            return this;
        }
        
        
        public OrdersValidateRequest RequestBody(OrderActionRequest OrderActionRequest)
        {
            Body = OrderActionRequest;
            return this;
        }
    }
}
