using Common.Application.Validation;
using FluentValidation;

namespace DigiMenu.Application.Users.Register
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator() 
        {
            RuleFor(x => x.username).NotNull().NotEmpty().WithMessage(ValidationMessages.required("نام کاربری"));
            RuleFor(x => x.password).NotNull().NotEmpty().WithMessage(ValidationMessages.required("رمز عبور"))
                .MinimumLength(6).WithMessage(ValidationMessages.minLength("رمز عبور", 6));

        }
    }
}
