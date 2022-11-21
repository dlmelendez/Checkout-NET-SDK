using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using PayPalHttp;

namespace PayPalCheckoutSdk.Core
{
    public class RefreshTokenRequest: HttpRequest
    {
        public RefreshTokenRequest(PayPalEnvironment environment, string code): base("/v1/identity/openidconnect/tokenservice", HttpMethod.Post, typeof(RefreshToken))
        {
            Headers.Authorization = new AuthenticationHeaderValue("Basic", environment.AuthorizationString());
            Body = new Dictionary<string, string>()
            {
                {"grant_type", "authorization_code"},
                {"code", code},
            };
            ContentType = "application/x-www-form-urlencoded";
        }
    }
}
