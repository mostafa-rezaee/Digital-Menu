using Common.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Application.Users.Edit
{
    public record EditUserCommand(long id, string firstName, string lastName, IFormFile? avatar, string username) : IBaseCommand;
}
