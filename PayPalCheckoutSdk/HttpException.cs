using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using PayPalCheckoutSdk.Core;
using System.Runtime.Serialization.Json;
using System.IO;

namespace PayPalHttp
{
    public static class HttpExceptionExtensions
    {
        private static readonly DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Error), new List<Type>() { typeof(ErrorDetails) });

        public static Error? GetError(this HttpException httpEx)
        {
            if(!string.IsNullOrWhiteSpace(httpEx.Message))
            {
                using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(httpEx.Message)))
                {
                    return jsonSerializer.ReadObject(ms) as Error;
                }
            }
            return null;
        }
    }
}
