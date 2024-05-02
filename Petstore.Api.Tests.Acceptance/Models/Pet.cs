using Petstore.Api.Tests.Acceptance.Models.Enums;
using System.Text.Json.Serialization;

namespace Petstore.Api.Tests.Acceptance.Models;

public class Pet
{
    [JsonPropertyName("id")]
    public long Id { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

    [JsonPropertyName("category")]
    public Category Category { get; set; } = new Category();

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("photoUrls")]
    public List<string> PhotoUrls { get; set; } = new List<string>();

    [JsonPropertyName("tags")]
    public List<Tag> Tags { get; set; } = new List<Tag>();

    [JsonPropertyName("status")]
    public PetStatus Status { get; set; }
}
