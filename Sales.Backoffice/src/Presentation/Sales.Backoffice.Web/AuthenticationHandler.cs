using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;

namespace Sales.Backoffice.Web;

public class AuthenticationHandler : DelegatingHandler
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthenticationHandler(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var accessToken = await _httpContextAccessor.HttpContext.GetTokenAsync("access_token");
        if (string.IsNullOrEmpty(accessToken))
            throw new UnauthorizedAccessException("Fail to get acces_token");

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        return await base.SendAsync(request, cancellationToken);
    }
}

