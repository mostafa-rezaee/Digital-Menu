using Common.Application;
using DigiMenu.Application.Roles.Create;
using DigiMenu.Application.Roles.Edit;
using DigiMenu.Query.Roles.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Presentation.Facade.Roles
{
    public interface IRoleFacade
    {
        //Cammands
        Task<OperationResult> Create(CreateRoleCommand command);
        Task<OperationResult> Edit(EditRoleCommand command);

        //Queries
        Task<RoleDto?> GetRoleById(long id);
        Task<List<RoleDto>> GetRoleList();
    }
}
