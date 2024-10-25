using DigiMenu.Domain.ProductAgg;
using DigiMenu.Infrastracture.Persistent.EF;
using DigiMenu.Query.Products.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Query.Products
{
    public static class ProductMapper
    {
        public static ProductDto? Map(this Product? product)
        {
            if (product == null) return null;
            return new()
            {
                CategoryId = product.CategoryId,
                CreateDate = product.CreateDate,
                Description = product.Description,
                Id = product.Id,
                ImageName = product.ImageName,
                IsVisible = product.IsVisible,
                LikeCount = product.LikeCount,
                Price = product.Price,
                Title = product.Title,
                SeoData = product.SeoData,
                ProductImages = product.ProductImages.Select(x => new ProductImageDto() { 
                    Id = x.Id,
                    CreateDate = x.CreateDate,
                    ImageName= x.ImageName,
                    ProductId = x.ProductId,
                    Order = x.Order
                }).ToList(),
                Category = new() {  Id = product.CategoryId}
            };
        }

        public static async Task SetCategory(this ProductDto productDto, DigiMenuContext _context)
        {
            var cat = await _context.Categories.FirstOrDefaultAsync(x => x.Id == productDto.CategoryId);
            if (cat == null) return;
            productDto.Category = new Categories.DTO.CategoryDto { 
                Id = cat.Id,
                CreateDate= cat.CreateDate,
                ImageName = cat.ImageName,
                IsVisible= cat.IsVisible,
                SeoData= cat.SeoData,
                Title = cat.Title,
            };
        }

        public static ProductFilterData MapListData(this Product product)
        {
            return new ProductFilterData()
            {
                Id = product.Id,
                CategoryTitle = product.Category.Title,
                CreateDate = product.CreateDate,
                ImageName = product.ImageName,
                Description = product.Description,
                Title = product.Title,
                LikeCount= product.LikeCount,
                IsVisible = product.IsVisible??true,
                Price = product.Price,
            };
        }
    }
}
