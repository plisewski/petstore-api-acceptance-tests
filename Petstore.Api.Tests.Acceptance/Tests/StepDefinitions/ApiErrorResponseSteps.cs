using Petstore.Api.Tests.Acceptance.Models;
using Petstore.Api.Tests.Acceptance.Utils;
using RestSharp;

namespace Petstore.Api.Tests.Acceptance.Tests.StepDefinitions;

[Binding]
public class ApiErrorResponseSteps
{
    private readonly ScenarioContext _scenarioContext;

    public ApiErrorResponseSteps(ScenarioContext scenarioContext) => _scenarioContext = scenarioContext;

    [Then(@"The response body contains message: (.*)")]
    public void ResponseBodyContainsMessage(string errorMessage)
    {
        var errorApiResponse = _scenarioContext.Get<RestResponse>().GetResponseContentAs<ApiResponseModel>();
        errorApiResponse.Should().NotBeNull();
        errorApiResponse.Message.Should().Be(errorMessage);
    }
}
