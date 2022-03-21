using ASPNetCoreMastersToDoList.ConfigModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ASPNetCoreMastersToDoList.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly JWTConfigModel _jwt;
        public UsersController(IOptions<JWTConfigModel> options)
        {
            _jwt = options.Value;
        }

        [HttpGet]
        [Route("/login")]
        public IActionResult Login()
        {
            return Ok(_jwt);
        }
    }
}
