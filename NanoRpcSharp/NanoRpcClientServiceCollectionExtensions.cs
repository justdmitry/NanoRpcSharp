namespace Microsoft.Extensions.DependencyInjection
{
    using System;
    using NanoRpcSharp;

    public static class NanoRpcClientServiceCollectionExtensions
    {
        public static IHttpClientBuilder AddNanoRpcClient(
            this IServiceCollection services,
            Uri nodeEndpoint)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (nodeEndpoint == null)
            {
                throw new ArgumentNullException(nameof(nodeEndpoint));
            }

            return services.AddHttpClient<INanoRpcClient, NanoRpcClient>(c =>
            {
                c.BaseAddress = nodeEndpoint;
            });
        }
    }
}
