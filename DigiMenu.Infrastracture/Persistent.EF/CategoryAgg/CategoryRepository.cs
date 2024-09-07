using DigiMenu.Domain.CategoryAgg;
using DigiMenu.Infrastracture._Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Infrastracture.Persistent.EF.CategoryAgg
{
    internal class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly DigiMenuContext _context;
        public CategoryRepository(DigiMenuContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> Delete(long id)
        {
            var cat = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (cat == null) return false;

            var categoryInUse = await _context.Products.AnyAsync(p => p.CategoryId == id);
            if (categoryInUse) return false;

            var removeCat = _context.Categories.Remove(cat);
            return true;
        }
    }
}
