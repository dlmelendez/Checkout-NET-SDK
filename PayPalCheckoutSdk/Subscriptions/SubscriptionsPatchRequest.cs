// This class was generated on Tue, 04 Sep 2018 12:18:45 PDT by version 0.1.0-dev+904328-dirty of Braintree SDK Generator
// OrdersPatchRequest.cs
// @version 0.1.0-dev+904328-dirty
// @type request
// @data H4sIAAAAAAAC/9RXTW/jNhC991cQcxasYFv0YKAHw0mRfuzaTdwFisSwJ+I44q6kYclhtkaQ/15QlJLINnY3bYI2N/txyHlPMxo93sI7rAnGwE6T8yOLUpSQwTH5whkrhhsYw+9Wo5BX2Kg2TkmJokr0SkpS6+nZyWRxcrxW7NR6Mp+fzd7Hf15Qgh+pPzioApuGRYX2oIdzPhkp1Xo6ezv/9WRxYI9q+cQsnhSKOHMVEhGt+OoDFeLHl+Ho6NtC8Kqi9id1QEmoB4AbLiuszHXzwyVUtJFLSIuTPkfUkjKk+FzKr9g+s+QwPjR/cFc+5JDvc7xivf0M6UFwwbpTbBqhpif6APdZhin0QeZnZCssDm/Zof11nGxwRYmeVqEx4p+DW6ZQ65cieLEcFcEL1yujn41sphzVfEMvSFo/vKivibbFLdGIajTVa2gNXxprTXP9mh6x542s+vZg95qoY83h/z3PLpYj09ywKei/mhf53rcif/QNhAx+C+S2c3RYk5DzML5YZnBKqMntoj+yq3exOUo5wG5hsbXRKnhxprmGDN6jMzHlYwuxMhoy+IW2HbjnJRYlqZ+OFW9a79DZCe6cwQgymDiH25TqKIMzQj1rqi2MN1h5isCfwTjSMBYXKIO5Y0tODHkYN6Gq7pYphrykQ+55zztvs0O7tRgrl7YMuO+uDIVMGoWRapTy8/nsXedVOlsSNaG11VZZdGKw6hS2C448B1eQ39H7/Wf1dsBjwV8uysZxPRDVAftFSRo4eom2IrE8gu6aRGkuQk2NqIqL1t6oeIr6VJpozljFnm3jb7AKNFI9Z7VhlyxijFgr7u3Rk+p8QHdb6OzLHWkH0tu/+8LvWUUpBde2oid24j9naFHK3Z4r/315UB6K0ytK79sLVSB1/b6+tiEGAntkX2G7cv/ejFTE1mkgPmodpZm8ipcJl/gp7NruORQt72KUt9x4SudEOIMptxa7UxsJmvSo8w+eG8jgVMS+JSlZx0kzWUxPIc1QGEN+8yYvSio+cpA8XbTy235a3kEG5x+Nved08pelQkift1ehKWuC8Zuj7+6++RsAAP//
// DO NOT EDIT
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using PayPalHttp;
using PayPalCheckoutSdk.Core;

namespace PayPalCheckoutSdk.Subscriptions
{
    /// <summary>
    /// Updates a subscription which could be in ACTIVE or SUSPENDED status. You can override plan level default attributes by providing customised values for plan path in the patch request.
    /// You cannot update attributes that have already completed(Example - trial cycles can’t be updated if completed).
    /// Once overridden, changes to plan resource will not impact subscription.
    /// Any price update will not impact billing cycles within next 10 days(Applicable only for subscriptions funded by PayPal account).
    /// https://developer.paypal.com/docs/api/subscriptions/v1/#subscriptions_patch
    /// </summary>
    public class SubscriptionsPatchRequest<T> : HttpRequest
    {
        public SubscriptionsPatchRequest(string subscriptionId) : base("/v1/billing/subscriptions/{id}?", new HttpMethod("PATCH"), typeof(void))
        {
            try {
                Path = Path.Replace("{id}", Uri.EscapeDataString(subscriptionId));
            } catch (IOException) {}
            
            ContentType =  MimeTypeConstants.ApplicationJson;
        }
        
        public SubscriptionsPatchRequest<T> RequestBody(List<Patch<T>> PatchRequest)
        {
            Body = PatchRequest;
            return this;
        }
    }
}
