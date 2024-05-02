using Petstore.Api.Tests.Acceptance.Models;
using RestSharp;

namespace Petstore.Api.Tests.Acceptance.ApiServices;

public interface IPetService
{
    Task<RestResponse> CreatePetAsync(Pet pet);
}
