using BoDi;
using Petstore.Api.Tests.Acceptance.ApiServices;
using Petstore.Api.Tests.Acceptance.RestClient;

namespace Petstore.Api.Tests.Acceptance.Tests.Hooks;

[Binding]
public class InitHook
{
    private readonly IObjectContainer _container;

    public InitHook(IObjectContainer container)
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
