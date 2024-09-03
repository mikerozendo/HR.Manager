using Microsoft.Extensions.DependencyInjection;

namespace Sales.Backoffice.Tests;

public class Helpers
{
    public ServiceProvider GetServiceProvider()
    {
        var services = new ServiceCollection();
        var serviceProvider = services
            .AddLogging()
            //.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(type.Assembly))
            .BuildServiceProvider();

        return serviceProvider;
    }
}
