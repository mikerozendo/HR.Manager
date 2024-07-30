using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.Identity.Configuration;
using Sales.Backoffice.Identity.Data;
using Sales.Backoffice.Identity.Models;
using Serilog;

namespace Sales.Backoffice.Identity;

internal static class WebApplicationExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder, EnvironmentConfiguration envConfig)
    {
        builder.Services.AddRazorPages();

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(envConfig.ConnectionStrings.SqlServer)
        );

        builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        builder.Services
            .AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;

                // see https://docs.duendesoftware.com/identityserver/v6/fundamentals/resources/
                options.EmitStaticAudienceClaim = true;
            })
            .AddInMemoryIdentityResources(IdentityConfiguration.IdentityResources)
            .AddInMemoryApiScopes(IdentityConfiguration.GetApiScopes())
            .AddInMemoryClients(builder.GetClients(envConfig))
            .AddAspNetIdentity<ApplicationUser>();

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseSerilogRequestLogging();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseIdentityServer();
        app.UseAuthorization();

        app.MapRazorPages()
            .RequireAuthorization();

        return app;
    }
}