using Sales.Backoffice.Dto.Enums;

namespace Sales.Backoffice.Dto.Requests.Commands;

public class CreateDocumentRequest
{
    public string Number { get; set; }
    public DocumentTypeDto DocumentType { get; set; }
}
