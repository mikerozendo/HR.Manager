namespace Sales.Backoffice.Identity.Configuration;

public class EnvironmentConfiguration
{
    public Serilog Serilog { get; set; }
    public Clients Clients { get; set; }
    public Connectionstrings ConnectionStrings { get; set; }
    public Applicationlocalconfig ApplicationLocalConfig { get; set; }
}

public class Serilog
{
    public Minimumlevel MinimumLevel { get; set; }
}

public class Minimumlevel
{
    public string Default { get; set; }
    public Override Override { get; set; }
}

public class Override
{
    public string Microsoft { get; set; }
    public string MicrosoftHostingLifetime { get; set; }
    public string MicrosoftAspNetCoreAuthentication { get; set; }
    public string System { get; set; }
}

public class Clients
{
    public Salesbackoffice SalesBackoffice { get; set; }
}

public class Salesbackoffice
{
    public string CliendId { get; set; }
    public string ClientSecret { get; set; }
}

public class Connectionstrings
{
    public string SqlServer { get; set; }
}

public class Applicationlocalconfig
{
    public bool ShouldSeedRoles { get; set; }
    public bool ShouldSeedUsersWithClaims { get; set; }
}
