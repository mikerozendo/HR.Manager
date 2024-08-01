using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sales.Backoffice.Web.Models;
using Sales.Backoffice.Web.Repositories;
using System.Diagnostics;

namespace Sales.Backoffice.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHealthCheckRepository _healthCheckUseCase;
        public HomeController(ILogger<HomeController> logger, IHealthCheckRepository healthCheckUseCase)
        {
            _logger = logger;
            _healthCheckUseCase = healthCheckUseCase;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Login()
        {
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Logout()
        {
            return SignOut("Cookies","oidc");
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
