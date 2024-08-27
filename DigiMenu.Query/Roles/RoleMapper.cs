using DigiMenu.Domain.RoleAgg;
using DigiMenu.Query.Roles.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Query.Roles
{
    public static class RoleMapper
    {
        public static RoleDto? Map(this Role? role)
        {
            if (role == null) return null;
            return new RoleDto { 
                CreateDate = role.CreateDate,
                Id = role.Id,
                Permissions = role.RolePermissions.Select(x => x.Permission).ToList(),
                Title = role.Title,
            };
        }

        public static List<RoleDto> MapList(this List<Role> roles)
        {
            var result = new List<RoleDto>();
            roles.ForEach(role => {
                if (role != null) result.Add(role.Map());
            });

            return result;
        }
    }
}
