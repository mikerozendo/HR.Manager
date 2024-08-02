using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales.Backoffice.Application.Services;
using Sales.Backoffice.Dto;

namespace Sales.Backoffice.Web.Controllers;

[Authorize]
public class BuyerController : Controller
{
    private readonly ILogger<BuyerController> _logger;
    private readonly IBuyerService _buyerService;

    public BuyerController(ILogger<BuyerController> logger, IBuyerService buyerService)
    {
        _logger = logger;
        _buyerService = buyerService;
    }

    [HttpGet]
    public async Task<ActionResult<BuyerDto>> Get()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult<BuyerDto>> Post()
    {
        var response = await _buyerService.PostAsync(new BuyerDto { Name = "Michael Test" });
        return Created(nameof(Get), response.Content);
    }

    public async Task<IActionResult> Index()
    {
        var response = await _buyerService.GetAsync();
        return View(response.Content);
    }
}
