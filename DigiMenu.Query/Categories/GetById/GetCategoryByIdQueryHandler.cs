using Common.Query;
using DigiMenu.Infrastracture.Persistent.EF;
using DigiMenu.Query.Categories.DTO;
using Microsoft.EntityFrameworkCore;

namespace DigiMenu.Query.Categories.GetById
{
    internal class GetCategoryByIdQueryHandler : IQueryHandler<GetCategoryByIdQuery, CategoryDto?>
    {
        private readonly DigiMenuContext _context;

        public GetCategoryByIdQueryHandler(DigiMenuContext context)
        {
            _context = context;
        }

        public async Task<CategoryDto?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var model = await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            return model.Map();
        }
    }
}
