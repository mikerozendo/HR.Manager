using Microsoft.AspNetCore.Authentication.JwtBearer;
using Sales.Backoffice.WebApi.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var envConfig = builder.Configuration.Get<EnvironmentConfiguration>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {
        opt.Authority = envConfig.IdentityConfig.Url;
        opt.Audience = "sales_backoffice_webapi"; // ID da API que o token deve ter como público

        opt.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
        //opt.TokenValidationParameters = new TokenValidationParameters
        //{
        //    ValidateAudience = false,

        //};
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

//app.MapControllers().RequireAuthorization("ApiScope");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers().RequireAuthorization("ApiScope");
});
app.Run();
