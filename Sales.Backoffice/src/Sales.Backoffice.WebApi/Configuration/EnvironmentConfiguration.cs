namespace Sales.Backoffice.WebApi.Configuration;

public record EnvironmentConfiguration
{
    public Identityconfig IdentityConfig { get; init; }
    public ConnectionStrings ConnectionStrings { get; init; }
}

public record Identityconfig
{
    public string Url { get; init; }
    public string Scope { get; init; }
}

public record ConnectionStrings
{
    public string SqlServer { get; init; }
}
