using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Sales.Backoffice.Repository.Seeders;

public static class DatabaseSeeder
{
	public static async Task SeedDatabaseAsync(this IServiceCollection serviceCollection)
	{
		using var serviceProvider = serviceCollection.BuildServiceProvider();
		var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
		context.Database.Migrate();

		await DepartmentSeeder.SeedAsync(serviceProvider);
		await EmployeeSeeder.SeedAsync(serviceProvider);
		
		
	}
}
