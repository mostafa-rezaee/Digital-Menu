using Common.Query;
using DigiMenu.Query.Users.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Query.Users.GetById
{
    public record GetUserByIdQuery(long Id) : IQuery<UserDto?>;
}
