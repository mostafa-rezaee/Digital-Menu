using Common.Query;
using DigiMenu.Domain.UserAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Query.Users.DTO
{
    public class UserDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AvatarName { get; set; }
        public bool IsActive { get; set; }
        public List<UserRoleDto> Roles { get; set; }
    }
}
