using Sales.Backoffice.Dto.Responses.Interfaces;

namespace Sales.Backoffice.Dto.Responses;

public class PaginatedResponse<T> : IPaginatedResponse<T>
{
    public ICollection<T> Data { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int Pages { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int CurrentyPage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int RowsPerPage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    T IResponse<T>.Data { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
