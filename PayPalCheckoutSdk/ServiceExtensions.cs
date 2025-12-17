using PayPalCheckoutSdk.Core;
using System;
using System.Collections.Generic;
using System.Text;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace Microsoft.Extensions.DependencyInjection
#pragma warning restore IDE0130 // Namespace does not match folder structure
{
    /// <summary>
    /// Used for startup service dependency injection
    /// </summary>
    public static class ServiceExtensions
    {
        public static IServiceCollection AddPayPalHttpClient(this IServiceCollection services, 
            string clientId,
            string clientSecret,
            bool useSandBox = false,
            JsonSerializerType? jsonSerializerType = JsonSerializerType.DefaultDataContract)
        {
            services.AddSingleton<PayPalHttpClient>(useSandBox ? new PayPalHttpClient(new SandboxEnvironment(clientId, clientSecret), jsonSerializerType) :
                new PayPalHttpClient(new LiveEnvironment(clientId, clientSecret), jsonSerializerType));
            return services;
        }
    }
}
