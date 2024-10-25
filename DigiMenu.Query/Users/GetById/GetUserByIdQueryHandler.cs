using Common.Query;
using DigiMenu.Infrastracture.Persistent.EF;
using DigiMenu.Query.Users.DTO;
using Microsoft.EntityFrameworkCore;

namespace DigiMenu.Query.Users.GetById
{
    public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserDto?>
    {
        private readonly DigiMenuContext _context;

        public GetUserByIdQueryHandler(DigiMenuContext context)
        {
            _context = context;
        }

        public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            return await user.Map().SetUserRoleTitles(_context);
        }
    }
}
