using Common.Application;
using DigiMenu.Domain.RoleAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Application.Roles.Create
{
    public record CreateRoleCommand(string title, List<Permissions> permissions) : IBaseCommand;
}
