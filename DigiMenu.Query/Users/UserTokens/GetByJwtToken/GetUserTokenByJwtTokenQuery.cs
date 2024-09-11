using Common.Query;
using DigiMenu.Query.Users.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Query.Users.UserTokens.GetByJwtToken
{
    public record GetUserTokenByJwtTokenQuery(string hashedJwtToken) : IQuery<UserTokenDto?>;
}
