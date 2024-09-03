using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Sales.Backoffice.WebApi.Controllers;

[Authorize]
[Route("api/sellers")]
[ApiController]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]

public class SellersController : ControllerBase
{
}
