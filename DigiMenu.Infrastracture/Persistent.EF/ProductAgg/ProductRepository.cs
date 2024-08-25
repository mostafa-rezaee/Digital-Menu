using Dapper;
using DigiMenu.Domain.ProductAgg;
using DigiMenu.Domain.ProductAgg.Repositories;
using DigiMenu.Infrastracture._Utilities;
using DigiMenu.Infrastracture.Persistent.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Infrastracture.Persistent.EF.ProductAgg
{
    internal class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly DapperContext _dapperContext;
        public ProductRepository(DigiMenuContext context, DapperContext dapperContext) : base(context)
        {
            _dapperContext = dapperContext;
        }

        public async Task<ProductImage?> GetProductImageById(long id)
        {
            using var connection = _dapperContext.CreateConnection();
            var sql = $"SELECT * from {_dapperContext.ProductImages} where Id=@ImageId";

            return await connection.QueryFirstOrDefaultAsync<ProductImage>
                (sql, new { ImagesId = id });
        }
    }
}
