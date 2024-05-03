using Petstore.Api.Tests.Acceptance.Models;
using Petstore.Api.Tests.Acceptance.RestClient;
using RestSharp;

namespace Petstore.Api.Tests.Acceptance.ApiServices;

public class PetService : BaseService, IPetService
{
    private const string _resourcePath = "pet";

    public PetService(IRestClientManager restClientManager) : base(restClientManager)
    {
    }

    public async Task<RestResponse> GetPetAsync(long id)
    {
        return await RestClientManager.ExecuteGetRequestAsync($"{_resourcePath}/{id}");
    }

    public async Task<RestResponse> CreatePetAsync(Pet pet)
    {
        return await RestClientManager.ExecutePostRequestAsync(_resourcePath, pet, new Dictionary<string, string>
        {
            { "Accept", "application/json" }
        });
    }
}
