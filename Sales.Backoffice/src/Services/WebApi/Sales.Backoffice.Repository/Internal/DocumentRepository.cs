using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.Model;
using Sales.Backoffice.Repository.Internal.Interfaces;

namespace Sales.Backoffice.Repository.Internal;

public class DocumentRepository(ApplicationDbContext dbContext) : IDocumentRepository
{
    public async Task<List<Document>> GetDocumentsByNumbersAsync(params string[] documents)
    {
        return await dbContext.Documents
            .Where(x => documents.Contains(x.Number))
            .ToListAsync();
    }
}
