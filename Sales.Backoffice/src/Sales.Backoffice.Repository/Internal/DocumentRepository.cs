using Microsoft.EntityFrameworkCore;
using Sales.Backoffice.Model;
using Sales.Backoffice.Repository.Internal.Interfaces;

namespace Sales.Backoffice.Repository.Internal;

public class DocumentRepository : IDocumentRepository
{
    private readonly ApplicationDbContext _dbContext;

    public DocumentRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Document>> GetDocumentsByNumbersAsync(params string[] documents)
    {
        return await _dbContext.Documents
            .Where(x => documents.Contains(x.Number))
            .ToListAsync();
    }
}
