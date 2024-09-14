using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Sales.Backoffice.WebApi.Configuration;

public static class IdentityConfiguration
{
	public static IServiceCollection AddIdentityConfig(this IServiceCollection serviceCollection, EnvironmentConfiguration envConfig)
	{
		serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
		.AddJwtBearer(opt =>
		{
			opt.Authority = envConfig.IdentityConfig.Url;
			opt.Audience = "sales_backoffice_webapi";
			opt.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
		});

		serviceCollection.AddAuthorization(options =>
		{
			options.AddPolicy("ApiScope", policy =>
			{
				policy.RequireAuthenticatedUser();
				policy.RequireClaim("scope", envConfig.IdentityConfig.Scope);
			});
		});
		
		return serviceCollection;
	}
}