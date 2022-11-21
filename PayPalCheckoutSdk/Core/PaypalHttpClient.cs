using System.Threading.Tasks;
using System.Net.Http.Headers;
using PayPalHttp;
namespace PayPalCheckoutSdk.Core
{
    public class PayPalHttpClient : HttpClient
    {
        private string refreshToken;
        private IInjector gzipInjector;
        private IInjector authorizationInjector;

        public PayPalHttpClient(PayPalEnvironment environment) : this(environment, null)
        { }

        public PayPalHttpClient(PayPalEnvironment environment, string refreshToken) : base(environment)
        {
            this.refreshToken = refreshToken;
            gzipInjector = new GzipInjector();
            authorizationInjector = new AuthorizationInjector(environment, refreshToken);

            AddInjector(gzipInjector);
            AddInjector(authorizationInjector);
        }

        protected override string GetUserAgent()
        {
            return UserAgent.GetUserAgentHeader();
        }

        class AuthorizationInjector : IInjector
        {
            private PayPalEnvironment _environment;
            private AccessToken _accessToken;
            private string _refreshToken;

            public AuthorizationInjector(PayPalEnvironment environment, string refreshToken)
            {
                _environment = environment;
                _refreshToken = refreshToken;
            }

            public void Inject(HttpRequest request)
            {
                if (!request.Headers.Contains("Authorization") && !(request is AccessTokenRequest || request is RefreshTokenRequest))
                {
                    if (_accessToken == null || _accessToken.IsExpired())
                    {
                        var accessTokenResponse = fetchAccessToken();
                        _accessToken = accessTokenResponse.Result<AccessToken>();
                    }
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken.Token);
                }
            }

            private HttpResponse fetchAccessToken()
            {
                //create a new client for access token.
                HttpClient AccessTokenClient = new HttpClient(_environment);
                AccessTokenRequest request = new AccessTokenRequest(_environment, _refreshToken);
                //make fetch access token call sync to avoid deadlock.
                Task<HttpResponse> executeTask = Task.Run<HttpResponse>(async () => await AccessTokenClient.Execute(request));
                return executeTask.Result;
            }
        }

        private class GzipInjector : IInjector
        {
            public void Inject(HttpRequest request)
            {
                request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            }
        }
    }
}
