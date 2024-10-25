﻿using Common.Application.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DigiMenu.Api.ViewModels.User
{
    public class EditUserViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public IFormFile? Avatar { get; set; }
    }
}
