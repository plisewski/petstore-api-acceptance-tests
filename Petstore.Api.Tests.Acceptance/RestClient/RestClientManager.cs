namespace Petstore.Api.Tests.Acceptance.RestClient;

using Microsoft.Extensions.Configuration;
using RestSharp;

public class RestClientManager
{
    private Lazy<RestClient> _client;

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

    public async Task<RestResponse> ExecuteRequest(RestRequest request) => await _client.Value.ExecuteAsync(request);

    private static IConfiguration LoadConfiguration()
    {
        return new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
    }
}
