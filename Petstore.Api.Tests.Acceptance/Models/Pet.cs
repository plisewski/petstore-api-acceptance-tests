using Petstore.Api.Tests.Acceptance.Models.Enums;

namespace Petstore.Api.Tests.Acceptance.Models;

public class Pet
{
    public long Id { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
    public Category? Category { get; set; }
    public string? Name { get; set; }
    public List<string>? PhotoUrls { get; set; }
    public List<Tag>? Tags { get; set; }
    public PetStatus Status { get; set; }
}
