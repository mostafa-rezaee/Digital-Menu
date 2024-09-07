using System.ComponentModel.DataAnnotations;

namespace DigiMenu.Api.ViewModels.UserAuthentication
{
    public class RegisterUserViewModel
    {
        [Required(ErrorMessage = "نام کاربری الزامیست")]
        public string Username { get; set; }

        [Required(ErrorMessage = "وارد کردن رمزعبور الزامیست")]
        [MinLength(6, ErrorMessage = "طول رمزعبور باید حداقل 6 کارکتر باشد")]
        public string Password { get; set; }

        [Required(ErrorMessage = "وارد کردن رمزعبور الزامیست")]
        [MinLength(6, ErrorMessage = "طول رمزعبور باید حداقل 6 کارکتر باشد")]
        [Compare(nameof(Password), ErrorMessage = "رمزعبور و تکرار آن باید یکسان باشند")]
        public string ConfirmPassword { get; set; }

    }
}
