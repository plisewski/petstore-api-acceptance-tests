using System.Text.Json.Serialization;

namespace Petstore.Api.Tests.Acceptance.Models;

public class ApiResponseModel
{
    [JsonPropertyName("code")]
    public int Code { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; } = default!;

    [JsonPropertyName("message")]
    public string Message { get; set; } = default!;
}
