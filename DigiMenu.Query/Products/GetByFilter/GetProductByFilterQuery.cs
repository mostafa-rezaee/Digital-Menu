using Common.Query;
using DigiMenu.Query.Products.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Query.Products.GetByFilter
{
    public class GetProductByFilterQuery : QueryFilter<ProductFilterResult, ProductFilterParams>
    {
        public GetProductByFilterQuery(ProductFilterParams filterParam) : base(filterParam)
        {
        }
    }
}
