using Common.Query;
using DigiMenu.Infrastracture.Persistent.EF;
using DigiMenu.Query.Users.DTO;
using Microsoft.EntityFrameworkCore;

namespace DigiMenu.Query.Users.GetByFilter
{
    public class GetUserByFilterQueryHandler : IQueryHandler<GetUserByFilterQuery, UserFilterResult>
    {
        private readonly DigiMenuContext _context;

        public GetUserByFilterQueryHandler(DigiMenuContext context)
        {
            _context = context;
        }

        public async Task<UserFilterResult> Handle(GetUserByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParam;
            var users = _context.Users.OrderBy(x=>x.LastName).ThenBy(x=>x.FirstName).AsQueryable();
            if (@params.FirstName != null)
            {
                users = users.Where(x => x.FirstName.Contains(@params.FirstName));
            }
            if (@params.LastName != null)
            {
                users = users.Where(x => x.FirstName.Contains(@params.LastName));
            }
            if (@params.Username != null)
            {
                users = users.Where(x => x.Username == @params.Username);
            }
            var skip = (@params.PageNumber - 1) * @params.PageCount;
            var result = new UserFilterResult
            {
                Data = await users.Skip(skip).Take(@params.PageCount).Select(x => x.MapListData()).ToListAsync(cancellationToken),
                FilterParams = @params
            };
            result.GeneratePaging(users, @params.PageCount, @params.PageNumber);
            return result;
        }
    }
}
