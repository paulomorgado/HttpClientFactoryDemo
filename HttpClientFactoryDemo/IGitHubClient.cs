using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientDemo
{
    public interface IGitHubClient : IDisposable
    {
        Task<IDictionary<string, string>> GetApiUrlsAsync(CancellationToken cancellationToken);
    }
}