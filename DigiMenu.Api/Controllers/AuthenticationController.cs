using Common.Application;
using Common.Application.Utilities.Security;
using Common.NetCore;
using DigiMenu.Api.Infrastructure.JWT;
using DigiMenu.Api.ViewModels;
using DigiMenu.Api.ViewModels.UserAuthentication;
using DigiMenu.Application.Users.Register;
using DigiMenu.Presentation.Facade.Users;
using DigiMenu.Query.Users.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UAParser;

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
        public async Task<ApiResult<LoginUserResult?>> LoginUser(LoginUserViewModel viewModel)
        {

            var user = await _userFacade.GetUserByUsername(viewModel.Username);
            if (user == null)
            {
                var result = OperationResult<LoginUserResult>.Error("اطلاعات ورود صحیح نیست");
                return CommandResult(result);
            }
            if (!ShaHasher.Compare(user.Password, viewModel.Password))
            {
                var result = OperationResult<LoginUserResult>.Error("اطلاعات ورود صحیح نیست");
                return CommandResult(result);
            }
            if (!user.IsActive)
            {
                var result = OperationResult<LoginUserResult>.Error("کاربر فعال نیست");
                return CommandResult(result);
            }
            var commandResult = await GenerateUserTokens(user);
            return CommandResult(commandResult);
        }

        [HttpPost("register")]
        public async Task<ApiResult> RegisterUser(RegisterUserViewModel viewModel)
        {
            var command = new RegisterUserCommand(viewModel.Username, ShaHasher.Hash(viewModel.Password));
            var result = await _userFacade.Register(command);
            return CommandResult(result);
        }

        [HttpPost("RefreshToken")]
        public async Task<ApiResult<LoginUserResult?>> RefreshUserToken(string refreshToken)
        {
            var userToken = await _userFacade.GetUserTokenByRefreshToken(refreshToken);
            if (userToken == null) return CommandResult(OperationResult<LoginUserResult?>.NotFound());
            if (userToken.TokenExpireDate > DateTime.Now)
            {
                return CommandResult(OperationResult<LoginUserResult?>.Error("توکن هنوز معتبر است"));
            }
            if (userToken.RefreshTokenExpireDate < DateTime.Now)
            {
                return CommandResult(OperationResult<LoginUserResult?>.Error("توکن نوسازی منقضی شده است"));
            }
            var user = await _userFacade.GetUserById(userToken.UserId);
            if (user == null) return CommandResult(OperationResult<LoginUserResult?>.Error("کاربری با توکن جاری یافت نشد"));
            await _userFacade.RomoveToken(new Application.Users.RemoveToken.RemoveUserTokenComman(userToken.UserId, userToken.Id));
            var commandResult = await GenerateUserTokens(user);
            return CommandResult(commandResult);
        }

        private async Task<OperationResult<LoginUserResult?>> GenerateUserTokens(UserDto user)
        {
            var parser = Parser.GetDefault();
            var info = parser.Parse(HttpContext.Request.Headers["user-agent"]);
            var device = $"{info.Device.Family}/{info.OS.Family} {info.OS.Major}.{info.OS.Minor} - {info.UA.Family}";
            var token = JwtTokenBuilder.BuildToken(user, _configuration);
            var refreshToken = Guid.NewGuid().ToString();

            var hashedToken = ShaHasher.Hash(token);
            var hashedRefreshToken = ShaHasher.Hash(refreshToken);
            var tokenResult = await _userFacade.AddToken(new Application.Users.AddToken.AddUserTokenCommand(user.Id, hashedToken, hashedRefreshToken, DateTime.Now.AddDays(7), DateTime.Now.AddDays(8), device));
            if (tokenResult.Status != OperationResultStatus.Success)
            {
                return OperationResult<LoginUserResult?>.Error();
            }
            return OperationResult<LoginUserResult?>.Success(new LoginUserResult()
            {
                Token = token,
                RefreshToken = refreshToken
            });
        }
    }
}
