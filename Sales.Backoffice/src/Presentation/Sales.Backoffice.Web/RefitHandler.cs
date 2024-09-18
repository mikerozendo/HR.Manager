using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;

namespace Sales.Backoffice.Web;

public class RefitHandler(IHttpContextAccessor httpContextAccessor) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var accessToken = await httpContextAccessor.HttpContext.GetTokenAsync("access_token");
        if (string.IsNullOrEmpty(accessToken))
            throw new UnauthorizedAccessException("Fail to get acces_token");

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        var response = await base.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();
        return response;
    }
}