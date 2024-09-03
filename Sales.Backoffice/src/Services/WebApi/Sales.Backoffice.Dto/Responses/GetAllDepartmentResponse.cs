using Sales.Backoffice.Dto.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Backoffice.Dto.Responses;

public class GetAllDepartmentResponse
{
    public Guid Id { get; set; }
    public DepartmentTypeDto DepartmentType { get; set; }

}
