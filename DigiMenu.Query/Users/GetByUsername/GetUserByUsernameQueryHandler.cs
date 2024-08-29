﻿using Common.Query;
using DigiMenu.Infrastracture.Persistent.EF;
using DigiMenu.Query.Users.DTO;
using Microsoft.EntityFrameworkCore;

namespace DigiMenu.Query.Users.GetByUsername
{
    public class GetUserByUsernameQueryHandler : IQueryHandler<GetUserByUsernameQuery, UserDto?>
    {
        private readonly DigiMenuContext _context;

        public GetUserByUsernameQueryHandler(DigiMenuContext context)
        {
            _context = context;
        }

        public async Task<UserDto?> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == request.username, cancellationToken);
            if (user == null) return null;
            return await user.Map().SetUserRoleTitles(_context);
        }
    }
}