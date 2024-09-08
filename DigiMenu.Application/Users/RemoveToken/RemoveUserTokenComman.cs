using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Application.Users.RemoveToken
{
    public record RemoveUserTokenComman(long userId, long tokenId) : IBaseCommand;
}
