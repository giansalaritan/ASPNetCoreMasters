using Microsoft.AspNetCore.Mvc;

namespace ASPNetCoreExceptionHandler.Controllers;

[ApiController]
public class ErrorController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error() => Problem();
}
