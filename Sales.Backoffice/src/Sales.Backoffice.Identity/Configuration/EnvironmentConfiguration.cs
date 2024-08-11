namespace Sales.Backoffice.Identity.Configuration;

public record EnvironmentConfiguration
{
    public Serilog Serilog { get; init; }
    public Clients Clients { get; init; }
    public Connectionstrings ConnectionStrings { get; init; }
    public Applicationlocalconfig ApplicationLocalConfig { get; init; }
    public Scopes Scopes { get; init; }
}

public record Scopes
{
    public string SalesBackofficeWebApi { get; init; }
}

public record Serilog
{
    public Minimumlevel MinimumLevel { get; init; }
}

public record Minimumlevel
{
    public string Default { get; init; }
    public Override Override { get; init; }
}

public record Override
{
    public string Microsoft { get; init; }
    public string MicrosoftHostingLifetime { get; init; }
    public string MicrosoftAspNetCoreAuthentication { get; init; }
    public string System { get; init; }
}

public record Clients
{
    public Salesbackoffice SalesBackoffice { get; init; }
}

public record Salesbackoffice
{
    public string CliendId { get; init; }
    public string ClientSecret { get; init; }
}

public record Connectionstrings
{
    public string SqlServer { get; init; }
}

public record Applicationlocalconfig
{
    public bool ShouldSeedRoles { get; init; }
    public bool ShouldSeedUsersWithClaims { get; init; }
}
