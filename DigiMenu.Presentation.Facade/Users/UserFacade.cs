using Common.Application;
using DigiMenu.Application.Users.AddToken;
using DigiMenu.Application.Users.ChangePassword;
using DigiMenu.Application.Users.Create;
using DigiMenu.Application.Users.Edit;
using DigiMenu.Application.Users.Register;
using DigiMenu.Query.Users.DTO;
using DigiMenu.Query.Users.GetByFilter;
using DigiMenu.Query.Users.GetById;
using DigiMenu.Query.Users.GetByUsername;
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

        public async Task<OperationResult> ChangePassword(ChangeUserPasswordCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> AddTokens(AddUserTokenCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
