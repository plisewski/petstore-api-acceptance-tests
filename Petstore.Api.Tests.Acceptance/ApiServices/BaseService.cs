using Petstore.Api.Tests.Acceptance.RestClient;

namespace Petstore.Api.Tests.Acceptance.ApiServices;

public abstract class BaseService
{
    protected IRestClientManager RestClientManager { get; private set; }

    protected BaseService(IRestClientManager restClientManager) => RestClientManager = restClientManager;
}
