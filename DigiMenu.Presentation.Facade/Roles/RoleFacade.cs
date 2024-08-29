using Common.Application;
using DigiMenu.Application.Roles.Create;
using DigiMenu.Application.Roles.Edit;
using DigiMenu.Query.Roles.DTO;
using DigiMenu.Query.Roles.GetById;
using DigiMenu.Query.Roles.GetList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DigiMenu.Presentation.Facade.Roles
{
    internal class RoleFacade : IRoleFacade
    {
        private readonly IMediator mediator;

        public RoleFacade(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<OperationResult> Create(CreateRoleCommand command)
        {
            return await mediator.Send(command);
        }

        public async Task<OperationResult> Edit(EditRoleCommand command)
        {
            return await mediator.Send(command);
        }

        public async Task<RoleDto?> GetRoleById(long id)
        {
            return await mediator.Send(new GetRoleByIdQuery(id));
        }

        public async Task<List<RoleDto>> GetRoleList()
        {
            return await mediator.Send(new GetRoleListQuery());
        }
    }
}
