using Common.Application.Validation;
using FluentValidation;

namespace DigiMenu.Application.Users.Edit
{
    public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
    {
        public EditUserCommandValidator()
        {
            RuleFor(x => x.firstName).NotNull().NotEmpty().WithMessage(ValidationMessages.required("نام"));
            RuleFor(x => x.lastName).NotNull().NotEmpty().WithMessage(ValidationMessages.required("نام خانوادگی"));
            RuleFor(x => x.username).NotNull().NotEmpty().WithMessage(ValidationMessages.required("نام کاربری"));
            RuleFor(x => x.password).MinimumLength(6).WithMessage(ValidationMessages.required("رمز عبور باید حداقل 6 کاراکتر باشد"));
            RuleFor(x => x.avatar).JustImageFile();


        }
    }
}
