using Common.Application;
using Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Application.Categories.Edit
{
    public record EditCategoryCommand(long Id, string title, bool isVisible, SeoData seoData) : IBaseCommand;

}
