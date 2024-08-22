using Common.Domain;
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
            NullOrEmptyException.CheckNotEmpty(imageName, nameof(imageName));
            HandleValidating(title, price, description);

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

        //When we have any product specification
        //public List<ProductSpecification> ProductSpecification { get; private set; }

        #region Methods

        public void Edit(string title, long categoryId, decimal price, int likeCount, bool isVisible,
                        string description, SeoData seoData)
        {
            HandleValidating(title, price, description);

            Title = title;
            CategoryId = categoryId;
            Price = price;
            LikeCount = likeCount;
            IsVisible = isVisible;
            Description = description;
            SeoData = seoData;
        }

        public void SetProductImage(string imageName)
        {
            NullOrEmptyException.CheckNotEmpty(imageName, nameof(imageName));
            ImageName = imageName;
        }

        public void AddImage(ProductImage image)
        {
            image.ProductId = Id;
            ProductImages.Add(image);
        }

        public string RemoveImage(long imageId)
        {
            var image = ProductImages.FirstOrDefault(x => x.Id == imageId);
            if (image == null) throw new NullOrEmptyException("تصویر یافت نشد");
            ProductImages.Remove(image);
            return image.ImageName;
        }

        private void HandleValidating(string title, decimal price, string description)
        {
            NullOrEmptyException.CheckNotEmpty(title, nameof(title));
            NullOrEmptyException.CheckNotEmpty(description, nameof(description));
            if (price <= 0)
                throw new InvalidDomainDataException("این مبلغ مجاز نیست");
        }

        #endregion
    }
}
