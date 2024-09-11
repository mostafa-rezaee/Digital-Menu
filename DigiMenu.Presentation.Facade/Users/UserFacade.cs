using Common.Application;
using Common.Application.Utilities.Security;
using DigiMenu.Application.Users.AddToken;
using DigiMenu.Application.Users.ChangePassword;
using DigiMenu.Application.Users.Create;
using DigiMenu.Application.Users.Edit;
using DigiMenu.Application.Users.Register;
using DigiMenu.Application.Users.RemoveToken;
using DigiMenu.Query.Users.DTO;
using DigiMenu.Query.Users.GetByFilter;
using DigiMenu.Query.Users.GetById;
using DigiMenu.Query.Users.GetByUsername;
using DigiMenu.Query.Users.UserTokens;
using DigiMenu.Query.Users.UserTokens.GetByJwtToken;
using DigiMenu.Query.Users.UserTokens.GetByRefreshToken;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DigiMenu.Presentation.Facade.Users
{
    internal class UserFacade : IUserFacade
    {
        private readonly IMediator _mediator;

        public UserFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> Create(CreateUserCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> Edit(EditUserCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> Register(RegisterUserCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<UserFilterResult> GetUserByFilter(UserFilterParams filterParams)
        {
            return await _mediator.Send(new GetUserByFilterQuery(filterParams));
        }

        public async Task<UserDto?> GetUserById(long id)
        {
            return await _mediator.Send(new GetUserByIdQuery(id));
        }

        public async Task<UserDto?> GetUserByUsername(string username)
        {
            return await _mediator.Send(new GetUserByUsernameQuery(username));
        }

        public async Task<UserTokenDto?> GetUserTokenByRefreshToken(string refreshToken)
        {
            var hashedRefreshToken = ShaHasher.Hash(refreshToken);
            return await _mediator.Send(new GetUserTokenByRefreshTokenQuery(hashedRefreshToken));
        }

        public async Task<UserTokenDto?> GetUserTokenByJwtToken(string jwtToken)
        {
            var hashedJwtToken = ShaHasher.Hash(jwtToken);
            return await _mediator.Send(new GetUserTokenByJwtTokenQuery(hashedJwtToken));
        }

        public async Task<OperationResult> ChangePassword(ChangeUserPasswordCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> AddToken(AddUserTokenCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> RomoveToken(RemoveUserTokenComman command)
        {
            return await _mediator.Send(command);
        }

        
    }
}
