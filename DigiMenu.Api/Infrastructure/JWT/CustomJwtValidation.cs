using Common.NetCore.Utilities;
using DigiMenu.Presentation.Facade.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace DigiMenu.Api.Infrastructure.JWT
{
    public class CustomJwtValidation
    {
        private readonly IUserFacade _userFacade;

        public CustomJwtValidation(IUserFacade facade)
        {
            _userFacade = facade;
        }

        public async Task Validate(TokenValidatedContext context)
        {
            if (context.Principal == null)
            {
                context.Fail("Principal not found");
                return;
            }
            var userId = context.Principal.GetUserId();
            var jwtToken = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var token = await _userFacade.GetUserTokenByJwtToken(jwtToken);
            if (token == null)
            {
                context.Fail("Token not found");
                return;
            }

            var user = await _userFacade.GetUserById(userId);
            if (user == null || user.IsActive == false)
            {
                context.Fail("User is not active");
                return;
            }
        }
    }
}
