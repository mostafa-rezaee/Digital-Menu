using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Domain.CategoryAgg
{
    public class Category : AggregateRoot
    {
        private Category() { }
        public Category(string title, string imageName, bool isVisible, SeoData seoData)
        {
            NullOrEmptyException.CheckNotEmpty(title, nameof(title));
            Title = title;
            ImageName = imageName;
            IsVisible = isVisible;
            SeoData = seoData;
        }

        public string Title { get; private set; }
        public string ImageName { get; private set; }

        public bool IsVisible { get; private set; } = true;
        public SeoData SeoData { get; private set; }

        #region Methods
        public void Edit(string title, bool isVisible, SeoData seoData)
        {
            NullOrEmptyException.CheckNotEmpty(title, nameof(title));
            Title = title;
            IsVisible = isVisible;
            SeoData = seoData;
        }

        public void SetCategoryImage(string imageName)
        {
            NullOrEmptyException.CheckNotEmpty(imageName, nameof(imageName));
            ImageName = imageName;
        }

        #endregion
    }
}
