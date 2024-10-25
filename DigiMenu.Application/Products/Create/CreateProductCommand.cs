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
    public class CreateProductCommand : IBaseCommand
    {
        public CreateProductCommand()
        {
            
        }
        public CreateProductCommand(string title, long categoryId, IFormFile image, decimal price, int? likeCount, bool isVisible,
                            string description, SeoData seoData/*, Dictionary<string,string> specifications*/)
        { 
            Title = title;
            CategoryId = categoryId;
            Image = image;
            Price = price;
            LikeCount = likeCount;
            IsVisible = isVisible;
            Description = description;
            SeoData = seoData;
        }

        public string Title { get; private set; }
        public long CategoryId { get; private set; }
        public IFormFile Image { get; private set; }
        public decimal Price { get; private set; }
        public int? LikeCount { get; private set; }
        public bool IsVisible { get; private set; }
        public string? Description { get; private set; }
        public SeoData SeoData { get; private set; }
    }
}
