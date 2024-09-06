using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.Application.Handlers.Commands;
using Sales.Backoffice.Repository;
using Sales.Backoffice.Repository.Internal;
using Sales.Backoffice.Repository.Internal.Interfaces;
using Sales.Backoffice.Repository.Seeders;
using Sales.Backoffice.WebApi.Configuration;

namespace Sales.Backoffice.WebApi;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void Configureservices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateEmployeeRequestHandler>());

        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IAgentRepository, AgentRepository>();
        services.AddScoped<IDocumentRepository, DocumentRepository>();

        var envConfig = Configuration.Get<EnvironmentConfiguration>();


        services.AddDbContextPool<ApplicationDbContext>(
            opt => opt.UseSqlServer(envConfig.ConnectionStrings.SqlServer,
                migrations => migrations.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
            .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
            .UseLazyLoadingProxies(false)
            .UseChangeTrackingProxies(false, false)
            .EnableThreadSafetyChecks(false)
            //UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery) //I need to read more about this 
        );

        services.BuildServiceProvider().Seed();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(opt =>
            {
                opt.Authority = envConfig.IdentityConfig.Url;
                opt.Audience = "sales_backoffice_webapi";
                opt.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
            });

        services.AddAuthorizationBuilder()
            .AddPolicy("ApiScope", policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim(
                    "scope",
                    envConfig.IdentityConfig.Scope);
            });

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sales.Backoffice.WebApi");
            });
        }

        // app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers().RequireAuthorization("ApiScope");
        });
    }
}
