using Sales.Backoffice.Identity;
using Sales.Backoffice.Identity.Configuration;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
        .Enrich.FromLogContext()
        .ReadFrom.Configuration(ctx.Configuration));

    var envConfig = builder.Configuration.Get<EnvironmentConfiguration>();
    if (envConfig is null)
        throw new ArgumentNullException(nameof(EnvironmentConfiguration));

    var app = builder.ConfigureServices(envConfig).ConfigurePipeline();

    if (envConfig.ApplicationLocalConfig.ShouldSeedRoles)
    {
        SeedData.SeedRoles(app);
    }

    if (envConfig.ApplicationLocalConfig.ShouldSeedUsersWithClaims)
    {
        SeedData.SeedUsers(app);
    }

    app.Run();
}
catch (Exception ex) when (ex is not HostAbortedException)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}