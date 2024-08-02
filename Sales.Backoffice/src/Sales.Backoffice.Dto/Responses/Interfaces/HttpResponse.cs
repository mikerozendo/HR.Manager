using System.Net;

namespace Sales.Backoffice.Dto.Responses.Interfaces;

public class HttpResponse
{
    public HttpStatusCode HttpStatusCode { get; set; }
    public string Message { get; set; }
}
