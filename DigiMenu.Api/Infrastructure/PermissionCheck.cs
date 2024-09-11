using Common.NetCore.Utilities;
using DigiMenu.Domain.RoleAgg.Enums;
using DigiMenu.Presentation.Facade.Roles;
using DigiMenu.Presentation.Facade.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security;

namespace DigiMenu.Api.Infrastructure
{
    public class PermissionCheck : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        private IUserFacade _userFacade;
        private IRoleFacade _roleFacade;
        private readonly Permissions permissions;

        public PermissionCheck(Permissions permissions)
        {
            this.permissions = permissions;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            if (HasAllowAnonymous(context))
                return;

            _userFacade = context.HttpContext.RequestServices.GetRequiredService<IUserFacade>();
            _roleFacade = context.HttpContext.RequestServices.GetRequiredService<IRoleFacade>();
            if (context.HttpContext.User.Identity != null && context.HttpContext.User.Identity.IsAuthenticated)
            {
                if (await UserHasPermission(context) == false)
                {
                    context.Result = new ForbidResult();
                }
            }
            else
            {
                context.Result = new UnauthorizedObjectResult("Unauthorized user!");
            }
        }

        private bool HasAllowAnonymous(AuthorizationFilterContext context)
        {
            var metaData = context.ActionDescriptor.EndpointMetadata.OfType<dynamic>().ToList();
            bool hasAllowAnonymous = false;
            foreach (var f in metaData)
            {
                try
                {
                    hasAllowAnonymous = f.TypeId.Name == "AllowAnonymousAttribute";
                    if (hasAllowAnonymous)
                        break;
                }
                catch
                {
                }
            }

            return hasAllowAnonymous;
        }

        private async Task<bool> UserHasPermission(AuthorizationFilterContext context)
        {
            var user = await _userFacade.GetUserById(context.HttpContext.User.GetUserId());
            if (user == null)
                return false;

            var roleIds = user.Roles.Select(s => s.RoleId).ToList();
            var roles = await _roleFacade.GetRoleList();


            var userRoles = roles.Where(r => roleIds.Contains(r.Id));

            return userRoles.Any(r => r.Permissions.Contains(permissions));
        }
    }
}
