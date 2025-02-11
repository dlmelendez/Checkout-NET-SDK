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
#pragma warning disable CA2211 // Non-constant fields should not be visible, Test class, not relevant
        public static IServiceCollection services = new ServiceCollection();

        public static IConfigurationRoot root;
#pragma warning restore CA2211 // Non-constant fields should not be visible

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
#if NET9_0_OR_GREATER
            services.AddPayPalHttpClient(ClientId, clientSecret, useSandBox: true, JsonSerializerType.SystemJsonTextWithDataContext);
#else
            services.AddPayPalHttpClient(ClientId, clientSecret, useSandBox: true, JsonSerializerType.SystemJsonText);
#endif
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
