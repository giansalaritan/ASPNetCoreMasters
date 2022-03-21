using ASPNetCoreMastersToDoList.AuthorizationRequirements;
using DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Services.DTO;

namespace ASPNetCoreMastersToDoList.AuthorizationHandlers
{
    public class CanEditItemsHandler : AuthorizationHandler<CanEditItemsRequirement, ItemDTO>
    {
        private readonly UserManager<User> _userManager;

        public CanEditItemsHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                             CanEditItemsRequirement requirement,
                                                             ItemDTO resource)
        {
            var appUser = await _userManager.GetUserAsync(context.User);
            if (appUser == null)
            {
                return;
            }

            if (resource.CreatedBy == Guid.Parse(appUser.Id)
            {
                context.Succeed(requirement);
            }
        }
    }
}
