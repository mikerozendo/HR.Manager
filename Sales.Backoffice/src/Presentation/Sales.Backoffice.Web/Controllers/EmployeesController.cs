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
		var apiResponse = await webApiClient.GetEmployeesByFilterAsync(activeEmployeeOptionsDto);
		
		return View(apiResponse.Content);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Post([FromForm] CreateEmployeeRequest request)
	{
		webApiClient.PostAsync(request);
		return Created();
	}

	public IActionResult Create()
	{
		return View();
	}
}
