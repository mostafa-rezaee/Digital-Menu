using DigiMenu.Domain.UserAgg;
using DigiMenu.Infrastracture.Persistent.EF;
using DigiMenu.Query.Users.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Query.Users
{
    public static class UserMapper
    {
        public static UserDto? Map(this User? user)
        {
            if (user == null) return null;
            return new UserDto
            {
                AvatarName = user.AvatarName,
                CreateDate = user.CreateDate,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                Password = user.Password,
                Roles = user.Roles.Select( x => new UserRoleDto {
                    RoleId = x.RoleId,
                    RoleTitle = ""
                }).ToList(),
                Username = user.Username,
                IsActive = user.IsActive,
            };
        }

        public static UserFilterData MapListData(this User user)
        {
            return new UserFilterData
            {
                AvatarName = user.AvatarName,
                CreateDate = user.CreateDate,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                Username = user.Username
            };
        }

        public static async Task<UserDto> SetUserRoleTitles(this UserDto userDto, DigiMenuContext context)
        {
            var roleIds = userDto.Roles.Select(r => r.RoleId);
            var result = await context.Roles.Where(r => roleIds.Any() && roleIds.Contains(r.Id)).ToListAsync();
            var roles = new List<UserRoleDto>();
            foreach (var role in result)
            {
                roles.Add(new UserRoleDto()
                {
                    RoleId = role.Id,
                    RoleTitle = role.Title
                });
            }

            userDto.Roles = roles;
            return userDto;
        }
    }
}
