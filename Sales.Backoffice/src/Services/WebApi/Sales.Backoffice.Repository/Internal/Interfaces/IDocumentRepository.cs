using Sales.Backoffice.Model;

namespace Sales.Backoffice.Repository.Internal.Interfaces;

public interface IDocumentRepository
{
    Task<List<Document>> GetDocumentsByNumbersAsync(params string[] documents);
}