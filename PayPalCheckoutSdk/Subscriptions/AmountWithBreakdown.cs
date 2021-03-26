
using System.Runtime.Serialization;
using System.Collections.Generic;
using PayPalCheckoutSdk.Core;

namespace PayPalCheckoutSdk.Subscriptions
{
    /// <summary>
    /// The total order amount with an optional breakdown that provides details, such as the total item amount, total tax amount, shipping, handling, insurance, and discounts, if any.<br/>If you specify `amount.breakdown`, the amount equals `item_total` plus `tax_total` plus `shipping` plus `handling` plus `insurance` minus `shipping_discount` minus discount.<br/>The amount must be a positive number. For listed of supported currencies and decimal precision, see the PayPal REST APIs <a href="/docs/integration/direct/rest/currency-codes/">Currency Codes</a>.
    /// </summary>
    [DataContract]
    public class AmountWithBreakdown
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public AmountWithBreakdown() {}

        /// <summary>
        /// The amount for this transaction.
        /// </summary>
        [DataMember(Name= "gross_amount", EmitDefaultValue = false)]
        public Money GrossAmount;

        /// <summary>
        /// The item total for the transaction.
        /// </summary>
        [DataMember(Name = "total_item_amount", EmitDefaultValue = false)]
        public Money TotalItemAmount;

        /// <summary>
        /// The fee details for the transaction.
        /// </summary>
        [DataMember(Name = "fee_amount", EmitDefaultValue = false)]
        public Money FeeAmount;

        /// <summary>
        /// The shipping amount for the transaction.
        /// </summary>
        [DataMember(Name = "shipping_amount", EmitDefaultValue = false)]
        public Money ShippingAmount;

        /// <summary>
        /// The tax amount for the transaction.
        /// </summary>
        [DataMember(Name = "tax_amount", EmitDefaultValue = false)]
        public Money TaxAmount;

        /// <summary>
        /// The net amount that the payee receives for this transaction in their PayPal account. The net amount is computed as gross_amount minus the paypal_fee.
        /// </summary>
        [DataMember(Name = "net_amount", EmitDefaultValue = false)]
        public Money NetAmount;

    }
}

