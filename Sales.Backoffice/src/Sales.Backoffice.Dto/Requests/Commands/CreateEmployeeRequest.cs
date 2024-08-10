using MediatR;
using Microsoft.AspNetCore.Mvc;
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
    public string Rg { get; set; }

    [Required]
    public string Cpf { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    public DateTime ContractStart { get; set; }

    [Required]
    [AllowedValues(0, 1)]
    public int SexType { get; set; }

    //[AllowNull]
    public List<CreatePersonContactListRequest>? PersonContactList { get; set; } = [];
}