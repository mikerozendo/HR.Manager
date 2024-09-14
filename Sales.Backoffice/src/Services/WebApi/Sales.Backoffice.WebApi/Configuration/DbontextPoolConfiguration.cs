using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.Repository;

namespace Sales.Backoffice.WebApi.Configuration;

public static class DbontextPoolConfiguration
{
	public static IServiceCollection AddDbContextPoolConfig(this IServiceCollection serviceCollection, EnvironmentConfiguration envConfig)
	{
		serviceCollection.AddDbContextPool<ApplicationDbContext>(opt =>
			opt.UseSqlServer(
			envConfig.ConnectionStrings.SqlServer, migrations =>
			migrations.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
		)
		.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
		.UseLazyLoadingProxies(false)
		.UseChangeTrackingProxies(false, false)
		.EnableThreadSafetyChecks(false)
		//UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery) //I need to read more about this 
		);
		
		return serviceCollection;
	}
}