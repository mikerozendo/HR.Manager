namespace Sales.Backoffice.Dto.Responses.Interfaces;

public interface IResponse<T>
{
    T Data { get; set; }
}
