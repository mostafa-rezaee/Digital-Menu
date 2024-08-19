using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Domain.Entities.Users
{
    public class User
    {
        public User(string name, string username, string password, bool isAdmin)
        {
            Name = name;
            Username = username;
            Password = password;
            IsAdmin = isAdmin;
        }

        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Username { get; private set; }
        public string Password { get; private set; }
        public bool IsAdmin { get; private set; } = false;

    }
}
