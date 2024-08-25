using DigiMenu.Domain.RoleAgg;
using DigiMenu.Domain.RoleAgg.Repositories;
using DigiMenu.Infrastracture._Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Infrastracture.Persistent.EF.RoleAgg
{
    internal class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(DigiMenuContext context) : base(context)
        {
        }
    }
}
