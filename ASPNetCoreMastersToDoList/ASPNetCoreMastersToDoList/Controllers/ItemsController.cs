using ASPNetCoreMastersToDoList.BindingModels;
using ASPNetCoreMastersToDoList.Constants;
using ASPNetCoreMastersToDoList.Filters;
using DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Security.Claims;

namespace ASPNetCoreMastersToDoList.Controllers
{
    [ApiController]
    [ServiceFilter(typeof(EnsureItemExistsFilter))]
    [Authorize]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly IAuthorizationService _authService;
        private readonly UserManager<User> _userService;

        public ItemsController(IItemService itemService, IAuthorizationService authorization, UserManager<User> userService)
        {
            _itemService = itemService;
            _authService = authorization;
            _userService = userService;
        }

        [HttpGet]
        [Route("items")]
        public IActionResult GetAll()
        {
            return Ok(_itemService.GetAll());
        }

        [HttpGet]
        [Route("items/{itemId}")]
        public IActionResult Get(int itemId)
        {
            return Ok(_itemService.Get(itemId));
        }

        [HttpGet]
        [Route("items/filterBy")]
        public IActionResult GetByFilters([FromQuery] ItemFilterBindingModel filters)
        {
            return Ok(_itemService.GetAllByFilter(filters.Map()));
        }

        [HttpPost]
        [Route("items")]
        public async Task<IActionResult> PostAsync([FromBody] ItemCreateBindingModel data)
        {
            var email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var user = await _userService.FindByNameAsync(email);
            _itemService.Add(data.Map(), user);
            return Ok();
        }

        [Authorize]
        [HttpPut]
        [Route("items/{itemId}")]
        public async Task<IActionResult> Put(int itemId, [FromBody] ItemUpdateBindingModel data)
        {
            var item = _itemService.Get(itemId);
            item.Text = data.Text;
            var authResult = await _authService.AuthorizeAsync(User, item, AuthorizationConstants.CanEditItems);
            if (!authResult.Succeeded)
            {
                return Forbid();
            }
            _itemService.Update(item);
            return Ok();
        }

        [HttpDelete]
        [Route("items/{itemId}")]
        public IActionResult Delete(int itemId)
        {
            _itemService.Delete(itemId);
            return Ok();
        }
    }
}
