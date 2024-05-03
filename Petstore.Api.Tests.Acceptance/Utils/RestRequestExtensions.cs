using RestSharp;

namespace Petstore.Api.Tests.Acceptance.Utils;

public static class RestRequestExtensions
{
    public static RestRequest AddHeaders(this RestRequest request, IDictionary<string, string>? headers)
    {
        if (headers is not null)
        {
            foreach (var (key, value) in headers)
            {
                request.AddHeader(key, value);
            }
        }
        return request;
    }
}
