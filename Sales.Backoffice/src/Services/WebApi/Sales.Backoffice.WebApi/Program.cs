using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.Application.Handlers.Commands;
using Sales.Backoffice.Repository;
using Sales.Backoffice.Repository.Internal;
using Sales.Backoffice.Repository.Internal.Interfaces;
using Sales.Backoffice.Repository.Seeders;
using Sales.Backoffice.WebApi.Configuration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sales.Backoffice.WebApi", Version = "v1" }));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateEmployeeRequestHandler>());

builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IAgentRepository, AgentRepository>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();


var configuration = builder.Configuration;
var envConfig = configuration.Get<EnvironmentConfiguration>()
	?? throw new ArgumentNullException("Missing configuration file");

builder.Services.AddDbContextPool<ApplicationDbContext>(opt =>
	opt.UseSqlServer(envConfig.ConnectionStrings.SqlServer, migrations =>
		migrations.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
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


builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("ApiScope", policy =>
	{
		policy.RequireAuthenticatedUser();
		policy.RequireClaim("scope", envConfig.IdentityConfig.Scope);
	});
});

if (envConfig.ShouldDbBePopulated)
	await builder.Services.SeedDatabaseAsync();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sales.Backoffice.WebApi v1"));
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers().RequireAuthorization("ApiScope");

app.Run();
