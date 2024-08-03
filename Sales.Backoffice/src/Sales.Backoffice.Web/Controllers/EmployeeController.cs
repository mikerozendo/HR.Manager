using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales.Backoffice.Application.Services;
using Sales.Backoffice.Dto.Requests;

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

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var list = await _employeeService.GetAsync();
        return View(list);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Post([FromForm] CreateEmployeeRequest request)
    {
        var response = await _employeeService.PostAsync(request);
        return CreatedAtAction(nameof(Index), request);
    }
    public IActionResult Create()
    {
        return View();
    }
}
