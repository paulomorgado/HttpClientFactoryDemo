using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using Polly.Caching;
using Polly.Caching.Memory;

namespace HttpClientDemo
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                    {
                        services.AddHostedService<Worker>();

                        services.AddMemoryCache();
                        services.AddSingleton<IAsyncCacheProvider, MemoryCacheProvider>();

                        services.AddHttpClient("GitHubClient", client =>
                        {
                            client.BaseAddress = new Uri("https://api.github.com/");
                            client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
                            client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactoryTesting");
                        })
                        .ConfigurePrimaryHttpMessageHandler(() => new SocketsHttpHandler { PooledConnectionLifetime = TimeSpan.FromMinutes(10) })
                        .AddTransientHttpErrorPolicy(p => p.RetryAsync(3))
                        .AddPolicyHandler((serviceProvider, httpResponseMessage) =>
                            Policy.CacheAsync<HttpResponseMessage>(
                                serviceProvider.GetRequiredService<IAsyncCacheProvider>(),
                                TimeSpan.FromSeconds(10),
                                context => httpResponseMessage.RequestUri.AbsoluteUri))
                        .AddTypedClient<IGitHubClient, GitHubClient>();
                    })
                .RunConsoleAsync();
        }
    }
}
