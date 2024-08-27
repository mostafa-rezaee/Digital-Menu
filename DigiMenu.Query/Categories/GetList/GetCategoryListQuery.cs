using Common.Query;
using DigiMenu.Query.Categories.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Query.Categories.GetList
{
    public record GetCategoryListQuery : IQuery<List<CategoryDto>>;
}
