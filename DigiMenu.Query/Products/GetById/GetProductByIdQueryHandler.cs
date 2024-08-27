using Common.Query;
using DigiMenu.Infrastracture.Persistent.EF;
using DigiMenu.Query.Products.DTO;
using Microsoft.EntityFrameworkCore;

namespace DigiMenu.Query.Products.GetById
{
    public class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, ProductDto?>
    {
        private readonly DigiMenuContext _context;

        public GetProductByIdQueryHandler(DigiMenuContext context)
        {
            _context = context;
        }

        public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x=> x.Id == request.Id, cancellationToken);
            return product.Map();
        }
    }
}
