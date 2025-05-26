using JapanPostAPISharp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace JapanPostAPISharp.Extensions
{
    public static class JapanPostApiServiceCollectionExtensions
    {
        public static IServiceCollection AddJapanPostApiClient(this IServiceCollection services, Action<JapanPostApiOptions> configureOptions)
        {
            services.Configure(configureOptions);
            services.AddHttpClient(); // HttpClientFactoryを登録

            services.AddSingleton<IJapanPostApiClient>(provider =>
            {
                var options = provider.GetRequiredService<IOptions<JapanPostApiOptions>>().Value;
                var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
                var httpClient = httpClientFactory.CreateClient();

                return new JapanPostApiClient(options.ClientId, options.ClientSecret, options.BaseUrl, httpClient);
            });

            return services;
        }
    }
}
