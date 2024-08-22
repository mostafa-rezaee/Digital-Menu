using Common.Application.Validation;
using FluentValidation;

namespace DigiMenu.Application.Products.AddImage
{
    public class AddProductImageCommandValidator : AbstractValidator<AddProductImageCommand> 
    {
        public AddProductImageCommandValidator()
        {
            RuleFor(x => x.ImageFile).NotNull().WithMessage(ValidationMessages.required("تصویر"))
                .JustImageFile();

            RuleFor(x => x.DisplayOrder).GreaterThanOrEqualTo(0);
        }
    }
}
