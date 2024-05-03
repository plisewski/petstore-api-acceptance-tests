namespace Petstore.Api.Tests.Acceptance.RestClient;

using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Petstore.Api.Tests.Acceptance.Utils;
using RestSharp;
using System.Collections.Generic;

public class RestClientManager : IRestClientManager
{
    private readonly Lazy<RestClient> _client;

    public RestClientManager()
    {
        _client = new Lazy<RestClient>(() =>
        {
            var config = LoadConfiguration();
            var restClientOptions = new RestClientOptions()
            {
                BaseUrl = new Uri(config["Petstore.Api:BaseUrl"]!)
            };

            return new RestClient(restClientOptions);
        });
    }

    public async Task<RestResponse> ExecuteRequestAsync(RestRequest request) => await _client.Value.ExecuteAsync(request);

    public async Task<RestResponse> ExecuteGetRequestAsync(string resource, IDictionary<string, string>? headers)
    {
        var request = new RestRequest(resource, Method.Get)
            .AddHeaders(headers);

        return await ExecuteRequestAsync(request);
    }

    public async Task<RestResponse> ExecutePostRequestAsync<T>(string resource, T requestBody, IDictionary<string, string>? headers) where T : class
    {
        var request = new RestRequest(resource, Method.Post)
            .AddJsonBody(JsonConvert.SerializeObject(requestBody, JsonSettings.DefaultSettings))
            .AddHeaders(headers);
        return await ExecuteRequestAsync(request);
    }
    
    private static IConfiguration LoadConfiguration()
    {
        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
    }
}
