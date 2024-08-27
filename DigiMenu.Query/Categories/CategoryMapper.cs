using DigiMenu.Domain.CategoryAgg;
using DigiMenu.Query.Categories.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Query.Categories
{
    internal static class CategoryMapper
    {
        public static CategoryDto Map(this Category? category)
        {
            if (category == null) return null;
            return new CategoryDto {
                Title = category.Title,
                ImageName = category.ImageName,
                IsVisible = category.IsVisible,
                SeoData = category.SeoData,
                Id = category.Id,
                CreateDate = category.CreateDate
            };
        }

        public static List<CategoryDto> Map(this List<Category> categories)
        {
            var list = new List<CategoryDto>();
            foreach (var category in categories)
            {
                if (category == null) continue;
                list.Add(Map(category));
            }
            return list;
        }
    }
}
