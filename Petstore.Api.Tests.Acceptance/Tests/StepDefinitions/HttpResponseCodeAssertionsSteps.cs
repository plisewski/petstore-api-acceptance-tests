using RestSharp;
using System.Net;

namespace Petstore.Api.Tests.Acceptance.Tests.StepDefinitions;

[Binding]
public class HttpResponseCodeAssertionsSteps
{
    private readonly ScenarioContext _scenarioContext;

    public HttpResponseCodeAssertionsSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [Then(@"Http status code should be (.*)")]
    public void ThenHttpStatusCodeShouldBe(HttpStatusCode expectedStatusCode)
    {
        _scenarioContext.Get<RestResponse>().StatusCode.Should().Be(expectedStatusCode);
    }
}
