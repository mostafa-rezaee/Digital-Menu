using Common.Application.Validation;
using FluentValidation;

namespace DigiMenu.Application.Products.Edit
{
    public class EditProductCommandValidator : AbstractValidator<EditProductCommand>
    {
        public EditProductCommandValidator()
        {
            RuleFor(x => x.title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
            RuleFor(x => x.price).NotNull().WithMessage(ValidationMessages.required("قیمت"));
            RuleFor(x => x.image).JustImageFile();
        }
    }
}
