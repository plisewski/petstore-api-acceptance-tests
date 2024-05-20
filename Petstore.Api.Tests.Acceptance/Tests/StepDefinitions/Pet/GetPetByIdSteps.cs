using Petstore.Api.Tests.Acceptance.ApiServices;
using Petstore.Api.Tests.Acceptance.Utils;
using RestSharp;

namespace Petstore.Api.Tests.Acceptance.Tests.StepDefinitions.Pet;

using Petstore.Api.Tests.Acceptance.Models;
using Petstore.Api.Tests.Acceptance.Models.Enums;

[Binding]
public class GetPetByIdSteps
{
    private readonly IPetService _petService;
    private readonly ScenarioContext _scenarioContext;

    public GetPetByIdSteps(ScenarioContext scenarioContext, IPetService petService)
    {
        _scenarioContext = scenarioContext;
        _petService = petService;
    }

    [When(@"I get existing pet from the store")]
    public async Task IGetExistingPetFromTheStoreAsync()
    {
        var createdPet = _scenarioContext.Get<RestResponse>().GetResponseContentAs<Pet>();
        var petFromService = await _petService.GetPetAsync(createdPet.Id);
        _scenarioContext.Set(petFromService);
    }

    [Then(@"Existing pet is getting successfully")]
    public void ThenExistingPetIsGettingSuccessfully()
    {
        var pet = _scenarioContext.Get<RestResponse>().GetResponseContentAs<Pet>();

        pet.Should().NotBeNull();
        pet.Id.Should().BeGreaterThan(0);
        pet.Name.Should().Be("BuBu");
        pet.Status.Should().Be(PetStatus.Pending);
    }

}
