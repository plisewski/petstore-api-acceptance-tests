using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Petstore.Api.Tests.Acceptance.Utils;

public static class JsonSettings
{
    public static JsonSerializerSettings DefaultSettings => new()
    {
        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        Converters = new List<JsonConverter> { new StringEnumConverter() }
    };
}
