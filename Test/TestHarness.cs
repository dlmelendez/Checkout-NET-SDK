using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PayPalCheckoutSdk.Core;
using PayPalHttp;
using Xunit;
[assembly: CollectionBehavior(MaxParallelThreads = -1)]

namespace PayPalCheckoutSdk.Test
{
    public class TestHarness
    {
        public static IServiceCollection services = new ServiceCollection();

        public static IConfigurationRoot root;

        public static string ClientId { get; private set; }

        static TestHarness()
        {
            var configuration = new ConfigurationBuilder()
               .AddUserSecrets("4dbe0d9e-0d79-4e71-b5dd-44b90dbe3ee9");

            root = configuration.Build();
            ClientId = root.GetSection("PAYPAL_CLIENT_ID") != null ? 
                root.GetSection("PAYPAL_CLIENT_ID").Value : System.Environment.GetEnvironmentVariable("PAYPAL_CLIENT_ID");
            string clientSecret = root.GetSection("PAYPAL_CLIENT_SECRET") != null ?
                root.GetSection("PAYPAL_CLIENT_SECRET").Value : System.Environment.GetEnvironmentVariable("PAYPAL_CLIENT_SECRET");

            services.AddPayPalHttpClient(ClientId, clientSecret, useSandBox: true);
        }

        public static PayPalEnvironment environment()
        {
            ClientId = root.GetSection("PAYPAL_CLIENT_ID") != null ?
                root.GetSection("PAYPAL_CLIENT_ID").Value : System.Environment.GetEnvironmentVariable("PAYPAL_CLIENT_ID");
            string clientSecret = root.GetSection("PAYPAL_CLIENT_SECRET") != null ?
                root.GetSection("PAYPAL_CLIENT_SECRET").Value : System.Environment.GetEnvironmentVariable("PAYPAL_CLIENT_SECRET");

            return new SandboxEnvironment(ClientId, clientSecret);
        }

        public static HttpClient client()
        {
            return services.BuildServiceProvider().GetService(typeof(PayPalHttpClient)) as HttpClient;
        }

        public static HttpClient client(string refreshToken)
        {
            return new PayPalHttpClient(environment(), refreshToken);
        }
    }
}
