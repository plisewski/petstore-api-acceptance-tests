using BoDi;
using Petstore.Api.Tests.Acceptance.ApiServices;
using Petstore.Api.Tests.Acceptance.RestClient;

namespace Petstore.Api.Tests.Acceptance.Tests.Hooks;

[Binding]
public class TestInitializationHook
{
    private readonly IObjectContainer _container;

    public TestInitializationHook(IObjectContainer container)
    {
        _container = container;
    }

    [BeforeScenario]
    public void RegisterDependencies()
    {
        var restClientManager = new RestClientManager();
        _container.RegisterInstanceAs<IRestClientManager>(restClientManager);

        var petService = new PetService(restClientManager);
        _container.RegisterInstanceAs<IPetService>(petService);
    }
}
