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
                    })
                .RunConsoleAsync();
        }
    }
}
