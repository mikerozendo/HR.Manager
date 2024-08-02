using Sales.Backoffice.WebApi.Models.Enums;

namespace Sales.Backoffice.WebApi.Models;

public class Document : RegisterBase
{
    public string Number { get; set; }
    public DocumentType DocumentType { get; set; }
    public bool IsValid { get; set; }
    public bool Validated { get; set; }
}
