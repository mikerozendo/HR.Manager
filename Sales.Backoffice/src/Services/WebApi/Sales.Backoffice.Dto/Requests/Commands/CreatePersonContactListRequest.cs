using Sales.Backoffice.Dto.Enums;

namespace Sales.Backoffice.Dto.Requests.Commands;

public class CreatePersonContactListRequest
{
    public string Contact { get; set; }
    public ContactTypeDto ContactType { get; set; }
}