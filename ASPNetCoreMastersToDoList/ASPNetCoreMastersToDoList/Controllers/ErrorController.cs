using Microsoft.AspNetCore.Mvc;

namespace ASPNetCoreExceptionHandler.Controllers;

[ApiController]
public class ErrorController : ControllerBase
{
    [HttpGet]
    [Route("/error")]
    public IActionResult Error() => Problem();
}
