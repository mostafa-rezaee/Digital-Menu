using Common.NetCore;
using Common.NetCore.Utilities;
using DigiMenu.Api.ViewModels.User;
using DigiMenu.Application.Products.Create;
using DigiMenu.Application.Products.Edit;
using DigiMenu.Application.Users.Create;
using DigiMenu.Application.Users.Edit;
using DigiMenu.Presentation.Facade.Products;
using DigiMenu.Presentation.Facade.Users;
using DigiMenu.Query.Users.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigiMenu.Api.Controllers
{

    public class UserController : BaseApiController
    {
        private readonly IUserFacade _userFacade;

        public UserController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        [HttpGet]
        public async Task<ApiResult<UserFilterResult>> GetUsersByFilter([FromQuery]UserFilterParams filterParams)
        {
            var result = await _userFacade.GetUserByFilter(filterParams);
            return QueryResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<UserDto?>> GetUserById(long id)
        {
            var result = await _userFacade.GetUserById(id);
            return QueryResult(result);
        }

        [HttpGet("uu/{username}")]
        public async Task<ApiResult<UserDto?>> GetUserByUsername(string username)
        {
            var result = await _userFacade.GetUserByUsername(username);
            return QueryResult(result);
        }

        [HttpGet("Current")]
        public async Task<ApiResult<UserDto?>> GetCurrentUser()
        {
            var result = await _userFacade.GetUserById(User.GetUserId());
            return QueryResult(result);
        }

        [HttpPut("ChangePassword")]
        public async Task<ApiResult> ChangePassword(ChangePasswordViewModel command)
        {
            var changePasswordModel = new Application.Users.ChangePassword.ChangeUserPasswordCommand{ 
                UserId = User.GetUserId(),
                Password = command.Password,
                CurrentPassword = command.CurrentPassword,
            };
            var result = await _userFacade.ChangePassword(changePasswordModel);
            return CommandResult(result);
        }

        [HttpPost]
        public async Task<ApiResult> CreateUser(CreateUserCommand command)
        {
            var result = await _userFacade.Create(command);
            return CommandResult(result);
        }

        [HttpPut]
        public async Task<ApiResult> EditUser([FromForm] EditUserCommand command)
        {
            var result = await _userFacade.Edit(command);
            return CommandResult(result);
        }

    }
}
