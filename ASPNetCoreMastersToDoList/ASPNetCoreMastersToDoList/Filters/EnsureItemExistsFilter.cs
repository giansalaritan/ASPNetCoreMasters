using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Services;

namespace ASPNetCoreMastersToDoList.Filters
{
    public class EnsureItemExistsFilter : Attribute, IActionFilter
    {
        readonly IItemService _itemService;
        const string ItemIdKey = "itemId";

        public EnsureItemExistsFilter(IItemService itemService)
        {
            _itemService = itemService;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.ContainsKey(ItemIdKey))
            {
                var itemId = Convert.ToInt32(context.ActionArguments[ItemIdKey] ?? 0);
                var item = _itemService.Get(itemId);
                if (item == null || item.Id == 0)
                {
                    context.Result = new NotFoundResult();
                }
            }
        }
    }
}
