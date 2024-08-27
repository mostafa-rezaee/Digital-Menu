using Common.Query;
using DigiMenu.Query.Categories.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Query.Categories.GetById
{
    public record GetCategoryByIdQuery(long Id) : IQuery<CategoryDto?>;
}
