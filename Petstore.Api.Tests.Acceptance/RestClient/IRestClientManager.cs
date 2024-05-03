using RestSharp;

namespace Petstore.Api.Tests.Acceptance.RestClient;

public interface IRestClientManager
{
    Task<RestResponse> ExecuteRequestAsync(RestRequest request);
    Task<RestResponse> ExecuteGetRequestAsync(string resource, IDictionary<string, string>? headers = null);
    Task<RestResponse> ExecutePostRequestAsync<T>(string resource, T requestBody, IDictionary<string, string>? headers) where T : class;
}
