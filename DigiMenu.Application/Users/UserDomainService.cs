using DigiMenu.Domain.UserAgg.Repositories;
using DigiMenu.Domain.UserAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Application.Users
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUserRepository _userRepository;

        public UserDomainService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool IsUsernameExist(string username)
        {
           return _userRepository.IsExist(x => x.Username == username);
        }
    }
}
