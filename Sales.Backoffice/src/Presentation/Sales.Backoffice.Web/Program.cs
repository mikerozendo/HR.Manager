using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Refit;
using Sales.Backoffice.Web;
using Sales.Backoffice.Web.Configuration;
using Sales.Backoffice.Web.Repositories.Interfaces;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
   private static void Main(string[] args)
   {
	   var builder = WebApplication.CreateBuilder(args);


	   var configuration = builder.Configuration.Get<EnvironmentConfiguration>();

	   builder.Services.AddHttpContextAccessor();
	   builder.Services.AddControllersWithViews();
	   builder.Services.AddTransient<AuthenticationHandler>();
		
	   builder.Services
		.AddRefitClient<IWebApiClient>()
		.AddHttpMessageHandler<AuthenticationHandler>()
		.ConfigureHttpClient(c => c.BaseAddress = new Uri(configuration.WebServiceUrls.SalesBackofficeWebApi));

	   builder.Services.AddAuthentication(options =>
	   {
		   options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
		   options.DefaultChallengeScheme = "oidc";
	   })
	   .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
		   x =>
		   {
			   x.ExpireTimeSpan = TimeSpan.FromMinutes(10);
		   }
	   )
	   .AddOpenIdConnect("oidc", opt =>
	   {
		   opt.Authority = configuration.WebServiceUrls.SalesBackofficeIdentity;
		   opt.GetClaimsFromUserInfoEndpoint = true;
		   opt.ClientId = configuration.Identity.ClientId;
		   opt.ClientSecret = configuration.Identity.ClientSecret;
		   opt.ResponseType = configuration.Identity.ResponseType;
		   opt.Scope.Add(configuration.Identity.AllowedScopes);
		   opt.SaveTokens = true;
		   opt.UseTokenLifetime = true;
		   opt.RequireHttpsMetadata = false;//only for dev env
	   });

	   var app = builder.Build();

	   if (!app.Environment.IsDevelopment())
	   {
		   app.UseExceptionHandler("/Home/Error");
		   app.UseHsts();
	   }

	   app.UseHttpsRedirection();
	   app.UseMiddleware<ExceptionMiddleware>();

	   app.UseStaticFiles();

	   app.UseRouting();
	   app.UseAuthentication();
	   app.UseAuthorization();
	   app.MapControllerRoute(
		   name: "default",
		   pattern: "{controller=Home}/{action=Index}/{id?}");

	   app.Run();
   }
}