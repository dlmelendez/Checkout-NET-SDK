﻿// This class was generated on Tue, 21 May 2019 11:25:19 PDT by version 0.1.0-dev+8fcb5f of Braintree SDK Generator
// Order.cs
// @version 0.1.0-dev+8fcb5f
// @type object
// @data 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
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;
using PayPalCheckoutSdk.Core;


namespace PayPalCheckoutSdk.Orders
{
    /// <summary>
    /// The order details.
    /// </summary>
    [DataContract]
    public class Order
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Order() {}

        /// <summary>
        /// The intent to either capture payment immediately or authorize a payment for an order after order creation.
        /// </summary>
        [DataMember(Name="intent", EmitDefaultValue = false)]
        public string? CheckoutPaymentIntent { get; set; }

        /// <summary>
        /// The date and time, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6). Seconds are required while fractional seconds are optional.<blockquote><strong>Note:</strong> The regular expression provides guidance but does not reject all invalid dates.</blockquote>
        /// </summary>
        [DataMember(Name="create_time", EmitDefaultValue = false)]
        public string? CreateTime { get; set; }

        /// <summary>
        /// The date and time, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6). Seconds are required while fractional seconds are optional.<blockquote><strong>Note:</strong> The regular expression provides guidance but does not reject all invalid dates.</blockquote>
        /// </summary>
        [DataMember(Name="expiration_time", EmitDefaultValue = false)]
        public string? ExpirationTime { get; set; }

        /// <summary>
        /// The ID of the order.
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue = false)]
        public string? Id { get; set; }

        /// <summary>
        /// An array of request-related [HATEOAS links](/docs/api/reference/api-responses/#hateoas-links). To complete payer approval, use the `approve` link with the `GET` method.
        /// </summary>
        [DataMember(Name="links", EmitDefaultValue = false)]
        public List<LinkDescription>? Links { get; set; }

        /// <summary>
        /// The customer who approves and pays for the order. The customer is also known as the payer.
        /// </summary>
        [DataMember(Name="payer", EmitDefaultValue = false)]
        public Payer? Payer { get; set; }

        /// <summary>
        /// An array of purchase units. Each purchase unit establishes a contract between a customer and merchant. Each purchase unit represents either a full or partial order that the customer intends to purchase from the merchant.
        /// </summary>
        [DataMember(Name="purchase_units", EmitDefaultValue = false)]
        public List<PurchaseUnit>? PurchaseUnits { get; set; }

        /// <summary>
        /// The order status.
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue = false)]
        public string? Status { get; set; }

        /// <summary>
        /// The date and time, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6). Seconds are required while fractional seconds are optional.<blockquote><strong>Note:</strong> The regular expression provides guidance but does not reject all invalid dates.</blockquote>
        /// </summary>
        [DataMember(Name="update_time", EmitDefaultValue = false)]
        public string? UpdateTime { get; set; }
    }
}

