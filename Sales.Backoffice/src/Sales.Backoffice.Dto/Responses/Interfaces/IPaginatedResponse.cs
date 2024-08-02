namespace Sales.Backoffice.Dto.Responses.Interfaces;

public interface IPaginatedResponse<T> : IResponse<T>
{
    ICollection<T> Data { get; set; }
    int Pages { get; set; }
    int CurrentyPage { get; set; }
    int RowsPerPage { get; set; }
}
