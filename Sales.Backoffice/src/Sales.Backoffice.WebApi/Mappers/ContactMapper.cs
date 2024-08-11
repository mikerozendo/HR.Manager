using Sales.Backoffice.Dto.Enums;
using Sales.Backoffice.Dto.Requests.Commands;
using Sales.Backoffice.WebApi.Models;
using Sales.Backoffice.WebApi.Models.Enums;

namespace Sales.Backoffice.WebApi.Mappers;

public static class ContactMapper
{
    public static List<Contact> ToModel(this List<CreatePersonContactListRequest> createPersonContactListRequests)
    {
        if (createPersonContactListRequests.Count == 0) return [];

        return createPersonContactListRequests
            .Select(x => new Contact()
            {
                ContactType = (ContactType)x.ContactType,
                Value = x.Contact
            })
            .ToList();
    }
}
