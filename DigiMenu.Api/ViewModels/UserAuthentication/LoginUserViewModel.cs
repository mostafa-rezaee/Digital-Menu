using System.ComponentModel.DataAnnotations;

namespace DigiMenu.Api.ViewModels.UserAuthentication
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage = "نام کاربری الزامیست")]
        public string Username { get; set; }

        [Required(ErrorMessage = "وارد کردن رمزعبور الزامیست")]
        public string Password { get; set; }
    }
}
