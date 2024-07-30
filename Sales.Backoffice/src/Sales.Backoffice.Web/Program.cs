using Microsoft.AspNetCore.Authentication;
using Sales.Backoffice.Web.Configuration;
using Sales.Backoffice.Web.Repositories;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var configuration = builder.Configuration.Get<EnvironmentConfiguration>();
        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped<IHealthCheckRepository, HealthCheckRepository>();

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = "Cookies";
            options.DefaultChallengeScheme = "oidc";
        })
        .AddCookie("Cookies", x => x.ExpireTimeSpan = TimeSpan.FromMinutes(5))
        .AddOpenIdConnect("oidc", opt =>
        {
            opt.Authority = configuration.WebServiceUrls.SalesBackofficeIdentity;
            opt.GetClaimsFromUserInfoEndpoint = true;
            opt.ClientId = "sales_backoffice_web";
            opt.ClientSecret = "salesBackoffice2024super_secret";
            opt.ResponseType = "code";
            opt.ClaimActions.MapJsonKey("role","role","role");
            opt.ClaimActions.MapJsonKey("sub", "sub", "sub");
            opt.Scope.Add("sales_backoffice_web");
            opt.SaveTokens = true;
            opt.TokenValidationParameters.NameClaimType = "name";
            opt.TokenValidationParameters.RoleClaimType = "role";
        });

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
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