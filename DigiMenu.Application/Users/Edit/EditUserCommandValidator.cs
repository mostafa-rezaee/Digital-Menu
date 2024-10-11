using Common.Application.Validation;
using FluentValidation;

namespace DigiMenu.Application.Users.Edit
{
    public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
    {
        public EditUserCommandValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().WithMessage(ValidationMessages.required("نام"));
            RuleFor(x => x.LastName).NotNull().NotEmpty().WithMessage(ValidationMessages.required("نام خانوادگی"));
            RuleFor(x => x.Username).NotNull().NotEmpty().WithMessage(ValidationMessages.required("نام کاربری"));
            RuleFor(x => x.Avatar).JustImageFile();


        }
    }
}
