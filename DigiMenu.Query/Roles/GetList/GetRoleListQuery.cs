using Common.Query;
using DigiMenu.Infrastracture.Persistent.EF;
using DigiMenu.Query.Roles.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Query.Roles.GetList
{
    public record GetRoleListQuery : IQuery<List<RoleDto>>;

    public class GetRoleListQueryHandler : IQueryHandler<GetRoleListQuery, List<RoleDto>>
    {
        private readonly DigiMenuContext _context;

        public GetRoleListQueryHandler(DigiMenuContext context)
        {
            _context = context;
        }

        public async Task<List<RoleDto>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
        {
            var roles = await _context.Roles.ToListAsync(cancellationToken);
            return roles.MapList();
        }
    }
}
