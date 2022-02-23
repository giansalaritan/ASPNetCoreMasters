using Microsoft.AspNetCore.Mvc;
using Services;

namespace ASPNetCoreMastersToDoList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        public IActionResult Get(int userId)
        {
            var strings = ItemService.GetAll(userId);
            return Ok(strings);
        }
    }
}
