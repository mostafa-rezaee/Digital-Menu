﻿using Common.NetCore;
using Common.NetCore.Utilities;
using DigiMenu.Api.Infrastructure;
using DigiMenu.Api.ViewModels.User;
using DigiMenu.Application.Products.Create;
using DigiMenu.Application.Products.Edit;
using DigiMenu.Application.Users.Create;
using DigiMenu.Application.Users.Edit;
using DigiMenu.Presentation.Facade.Products;
using DigiMenu.Presentation.Facade.Users;
using DigiMenu.Query.Users.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigiMenu.Api.Controllers
{
    [Authorize]
    public class UserController : BaseApiController
    {
        private readonly IUserFacade _userFacade;

        public UserController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        [HttpGet]
        [PermissionCheck(Domain.RoleAgg.Enums.Permissions.ManageUsers)]
        public async Task<ApiResult<UserFilterResult>> GetUsers([FromQuery]UserFilterParams filterParams)
        {
            var result = await _userFacade.GetUserByFilter(filterParams);
            return QueryResult(result);
        }

        [HttpGet("{id}")]
        [PermissionCheck(Domain.RoleAgg.Enums.Permissions.ManageUsers)]
        public async Task<ApiResult<UserDto?>> GetUserById(long id)
        {
            var result = await _userFacade.GetUserById(id);
            return QueryResult(result);
        }

        [HttpGet("ubun/{username}")]
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
        [PermissionCheck(Domain.RoleAgg.Enums.Permissions.ManageUsers)]
        public async Task<ApiResult> CreateUser(CreateUserCommand command)
        {
            var result = await _userFacade.Create(command);
            return CommandResult(result);
        }

        [HttpPut]
        [PermissionCheck(Domain.RoleAgg.Enums.Permissions.ManageUsers)]
        public async Task<ApiResult> Edit([FromForm] EditUserCommand command)
        {
            var result = await _userFacade.Edit(command);
            return CommandResult(result);
        }

        [HttpPut("Current")]
        public async Task<ApiResult> EditUser([FromForm] EditUserViewModel command)
        {
            var result = await _userFacade.Edit(new EditUserCommand(
                User.GetUserId(),
                command.FirstName,
                command.LastName,
                command.Avatar,
                command.Username));
            return CommandResult(result);
        }

    }
}
