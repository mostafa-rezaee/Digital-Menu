using Common.Domain;
using Common.Domain.Exceptions;
using DigiMenu.Domain.UserAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Domain.UserAgg
{
    public class User : AggregateRoot
    {
        public User(string firstName, string lastName, string username, string password, IDomainUseService userService)
        {
            HandlePropertiesValidation(username, userService, password);
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public List<UserRole> Roles { get; private set; }

        #region Methods

        public void Edit(string firstName, string lastName, string username, IDomainUseService userService)
        {
            HandlePropertiesValidation(username, userService);
            FirstName = firstName;
            LastName = lastName;
            Username = username;
        }

        public void AddRoles(List<UserRole> roles) 
        {
            roles.ForEach(role => role.UserId = Id);
            Roles.Clear();
            Roles.AddRange(roles);
        }

        public void HandlePropertiesValidation(string username, IDomainUseService userService, string? password = null)
        {
            NullOrEmptyException.CheckNotEmpty(username, nameof(username));
            if (password != null)
            {
                NullOrEmptyException.CheckNotEmpty(password, nameof(password));
            }

            if (username != Username)
            {
                if (userService.IsUsernameExist(username))
                {
                    throw new InvalidDomainDataException("نام کاربری تکراری است");
                }
            }

        }

        public static User RegisterUser(string username, string password, IDomainUseService userService)
        {
            return new User("", "", username, password, userService);
        }


        #endregion
    }
}
