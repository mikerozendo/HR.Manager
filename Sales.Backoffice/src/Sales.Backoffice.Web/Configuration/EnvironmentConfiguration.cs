namespace Sales.Backoffice.Web.Configuration;

public class EnvironmentConfiguration
{
    public WebServiceUrls WebServiceUrls { get; set; }
}

public class WebServiceUrls
{
    public string SalesBackofficeWebApi { get; set; }
    public string SalesBackofficeIdentity { get; set; }
}

