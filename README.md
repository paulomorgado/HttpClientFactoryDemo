# HttpClient and HttpClient factory demo

To access the demos, checkout the respective tag.

```
git checkout tags/single-use-httpclient --force --quiet
```

The demo accesses https://bing.com/ and https://api.github.com/. Due to the high intensity of the requests, those websites might (they will!) throttle the requests.

To monitor for TIME_WAIT connections to these destinations, use the following PowerShell command:

```PowerShell
while ($true) { (Get-NetTCPConnection -RemoteAddress '13.107.21.200','204.79.197.200','140.82.118.6' -State TimeWait -ErrorAction Ignore).Count } 
```

## Single use HttpClient

*tag: single-use-httpclient*

This demo uses a new instance of `HttpClient` each time it's used.

## Single use HttpClient with connection close

*tag: single-use-httpclient-connection-close*

This demo uses a new instance of `HttpClient` each time it's used with `ConnectionClose` set to `true`.

## Singleton HttpClient

*tag: single-use-httpclient-connection-close*

This demo uses a singleton instance of `HttpClient` for every use.

## Single use HttpClient with singleton HttpClientHandler

*tag: single-use-httpclient-singleton-httpclienthandler*

This demo uses a singleton instance of `HttpClientHandler` in instances of `HttpClient` for one-time use.

## Use HttpClient factory

*tag: httpclientfactory*

This demo uses the implmentation of `IHttpHandlerFactory` to create instances of `HttpClient` for one-time use.

## Use HttpClient factory with named clients

*tag: httpclientfactory-named-httpclient*

This demo uses the implmentation of `IHttpHandlerFactory` to create instances of `HttpClient` for one-time use using named definitions.

## Use HttpClient factory with typed clients

*tag: httpclientfactory-typed-client*

This demo uses the implmentation of `IHttpHandlerFactory` to create instances of `HttpClient` for one-time use using typed clients.

## Use HttpClient factory with custom primary handler

*tag: httpclientfactory-socketshttphandler*

This demo uses the implmentation of `IHttpHandlerFactory` to create instances of `HttpClient` for one-time use using a custom primary handler (`SocketsHttpHandler`).

## Use HttpClient factory with policies

*tag: httpclientfactory-polly*

This demo uses the implmentation of `IHttpHandlerFactory` to create instances of `HttpClient` for one-time use using policies provided by [Polly](https://github.com/App-vNext/Polly).

# Resources

* TIME\_WAIT
  * [Troubleshoot port exhaustion issues](https://docs.microsoft.com/windows/client-management/troubleshoot-tcpip-port-exhaust)
  * [TCP TIME\_WAIT and TIME\_WAIT assassination](https://docs.microsoft.com/azure/virtual-network/virtual-network-tcpip-performance-tuning)
* `HttpClient` class
  * [Documentation](https://docs.microsoft.com/dotnet/api/system.net.http.httpclient)
  * [Browse source code](https://source.dot.net/)
* `SocketsHttpHandler` Class
  * [Documentation](https://docs.microsoft.com/dotnet/api/system.net.http.socketshttphandler)
  * [Browse source code](https://source.dot.net/)
* [Make HTTP requests using](https://docs.microsoft.com/aspnet/core/fundamentals/http-requests)[`IHttpClientFactory`](https://docs.microsoft.com/aspnet/core/fundamentals/http-requests)[in ASP.NET Core](https://docs.microsoft.com/aspnet/core/fundamentals/http-requests)
* [Use IHttpClientFactory to implement resilient HTTP requests](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests)
* IHttpClientFactoryinterface
  * [Documentation](https://docs.microsoft.com/dotnet/api/system.net.http.ihttpclientfactory)
  * [Browse source code](https://source.dot.net/)
* `HttpClientBuilderExtensions` Class
  * [Documentation](https://docs.microsoft.com/dotnet/api/microsoft.extensions.dependencyinjection.httpclientbuilderextensions)
  * [Browse source code](https://source.dot.net/)
* [Steve Gordon's blog posts on `HttpClient`](https://www.stevejgordon.co.uk/tag/httpclient) [[GitHub](https://github.com/stevejgordon)] [[Twitter](https://twitter.com/stevejgordon)]
  * [`HttpClient` Creation And Disposal Internals: Should I Dispose Of `HttpClient` ?](https://www.stevejgordon.co.uk/httpclient-creation-and-disposal-internals-should-i-dispose-of-httpclient)
  * [Demystifying `HttpClient` Internals: SendAsync Flow For `HttpRequestMessage`](https://www.stevejgordon.co.uk/demystifying-httpclient-internals-sendasync-flow-for-httprequestmessage)
  * [Demystifying `HttpClient` Internals: `HttpResponseMessage`](https://www.stevejgordon.co.uk/demystifying-httpclient-internals-httpresponsemessage)
  * [`HttpClient` Connection Pooling in .NET Core](https://www.stevejgordon.co.uk/httpclient-connection-pooling-in-dotnet-core)
  * [Using `HttpCompletionOption` To Improve `HttpClient` Performance In .NET](https://www.stevejgordon.co.uk/using-httpcompletionoption-responseheadersread-to-improve-httpclient-performance-dotnet)
  * [Sending And Receiving JSON Using `HttpClient` With `System.Net.Http.Json`](https://www.stevejgordon.co.uk/sending-and-receiving-json-using-httpclient-with-system-net-http-json)
* [Steve Gordon's blog posts on `IHttpClientFactory`](https://www.stevejgordon.co.uk/tag/httpclientfactory) [[GitHub](https://github.com/stevejgordon)] [[Twitter](https://twitter.com/stevejgordon)]
  * [HttpClientFactory in ASP.NET Core 2.1 (Part 1): An Introduction To HttpClientFactory](https://www.stevejgordon.co.uk/introduction-to-httpclientfactory-aspnetcore)
  * [HttpClientFactory In ASP.NET Core 2.1 (Part 2): Defining Named And Typed Clients](https://www.stevejgordon.co.uk/httpclientfactory-named-typed-clients-aspnetcore)
  * [HttpClientFactory In ASP.NET Core 2.1 (Part 3): Outgoing Request Middleware With Handlers](https://www.stevejgordon.co.uk/httpclientfactory-aspnetcore-outgoing-request-middleware-pipeline-delegatinghandlers)
  * [HttpClientFactory In ASP.NET Core 2.1 (Part 4): Integrating With Polly For Transient Fault Handling](https://www.stevejgordon.co.uk/httpclientfactory-using-polly-for-transient-fault-handling)
  * [`IHttpClientFactory` Patterns: Using Typed Clients From Singleton Services](https://www.stevejgordon.co.uk/ihttpclientfactory-patterns-using-typed-clients-from-singleton-services)
  * [HttpClientFactory In ASP.NET Core 2.1 (Part 5): Logging](https://www.stevejgordon.co.uk/httpclientfactory-asp-net-core-logging)
* [Andrew Lock's blog posts on `IHttpClientFactory`](https://andrewlock.net/tag/httpclient/) [[GitHub](https://github.com/andrewlock)] [[Twitter](https://twitter.com/andrewlocknet)]
  * [Exploring the code behind `IHttpClientFactory` in depth](https://andrewlock.net/exporing-the-code-behind-ihttpclientfactory/)
  * [DI scopes in `IHttpClientFactory` message handlers don't work like you think they do](https://andrewlock.net/understanding-scopes-with-ihttpclientfactory-message-handlers/)
* Damen Bod’s blog posts on `HttpClient`/`IHttpClientFactory` [[GitHub](https://github.com/damienbod)] [[Twitter](https://twitter.com/damien_bod)]
  * [Using Certificate Authentication With `IHttpClientFactory` and `HttpClient`](https://damienbod.com/2019/09/07/using-certificate-authentication-with-ihttpclientfactory-and-httpclient/)
* João Grassi [[GitHub](https://github.com/joaopgrassi)] [[Twitter](https://twitter.com/jotagrassi)]
  * [Encapsulating getting access tokens from IdentityServer with a typed `HttpClient` and MessageHandler](https://blog.joaograssi.com/typed-httpclient-with-messagehandler-getting-accesstokens-from-identityserver/)
