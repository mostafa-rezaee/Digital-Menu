﻿using Common.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Domain.CategoryAgg
{
    public interface ICategoryRepository : BaseRepository<Category>
    {
        Task<bool> Delete(long id);
    }
}
