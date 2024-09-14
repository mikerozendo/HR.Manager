using Sales.Backoffice.Application.Handlers.Commands;
using Sales.Backoffice.Repository.Seeders;
using Sales.Backoffice.WebApi.Configuration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var envConfig = configuration.Get<EnvironmentConfiguration>()
    ?? throw new ArgumentNullException("Missing configuration file");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sales.Backoffice.WebApi", Version = "v1" })
);

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<CreateEmployeeRequestHandler>()
);

builder.Services
.AddDbContextPoolConfig(envConfig)
.AddRepositories()
.AddIdentityConfig(envConfig);

if (envConfig.ShouldDbBePopulated)
    await builder.Services.SeedDatabaseAsync();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sales.Backoffice.WebApi v1"));


app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers().RequireAuthorization("ApiScope");

app.Run();
