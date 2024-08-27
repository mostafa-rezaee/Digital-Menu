using Common.Domain.ValueObjects;
using Common.Query;
using DigiMenu.Domain.ProductAgg;
using DigiMenu.Query.Categories.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Query.Products.DTO
{
    public class ProductDto : BaseDto
    {
        public string Title { get;  set; }
        public long CategoryId { get;  set; }
        public string ImageName { get; set; }
        public decimal Price { get; set; }
        public int LikeCount { get; set; }
        public bool IsVisible { get; set; }
        public string Description { get; set; }
        public SeoData SeoData { get; set; }
        public CategoryDto Category { get; set; }
        public List<ProductImageDto> ProductImages { get; set; }
    }
}
