using System.Threading.Tasks;
using System.Net.Http.Headers;
using PayPalHttp;
namespace PayPalCheckoutSdk.Core
{
    public class PayPalHttpClient : HttpClient
    {
        private readonly IInjector _gzipInjector;
        private readonly IInjector _authorizationInjector;

        public PayPalHttpClient(PayPalEnvironment environment) : this(environment, null)
        { }

        public PayPalHttpClient(PayPalEnvironment environment, string? refreshToken) : base(environment)
        {
            _gzipInjector = new GzipInjector();
            _authorizationInjector = new AuthorizationInjector(environment, refreshToken);

            AddInjector(_gzipInjector);
            AddInjector(_authorizationInjector);
        }

        protected override string GetUserAgent()
        {
            return UserAgent.GetUserAgentHeader();
        }

        class AuthorizationInjector : IInjector
        {
            private readonly PayPalEnvironment _environment;
            private AccessToken? _accessToken;
            private readonly string? _refreshToken;

            public AuthorizationInjector(PayPalEnvironment environment, string? refreshToken)
            {
                _environment = environment;
                _refreshToken = refreshToken;
            }

            public async Task<T> InjectAsync<T>(T request) where T : HttpRequest
            {
                if (!request.Headers.Contains("Authorization") && !(request is AccessTokenRequest || request is RefreshTokenRequest))
                {
                    if (_accessToken == null || _accessToken.IsExpired())
                    {
                        _accessToken = await FetchAccessTokenAsync().ConfigureAwait(false);
                    }
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken.Token);
                }
                return request;
            }

            private async Task<AccessToken> FetchAccessTokenAsync()
            {
                //create a new client for access token.
                HttpClient AccessTokenClient = new HttpClient(_environment);
                AccessTokenRequest request = new AccessTokenRequest(_environment, _refreshToken);
                //make fetch access token call sync to avoid deadlock.
                var accessTokenResponse = await AccessTokenClient.Execute(request).ConfigureAwait(false);
                return accessTokenResponse.Result<AccessToken>();
            }

        }

        private class GzipInjector : IInjector
        {
            public Task<T> InjectAsync<T>(T request) where T : HttpRequest
            {
                request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
                return Task.FromResult(request);
            }
        }
    }
}
