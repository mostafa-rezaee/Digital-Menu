using Common.Application.Validation;
using FluentValidation;

namespace DigiMenu.Application.PageSettings.Edit
{
    public class EditPageSettingCommandValidator : AbstractValidator<EditPageSettingCommand>
    {
        public EditPageSettingCommandValidator()
        {
            RuleFor(x => x.pageTitle).NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان صفحه"));
        }
    }
}
