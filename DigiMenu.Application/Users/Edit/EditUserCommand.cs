using Common.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Application.Users.Edit
{
    public class EditUserCommand : IBaseCommand
    {
        public EditUserCommand(long id, string firstName, string lastName, IFormFile? avatar, string username)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Avatar = avatar;
        }

        public long Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Username { get; private set; }
        public IFormFile? Avatar { get; private set; }
    }
}
