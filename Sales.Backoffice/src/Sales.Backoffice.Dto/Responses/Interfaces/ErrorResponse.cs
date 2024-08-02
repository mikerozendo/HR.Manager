using System.Diagnostics;

namespace Sales.Backoffice.Dto.Responses.Interfaces;

public class ErrorResponse<T> : IResponse<T>
{
    public string ErrorDescription { get; private set; }
    public StackTrace StackTrace { get; set; }
    public T Data { get; set; }

    public ErrorResponse(string errorDescription, StackTrace envStackTrace)
    {
        ErrorDescription = errorDescription;
        StackTrace = envStackTrace;
    }
}
