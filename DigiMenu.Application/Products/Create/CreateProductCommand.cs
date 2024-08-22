using Common.Application;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Application.Products.Create
{
    public record CreateProductCommand(string title, long categoryId, IFormFile image, decimal price, int likeCount, bool isVisible,
                        string description, SeoData seoData/*, Dictionary<string,string> specifications*/) : IBaseCommand;
}
