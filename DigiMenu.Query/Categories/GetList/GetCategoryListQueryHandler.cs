using Common.Query;
using DigiMenu.Infrastracture.Persistent.EF;
using DigiMenu.Query.Categories.DTO;
using Microsoft.EntityFrameworkCore;

namespace DigiMenu.Query.Categories.GetList
{
    internal class GetCategoryListQueryHandler : IQueryHandler<GetCategoryListQuery, List<CategoryDto>>
    {
        private readonly DigiMenuContext _context;

        public GetCategoryListQueryHandler(DigiMenuContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var list = await _context.Categories.ToListAsync(cancellationToken);
            return list.Map();
        }
    }
}
