using Newtonsoft.Json;
using RestSharp;

namespace Petstore.Api.Tests.Acceptance.Utils;

public static class RestResponseExtensions
{
    public static T GetResponseContentAs<T>(this RestResponse response)
    {
        if (response is null)
        {
            throw new ArgumentNullException(nameof(response), "The response is null");
        }

        if (string.IsNullOrWhiteSpace(response.Content))
        {
            throw new ArgumentException("Response content is empty or null", nameof(response));
        }

        try
        {
            return JsonConvert.DeserializeObject<T>(response.Content)!;
        }
        catch (Exception ex)
        {

            throw new InvalidOperationException("Deserialization error: Failed to convert response content.", ex);
        }
    }
}
