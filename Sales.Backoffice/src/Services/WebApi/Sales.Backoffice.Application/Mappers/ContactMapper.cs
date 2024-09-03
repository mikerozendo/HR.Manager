using Sales.Backoffice.Dto.Requests.Commands;
using Sales.Backoffice.Model;
using Sales.Backoffice.Model.Enums;

namespace Sales.Backoffice.Application.Mappers;

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
