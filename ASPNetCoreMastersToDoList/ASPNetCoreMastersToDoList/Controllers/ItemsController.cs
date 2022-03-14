using ASPNetCoreMastersToDoList.BindingModels;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.DTO;

namespace ASPNetCoreMastersToDoList.Controllers
{
    public class ItemsController : ControllerBase
    {
        public IActionResult Get(int id)
        {
            return Ok(id);
        }

        public IActionResult Post(ItemCreateBindingModel itemCreateBindingModel)
        {
            var itemDTO = new ItemDTO()
            {
                Text = itemCreateBindingModel.Text
            };

            ItemService.Save(itemDTO);

            return Ok(true);
        }
    }
}
