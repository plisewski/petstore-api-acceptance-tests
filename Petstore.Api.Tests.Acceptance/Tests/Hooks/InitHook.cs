using BoDi;
using Microsoft.Extensions.Configuration;

namespace Petstore.Api.Tests.Acceptance.Tests.Hooks;

public class InitHook
{
    private IObjectContainer _objectContainer;

    public InitHook(IObjectContainer objectContainer)
    {
        _objectContainer = objectContainer;
    }

    [BeforeScenario]
    public void RegisterHttpClient()
    {
        var config = LoadConfiguration();
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri(config["Petstore.Api:BaseUrl"]!)
        };

        _objectContainer.RegisterInstanceAs(httpClient);
    }

    private static IConfiguration LoadConfiguration()
    {
        return new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
    }
}
