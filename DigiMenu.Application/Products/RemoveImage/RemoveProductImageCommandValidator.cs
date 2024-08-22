﻿using Common.Application.Validation;
using FluentValidation;

namespace DigiMenu.Application.Products.RemoveImage
{
    public class RemoveProductImageCommandValidator : AbstractValidator<RemoveProductImageCommand>
    {
        public RemoveProductImageCommandValidator()
        {
            RuleFor(x => x.ImageFile).NotNull().WithMessage(ValidationMessages.required("تصویر"))
                .JustImageFile();

            RuleFor(x => x.DisplayOrder).GreaterThanOrEqualTo(0);
        }
    }
      
}