using Common.Application.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Application.Categories.Create
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator() 
        {
            RuleFor(c => c.title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
            RuleFor(c => c.image).JustImageFile().NotNull().WithMessage(ValidationMessages.required("عکس"));
        }
    }
}
