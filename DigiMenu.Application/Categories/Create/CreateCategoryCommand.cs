using Common.Application;
using Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Application.Categories.Create
{
    public  record CreateCategoryCommand(string title, bool isVisible, SeoData seoData) : IBaseCommand;
}
