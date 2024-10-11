using Common.Application.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DigiMenu.Api.ViewModels.User
{
    public class EditUserViewModel
    {
        [DisplayName("نام")]
        public string FirstName { get; set; }

        [DisplayName("نام خانوادگی")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string LastName { get; set; }

        [DisplayName("نام کاربری")]
        [Required(ErrorMessage = "{0} را وارد کنید")]
        public string Username { get; set; }

        [DisplayName("نصویر پروفایل")]
        [FileImage(ErrorMessage = "{0} معتبر نیست")]
        public IFormFile? Avatar { get; set; }
    }
}
