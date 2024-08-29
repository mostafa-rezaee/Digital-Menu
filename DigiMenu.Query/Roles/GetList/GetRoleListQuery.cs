using Common.Query;
using DigiMenu.Query.Roles.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Query.Roles.GetList
{
    public record GetRoleListQuery : IQuery<List<RoleDto>>;
}
