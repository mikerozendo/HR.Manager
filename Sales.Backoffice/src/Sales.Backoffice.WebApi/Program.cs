using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Sales.Backoffice.Repository;
using Sales.Backoffice.Repository.Internal;
using Sales.Backoffice.Repository.Internal.Interfaces;
using Sales.Backoffice.WebApi.Configuration;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IAgentRepository, AgentRepository>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();

var envConfig = builder.Configuration.Get<EnvironmentConfiguration>();


builder.Services.AddDbContextPool<ApplicationDbContext>(
    opt => opt.UseSqlServer(envConfig.ConnectionStrings.SqlServer, 
        migrations => migrations.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
    .UseLazyLoadingProxies(false)
    .UseChangeTrackingProxies(false, false)
    .EnableThreadSafetyChecks(false)
    //UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery) //I need to read more about this 
);


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.Authority = envConfig.IdentityConfig.Url; 
        opt.Audience = "sales_backoffice_webapi";
        opt.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
    });

builder.Services.AddAuthorizationBuilder()
    .AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim(
            "scope",
            envConfig.IdentityConfig.Scope);
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers().RequireAuthorization("ApiScope");
});

app.Run();
