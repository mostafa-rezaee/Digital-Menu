using Common.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Query.Products.DTO
{
    public class ProductImageDto : BaseDto
    {
        public long ProductId { get;  set; }
        public string ImageName { get;  set; }
        public int Order { get;  set; }
    }
}
