using Common.Application.Validation;
using FluentValidation;

namespace DigiMenu.Application.Roles.Create
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand> 
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(x => x.title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));

        }
    }
}
