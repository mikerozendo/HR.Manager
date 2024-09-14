using Sales.Backoffice.Repository.Internal;
using Sales.Backoffice.Repository.Internal.Interfaces;

namespace Sales.Backoffice.WebApi.Configuration;

public static class RepositoriesConfiguration
{
	public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
	{
		serviceCollection.AddScoped<IDepartmentRepository, DepartmentRepository>();
		serviceCollection.AddScoped<IEmployeeRepository, EmployeeRepository>();
		serviceCollection.AddScoped<IAgentRepository, AgentRepository>();
		serviceCollection.AddScoped<IDocumentRepository, DocumentRepository>();
		return serviceCollection;
	}
}
