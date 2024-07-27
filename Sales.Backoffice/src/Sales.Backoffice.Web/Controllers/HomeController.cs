using Microsoft.AspNetCore.Mvc;
using Sales.Backoffice.Application.UseCases;
using Sales.Backoffice.Web.Models;
using System.Diagnostics;

namespace Sales.Backoffice.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHealthCheckUseCase _healthCheckUseCase;
        public HomeController(ILogger<HomeController> logger, IHealthCheckUseCase healthCheckUseCase)
        {
            _logger = logger;
            _healthCheckUseCase = healthCheckUseCase;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            //return View();
            await _healthCheckUseCase.GetAsync();
            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
