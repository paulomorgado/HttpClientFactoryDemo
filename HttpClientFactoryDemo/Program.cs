using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

                        services.AddHttpClient("GitHubClient", client =>
                        {
                            client.BaseAddress = new Uri("https://api.github.com/");
                            client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
                            client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactoryTesting");
                        })
                        .SetHandlerLifetime(TimeSpan.FromSeconds(10));
                    })
                .RunConsoleAsync();
        }
    }
}
