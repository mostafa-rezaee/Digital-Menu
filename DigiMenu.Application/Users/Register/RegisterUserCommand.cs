using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Application.Users.Register
{
    public record RegisterUserCommand(long id, string username, string password) : IBaseCommand;
}
