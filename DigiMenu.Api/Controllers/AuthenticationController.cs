using Common.Application;
using Common.Application.Utilities.Security;
using Common.NetCore;
using DigiMenu.Api.Infrastructure.JWT;
using DigiMenu.Api.ViewModels.UserAuthentication;
using DigiMenu.Application.Users.Register;
using DigiMenu.Presentation.Facade.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigiMenu.Api.Controllers
{
    
    public class AuthenticationController : BaseApiController
    {
        private readonly IUserFacade _userFacade;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IUserFacade userFacade, IConfiguration configuration)
        {
            _userFacade = userFacade;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<ApiResult<string>> LoginUser(LoginUserViewModel viewModel)
        {

            var user = await _userFacade.GetUserByUsername(viewModel.Username);
            if (user == null)
            {
                var result = OperationResult<string>.Error("اطلاعات ورود صحیح نیست");
                return CommandResult(result);
            }
            if (!ShaHasher.Compare(user.Password, viewModel.Password))
            {
                var result = OperationResult<string>.Error("اطلاعات ورود صحیح نیست");
                return CommandResult(result);
            }
            if (!user.IsActive)
            {
                var result = OperationResult<string>.Error("کاربر فعال نیست");
                return CommandResult(result);
            }
            var token = JwtTokenBuilder.BuildToken(user, _configuration);
            return new ApiResult<string> { 
                Data = token,
                IsSuccess = true,
                MetaData = new ()
            };
        }

        [HttpPost("register")]
        public async Task<ApiResult> RegisterUser(RegisterUserViewModel viewModel)
        {
            var command = new RegisterUserCommand(viewModel.Username, ShaHasher.Hash(viewModel.Password));
            var result = await _userFacade.Register(command);
            return CommandResult(result);
        }
    }
}
