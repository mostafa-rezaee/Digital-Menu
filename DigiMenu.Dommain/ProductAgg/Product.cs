﻿using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Domain.ProductAgg
{
    public class Product : AggregateRoot
    {
        public Product(string title, long categoryId, string imageName, decimal price, int likeCount, bool isVisible, 
                        string description, SeoData seoData)
        {
            HandleValidating(title, imageName, price, description);

            Title = title;
            CategoryId = categoryId;
            ImageName = imageName;
            Price = price;
            LikeCount = likeCount;
            IsVisible = isVisible;
            Description = description;
            SeoData = seoData;
        }

        public string Title { get; private set; }
        public long CategoryId { get; private set; }
        public string ImageName { get; private set; }
        public decimal Price { get; private set; }
        public int LikeCount { get; private set; }
        public bool IsVisible { get; private set; }
        public string Description { get; private set; }
        public SeoData SeoData { get; private set; }
        public List<ProductImage> ProductImages { get; private set; }

        #region Methods

        public void Edit(string title, long categoryId, string imageName, decimal price, int likeCount, bool isVisible,
                        string description, SeoData seoData)
        {
            HandleValidating(title, imageName, price, description);

            Title = title;
            CategoryId = categoryId;
            ImageName = imageName;
            Price = price;
            LikeCount = likeCount;
            IsVisible = isVisible;
            Description = description;
            SeoData = seoData;
        }

        public void AddImage(ProductImage image)
        {
            image.ProductId = Id;
            ProductImages.Add(image);
        }

        public void RemoveImage(long imageId)
        {
            var image = ProductImages.FirstOrDefault(x => x.Id == imageId);
            if (image == null) return;
            ProductImages.Remove(image);
        }

        public void HandleValidating(string title, string imageName, decimal price, string description)
        {
            NullOrEmptyException.CheckNotEmpty(title, nameof(imageName));
            NullOrEmptyException.CheckNotEmpty(imageName, nameof(imageName));
            NullOrEmptyException.CheckNotEmpty(description, nameof(imageName));
            if (price <= 0)
                throw new InvalidDomainDataException("این مبلغ مجاز نیست");
        }

        #endregion
    }
}
