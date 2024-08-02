using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales.Backoffice.Application.RequestModels;
using Sales.Backoffice.Application.Services;

namespace Sales.Backoffice.Web.Controllers;

[Authorize]
public class EmployeeController : Controller
{
    private readonly ILogger<EmployeeController> _logger;
    private readonly IEmployeeService _employeeService;
    public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
    {
        _logger = logger;
        _employeeService = employeeService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Post(EmployeeRequest request)
    {
        var response = await _employeeService.PostAsync(request);
        return CreatedAtAction(nameof(Index), request);
    }
}
