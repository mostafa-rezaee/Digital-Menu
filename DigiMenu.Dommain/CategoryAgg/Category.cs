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
        public Category(string title, bool isVisible, SeoData seoData)
        {
            NullOrEmptyException.CheckNotEmpty(title, nameof(title));
            Title = title;
            IsVisible = isVisible;
            SeoData = seoData;
        }

        public string Title { get; private set; }
        public bool IsVisible { get; private set; }
        public SeoData SeoData { get; private set; }

        #region Methods
        public void Edit(string title, bool isVisible, SeoData seoData)
        {
            NullOrEmptyException.CheckNotEmpty(title, nameof(title));
            Title = title;
            IsVisible = isVisible;
            SeoData = seoData;
        }

        #endregion
    }
}
