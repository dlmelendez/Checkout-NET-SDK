using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayPalCheckoutSdk.Core
{
    public enum JsonSerializerType
    {
        /// <summary>
        /// Default System.Runtime.Serialization with DataContracts
        /// </summary>
        DefaultDataContract = 0,
        /// <summary>
        /// System.Text.Json polymophic serialization
        /// </summary>
        SystemJsonText = 1,
#if NET7_0_OR_GREATER
        /// <summary>
        /// Experimental!, System.Text.Json with code generated context
        /// </summary>
        SystemJsonTextWithDataContext = 2
#endif
    }
}
