using Common.Application;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Application.Categories.Create
{
    public class CreateCategoryCommand : IBaseCommand
    {
        public CreateCategoryCommand(string title, IFormFile image, bool isVisible, SeoData seoData)
        {
            Title = title;
            Image = image;
            IsVisible = isVisible;
            SeoData = seoData;
        }

        public string Title { get; private set; }
        public IFormFile Image { get; private set; }

        public bool IsVisible { get; private set; } = true;
        public SeoData SeoData { get; private set; }
    }
}
