using ASPNetCoreMastersToDoList.BindingModels;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTO;

namespace ASPNetCoreMastersToDoList.Controllers
{
    [ApiController]
    public class ItemsController : ControllerBase
    {
        [HttpGet, Route("items")]
        public IActionResult GetAll()
        {
            var items = ItemService.GetAll();
            return Ok(items);
        }

        [HttpGet, Route("items/{itemId}")]
        public IActionResult Get(int itemId)
        {
            var item = ItemService.Get(itemId);
            return Ok(item);
        }

        [HttpGet, Route("items/filterBy")]
        public IActionResult GetByFilters([FromQuery] Dictionary<string, string> filters)
        {
            return Ok(null);
        }

        [HttpPost, Route("items")]
        public IActionResult Post([FromBody] ItemCreateBindingModel itemCreateModel)
        {
            var itemDTO = new ItemDTO()
            {
                Text = itemCreateModel.Text
            };

            var isSuccess = ItemService.Save(itemDTO);

            return Ok(isSuccess);
        }

        [HttpPut, Route("items/{itemId}")]
        public IActionResult Put(int itemId, [FromBody] ItemCreateBindingModel itemCreateModel)
        {
            var itemDTO = new ItemDTO()
            {
                Id = itemId,
                Text = itemCreateModel.Text
            };

            var isSuccess = ItemService.Update(itemDTO);
            return Ok(isSuccess);
        }

        [HttpDelete, Route("items/{itemId}")]
        public IActionResult Delete(int itemId)
        {
            var isSuccess = ItemService.Delete(itemId);
            return Ok(isSuccess);
        }
    }
}
