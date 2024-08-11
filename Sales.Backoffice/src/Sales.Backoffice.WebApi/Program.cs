using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.WebApi.Configuration;
using Sales.Backoffice.WebApi.Repositories;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

var envConfig = builder.Configuration.Get<EnvironmentConfiguration>();


builder.Services.AddDbContextPool<ApplicationDbContext>(
    opt => opt.UseSqlServer(envConfig.ConnectionStrings.SqlServer)
    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
    .UseLazyLoadingProxies(false)
    .UseChangeTrackingProxies(false, false)
    .EnableThreadSafetyChecks(false));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.Authority = envConfig.IdentityConfig.Url; 
        opt.Audience = "sales_backoffice_webapi";
        opt.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
    });

//builder.Services.AddAuthorizationBuilder()
//    .AddPolicy("ApiScope", policy =>
//    {
//        policy.RequireAuthenticatedUser();
//        policy.RequireClaim(
//            "scope",
//            envConfig.IdentityConfig.Scope);
//    });

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
    endpoints.MapControllers()/*.RequireAuthorization("ApiScope")*/;
});

app.Run();
