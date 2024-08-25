using DigiMenu.Domain.CategoryAgg;
using DigiMenu.Infrastracture._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Infrastracture.Persistent.EF.CategoryAgg
{
    internal class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DigiMenuContext context) : base(context)
        {
        }
    }
}
