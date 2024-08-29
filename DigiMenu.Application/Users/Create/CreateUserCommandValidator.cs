using Common.Application.Validation;
using FluentValidation;

namespace DigiMenu.Application.Users.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().WithMessage(ValidationMessages.required("نام"));
            RuleFor(x => x.LastName).NotNull().NotEmpty().WithMessage(ValidationMessages.required("نام خانوادگی"));
            RuleFor(x => x.Username).NotNull().NotEmpty().WithMessage(ValidationMessages.required("نام کاربری"));
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage(ValidationMessages.required("رمز عبور"));
            RuleFor(x => x.Password).MinimumLength(6).WithMessage(ValidationMessages.required("رمز عبور باید حداقل 6 کاراکتر باشد"));

        }
    }
}
