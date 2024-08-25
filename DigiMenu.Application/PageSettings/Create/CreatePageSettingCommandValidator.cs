using Common.Application.Validation;
using FluentValidation;

namespace DigiMenu.Application.PageSettings.Create
{
    public class CreatePageSettingCommandValidator : AbstractValidator<CreatePageSettingCommand> 
    {
        public CreatePageSettingCommandValidator()
        {
            RuleFor(x => x.pageTitle).NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان صفحه"));
            RuleFor(x => x.backgroundImage).JustImageFile();
            RuleFor(x => x.logoImage).JustImageFile();

        }
    }
}
