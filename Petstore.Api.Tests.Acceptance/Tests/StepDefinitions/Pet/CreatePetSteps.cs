namespace Petstore.Api.Tests.Acceptance.Tests.StepDefinitions.Pet;

using TechTalk.SpecFlow.Assist;
using Petstore.Api.Tests.Acceptance.Models;

[Binding]
public class CreatePetSteps
{
    private readonly HttpClient _httpClient;

    public CreatePetSteps()
    {
        
    }

    [When(@"I create a pet with the following details")]
    public void WhenICreateAPetWithTheFollowingDetails(Table table)
    {
        var pet = table.CreateInstance<Pet>();
    }

    [Then(@"I can see new pet is created successfully")]
    public void ThenICanSeeNewPetIsCreatedSuccessfully()
    {
        throw new PendingStepException();
    }

    [Then(@"Http status code should be")]
    public void ThenHttpStatusCodeShouldBe()
    {
        throw new PendingStepException();
    }

}
