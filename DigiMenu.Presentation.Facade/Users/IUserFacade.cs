using Common.Application;
using DigiMenu.Application.Users.Create;
using DigiMenu.Application.Users.Edit;
using DigiMenu.Application.Users.Register;
using DigiMenu.Application.Users.ChangePassword;
using DigiMenu.Query.Users.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigiMenu.Application.Users.AddToken;

namespace DigiMenu.Presentation.Facade.Users
{
    public interface IUserFacade
    {
        //commands
        Task<OperationResult> Create(CreateUserCommand command);
        Task<OperationResult> Edit(EditUserCommand command);
        Task<OperationResult> Register(RegisterUserCommand command);
        Task<OperationResult> ChangePassword(ChangeUserPasswordCommand command);
        Task<OperationResult> AddTokens(AddUserTokenCommand command);

        //Queries
        Task<UserDto?> GetUserById(long id);
        Task<UserDto?> GetUserByUsername(string username);
        Task<UserFilterResult> GetUserByFilter(UserFilterParams filterParams);
    }
}
