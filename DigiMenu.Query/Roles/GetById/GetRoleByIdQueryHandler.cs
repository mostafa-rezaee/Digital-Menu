using Common.Query;
using DigiMenu.Infrastracture.Persistent.EF;
using DigiMenu.Query.Roles.DTO;
using Microsoft.EntityFrameworkCore;

namespace DigiMenu.Query.Roles.GetById
{
    public class GetRoleByIdQueryHandler : IQueryHandler<GetRoleByIdQuery, RoleDto?>
    {
        private readonly DigiMenuContext _context;

        public GetRoleByIdQueryHandler(DigiMenuContext context)
        {
            _context = context;
        }

        public async Task<RoleDto?> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            return role.Map();
        }
    }
}
