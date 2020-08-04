using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HttpClientDemo
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> logger;

        public Worker(ILogger<Worker> logger)
        {
            this.logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                this.logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                try
                {
                    await Task.WhenAll(Enumerable.Range(0, 250).Select(_ => GetData(stoppingToken)));
                }
                catch (Exception ex)
                {
                    this.logger.LogError(ex, "Worker failed at: {time}", DateTimeOffset.Now);
                }
            }
        }

        private async Task GetData(CancellationToken stoppingToken)
        {
            using (var httpClient = GetHttpClient())
            {
                try
                {
                    var response = await httpClient.GetAsync("http://bing.com/", stoppingToken);
                    this.logger.LogDebug("{StatusCode}", response.StatusCode);
                }
                catch (Exception ex)
                {
                    this.logger.LogError("{ExceptionType}: {ExceptionMessage}", ex.GetType().Name, ex.Message);

                    if (!(ex.InnerException is null))
                    {
                        this.logger.LogError("{InnerExceptionType}: {InnerExceptionMessage}", ex.InnerException.GetType().Name, ex.InnerException.Message);
                    }
                }
            }
        }

        private readonly HttpClientHandler httpClientHandler = new HttpClientHandler();

        private HttpClient GetHttpClient()
        {
            var httpClient = new HttpClient(httpClientHandler, false);
            return httpClient;
        }
    }
}
