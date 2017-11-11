using Xunit;

namespace AspNetCore20Example.Services.API.Integration.Tests.Configuration
{
    [CollectionDefinition("Base collection")]
    public abstract class BaseTestCollection : ICollectionFixture<BaseTestFixture>
    {
    }
}