using Sales.Backoffice.Dto.Requests.Commands;
using Sales.Backoffice.WebApi.Models;
using Sales.Backoffice.WebApi.Models.Enums;

namespace Sales.Backoffice.WebApi.Mappers;

public static class DocumentMapper
{
    public static List<Document> ToModel(this List<CreateDocumentRequest> documents)
    {
        return documents.Select(x => new Document()
        {
            DocumentType = (DocumentType)x.DocumentType,
            Number = x.Number,
            Validated = false,
        })
        .ToList();
    }
}
