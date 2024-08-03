using System.ComponentModel.DataAnnotations;

namespace Sales.Backoffice.Dto.Requests;

public class CreatePersonContactListRequest
{
    public string Contact { get; set; }
    public int Type { get; set; }
}
