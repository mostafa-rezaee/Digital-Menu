using Common.Application.Validation;
using FluentValidation;

namespace DigiMenu.Application.Products.Create
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
            RuleFor(x => x.price).NotNull().WithMessage(ValidationMessages.required("قیمت"))
                .GreaterThanOrEqualTo(0); ;
            RuleFor(x => x.image).JustImageFile();

        }
    }
}
