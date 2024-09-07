using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales.Backoffice.Dto.Enums;
using Sales.Backoffice.Dto.Requests.Commands;
using Sales.Backoffice.Web.Repositories.Interfaces;

namespace Sales.Backoffice.Web.Controllers;

[Authorize]
public class EmployeesController(IWebApiClient webApiClient) : Controller
{
	[HttpGet]
	public async Task<IActionResult> Index(ActiveEmployeeOptionsDto activeEmployeeOptionsDto = ActiveEmployeeOptionsDto.OnlyActive)
	{
		return View(await webApiClient.GetEmployeesByFilterAsync(activeEmployeeOptionsDto));
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Post([FromForm] CreateEmployeeRequest request)
	{
		return await webApiClient.PostAsync(request);
	}

	public IActionResult Create()
	{
		return View();
	}
}
