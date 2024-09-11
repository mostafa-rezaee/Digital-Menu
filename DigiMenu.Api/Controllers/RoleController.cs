using Common.NetCore;
using DigiMenu.Api.Infrastructure;
using DigiMenu.Application.Products.Create;
using DigiMenu.Application.Products.Edit;
using DigiMenu.Application.Roles.Create;
using DigiMenu.Application.Roles.Edit;
using DigiMenu.Presentation.Facade.Products;
using DigiMenu.Presentation.Facade.Roles;
using DigiMenu.Query.Roles.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigiMenu.Api.Controllers
{
    [PermissionCheck(Domain.RoleAgg.Enums.Permissions.ManageRoles)]
    public class RoleController : BaseApiController
    {
        private readonly IRoleFacade _roleFacade;

        public RoleController(IRoleFacade roleFacade)
        {
            _roleFacade = roleFacade;
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<RoleDto?>> GetRoleById(long id)
        {
            var result = await _roleFacade.GetRoleById(id);
            return QueryResult(result);
        }

        [HttpGet]
        public async Task<ApiResult<List<RoleDto>>> GetRoles()
        {
            var result = await _roleFacade.GetRoleList();
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult> CreateRole(CreateRoleCommand command)
        {
            var result = await _roleFacade.Create(command);
            return CommandResult(result);
        }

        [HttpPut]
        public async Task<ApiResult> EditRole(EditRoleCommand command)
        {
            var result = await _roleFacade.Edit(command);
            return CommandResult(result);
        }
    }
}
