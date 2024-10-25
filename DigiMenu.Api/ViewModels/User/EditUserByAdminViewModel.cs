using Common.Application.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DigiMenu.Api.ViewModels.User
{
    public class EditUserByAdminViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public IFormFile? AvatarImage { get; set; }

        public bool IsActive { get; set; }
    }
}
