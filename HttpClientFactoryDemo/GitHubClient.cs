using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HttpClientDemo
{

    public class GitHubClient : IGitHubClient
    {
        private readonly HttpClient httpClient;

        public GitHubClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public Task<IDictionary<string, string>> GetApiUrlsAsync(CancellationToken cancellationToken)
            => this.httpClient.GetFromJsonAsync<IDictionary<string, string>>(default(string), cancellationToken);

        ~GitHubClient()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.httpClient?.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
