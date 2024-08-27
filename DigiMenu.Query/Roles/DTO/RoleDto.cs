using Common.Query;
using DigiMenu.Domain.RoleAgg;
using DigiMenu.Domain.RoleAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Query.Roles.DTO
{
    public class RoleDto : BaseDto
    {
        public string Title { get;  set; }
        public List<Permissions> Permissions { get;  set; }
    }


}
