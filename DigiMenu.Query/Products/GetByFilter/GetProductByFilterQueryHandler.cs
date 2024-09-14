using Common.Query;
using DigiMenu.Infrastracture.Persistent.EF;
using DigiMenu.Query.Products.DTO;
using Microsoft.EntityFrameworkCore;

namespace DigiMenu.Query.Products.GetByFilter
{
    public class GetProductByFilterQueryHandler : IQueryHandler<GetProductByFilterQuery, ProductFilterResult>
    {
        private readonly DigiMenuContext _context;

        public GetProductByFilterQueryHandler(DigiMenuContext context)
        {
            _context = context;
        }

        public async Task<ProductFilterResult> Handle(GetProductByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParam;
            var result = _context.Products.OrderByDescending(x=> x.CreateDate).AsQueryable();

            if (@params.Title != null)
            {
                result = result.Where(x => x.Title.Contains(@params.Title));
            }

            if (@params.CategoryId != null)
            {
                result = result.Where(x => x.CategoryId == @params.CategoryId.Value);
            }

            var skip = (@params.PageNumber - 1) * @params.PageCount;
            var data = new ProductFilterResult
            {
                Data = await result.Skip(skip).Take(@params.PageCount).Select(x => x.MapListData()).ToListAsync(cancellationToken),
                FilterParams = @params
            };
            data.GeneratePaging(result, @params.PageCount, @params.PageNumber);
            return data;
        }
    }
}
