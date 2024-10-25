using Common.Application.Validation;
using FluentValidation;

namespace DigiMenu.Application.Products.Create
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
            RuleFor(x => x.Price).NotNull().WithMessage(ValidationMessages.required("قیمت"))
                .GreaterThanOrEqualTo(0); ;
            RuleFor(x => x.Image).JustImageFile();

        }
    }
}
