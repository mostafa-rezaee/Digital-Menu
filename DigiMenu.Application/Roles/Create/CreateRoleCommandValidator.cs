using Common.Application.Validation;
using FluentValidation;

namespace DigiMenu.Application.Roles.Create
{
    public class EditRoleCommandValidator : AbstractValidator<EditRoleCommand> 
    {
        public EditRoleCommandValidator()
        {
            RuleFor(x => x.title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

        }
    }
}
