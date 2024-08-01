namespace Sales.Backoffice.Web.Configuration;

public record EnvironmentConfiguration
{
    public  WebServiceUrls WebServiceUrls { get; init; }
    public Identity Identity { get; init; }
}

public record WebServiceUrls
{
    public string SalesBackofficeWebApi { get; init; }
    public string SalesBackofficeIdentity { get; init; }
}

public record Identity
{
    public string ClientId { get; init; }
    public string ClientSecret { get; init; }
    public string ResponseType { get; init; }
    public string AllowedScopes { get; init; }
}