﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Domain.UserAgg.Services
{
    public interface IUserDomainService
    {
        public bool IsUsernameExist(string username);
    }
}
