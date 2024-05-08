namespace Petstore.Api.Tests.Acceptance.Tests.StepDefinitions.Pet;

using Petstore.Api.Tests.Acceptance.ApiServices;
using Petstore.Api.Tests.Acceptance.Models;
using Petstore.Api.Tests.Acceptance.Utils;
using RestSharp;
using TechTalk.SpecFlow.Assist;

[Binding]
public class CreatePetSteps
{
    private readonly IPetService _petService;
    private readonly ScenarioContext _scenarioContext;

    public CreatePetSteps(ScenarioContext scenarioContext, IPetService petService)
    {
        _scenarioContext = scenarioContext;
        _petService = petService;
    }

    [When(@"I create a pet with the following details")]
    public async Task ICreateAPetWithTheFollowingDetailsAsync(Table table)
    {
        var pet = table.CreateInstance<Pet>();
        var response = await _petService.CreatePetAsync(pet);
        _scenarioContext.Set(response);
    }

    [Then(@"I can see new pet is created successfully")]
    public async Task ThenICanSeeNewPetIsCreatedSuccessfully()
    {
        var createdPet = _scenarioContext.Get<RestResponse>().GetResponseContentAs<Pet>();
        var petFromService = await _petService.GetPetAsync(createdPet.Id);
        createdPet
            .Should()
            .BeEquivalentTo(petFromService.GetResponseContentAs<Pet>(), opt => opt.WithStrictOrdering());
    }
}
