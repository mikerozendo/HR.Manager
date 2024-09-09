using Sales.Backoffice.Dto.Requests.Commands;
using Sales.Backoffice.Model;
using Sales.Backoffice.Model.Enums;

namespace Sales.Backoffice.Application.Mappers;

public static class DocumentMapper
{
    public static List<Document> ToModel(this List<CreateDocumentRequest> documents)
    {
        return documents.Select(x => new Document
            {
                DocumentType = (DocumentType)x.DocumentType,
                Number = x.Number,
            })
            .ToList();
    }
}