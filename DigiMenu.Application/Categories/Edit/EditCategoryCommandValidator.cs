using Common.Application.Validation;
using FluentValidation;

namespace DigiMenu.Application.Categories.Edit
{
    public class EditCategoryCommandValidator : AbstractValidator<EditCategoryCommand> 
    {
        public EditCategoryCommandValidator()
        {
            RuleFor(c => c.title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
            RuleFor(c => c.image).JustImageFile();
        }
    }

}
