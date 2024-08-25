using DigiMenu.Domain.ProductAgg;
using DigiMenu.Domain.ProductAgg.Repositories;
using DigiMenu.Infrastracture._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Infrastracture.Persistent.EF.ProductAgg
{
    internal class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(DigiMenuContext context) : base(context)
        {
        }
    }
}
