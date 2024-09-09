using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Sales.Backoffice.Repository.Seeders;

public static class DatabaseSeeder
{
	public static void SeedDatabase(this IServiceCollection serviceCollection)
	{
		using var serviceProvider = serviceCollection.BuildServiceProvider();
		var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
		context.Database.Migrate();

		DepartmentSeeder.Seed(serviceProvider);
		EmployeeSeeder.Seed(serviceProvider);
	}
}
