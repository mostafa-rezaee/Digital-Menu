using Common.Domain.ValueObjects;
using Common.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Query.Categories.DTO
{
    public class CategoryDto : BaseDto
    {
        public string Title { get; set; }
        public string ImageName { get; set; }

        public bool IsVisible { get; set; }
        public SeoData SeoData { get; set; }
    }
}
