using RestSharp;

namespace Petstore.Api.Tests.Acceptance.RestClient;

public interface IRestClientManager
{
    Task<RestResponse> ExecuteRequest(RestRequest request);
}
