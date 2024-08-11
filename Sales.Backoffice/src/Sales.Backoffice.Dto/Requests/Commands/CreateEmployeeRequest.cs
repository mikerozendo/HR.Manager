using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sales.Backoffice.Dto.Enums;
using System.ComponentModel.DataAnnotations;

namespace Sales.Backoffice.Dto.Requests.Commands;

public class CreateEmployeeRequest : IRequest<ObjectResult>
{
    [Required]
    public string Name { get; set; }

    [Required]
    [MaxLength(40)]
    public string LastName { get; set; }

    [Required]
    public List<CreateDocumentRequest> DocumentList { get; set; } = [];

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    public DateTime ContractStart { get; set; }

    [Required]
    public SexTypeDto SexType { get; set; }

    [Required]
    public List<CreatePersonContactListRequest>? PersonContactList { get; set; } = [];

    public DepartmentTypeDto DepartmentType { get; set; }
}