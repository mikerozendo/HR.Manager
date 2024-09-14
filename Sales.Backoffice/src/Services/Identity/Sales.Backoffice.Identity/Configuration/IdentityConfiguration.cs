using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace Sales.Backoffice.Identity.Configuration;

public static class IdentityConfiguration
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        [
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
        ];

    public static IEnumerable<ApiScope> GetApiScopes(EnvironmentConfiguration envConfig) =>
        [
            new ApiScope(envConfig.Scopes.SalesBackofficeWebApi),
            new ApiScope("read","read data"),
            new ApiScope("write","write data"),
            new ApiScope("update","update data"),
            new ApiScope("delete","delete data"),
        ];

    public static IEnumerable<Client> GetClients(this WebApplicationBuilder builder, EnvironmentConfiguration envConfig) =>
        [
            new Client
            {
                ClientId = envConfig.Clients.SalesBackoffice.CliendId ,
                ClientSecrets = { new Secret(envConfig.Clients.SalesBackoffice.ClientSecret.Sha256()) },

                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = { "https://localhost:7050/signin-oidc" },
                FrontChannelLogoutUri = "https://localhost:7050/signout-oidc",
                PostLogoutRedirectUris = { "https://localhost:7050/signout-callback-oidc" },

                AllowOfflineAccess = false,
                AllowedScopes =
                {
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.Email,
                    envConfig.Scopes.SalesBackofficeWebApi
                }
            },
        ];

    public static IEnumerable<ApiResource> ApiResources(EnvironmentConfiguration envConfig) =>
    [
        new ApiResource(envConfig.Scopes.SalesBackofficeWebApi, "Sales Backoffice API")
        {
            Scopes = { envConfig.Scopes.SalesBackofficeWebApi },
            ApiSecrets = { new Secret("api-secret".Sha256()) }
        }
    ];
}
