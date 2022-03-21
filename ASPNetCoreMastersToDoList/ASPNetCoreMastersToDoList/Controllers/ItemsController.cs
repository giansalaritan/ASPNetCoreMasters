using ASPNetCoreMastersToDoList.BindingModels;
using ASPNetCoreMastersToDoList.Filters;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ASPNetCoreMastersToDoList.Controllers
{
    [ApiController]
    [ServiceFilter(typeof(EnsureItemExistsFilter))]
    public class ItemsController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemsController(IItemService itemService)
        {
            _itemService = itemService;
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
        public IActionResult Post([FromBody] ItemCreateBindingModel data)
        {
            _itemService.Add(data.Map());
            return Ok();
        }

        [HttpPut]
        [Route("items/{itemId}")]
        public IActionResult Put(int itemId, [FromBody] ItemUpdateBindingModel data)
        {
            data.Id = itemId;
            _itemService.Update(data.Map());
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
