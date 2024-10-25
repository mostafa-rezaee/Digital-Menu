using Common.Domain.ValueObjects;

namespace DigiMenu.Api.ViewModels.Product
{
    public class CreateProductViewModel
    {
        public string Title { get; set; }
        public long CategoryId { get; set; }
        public IFormFile Image { get; set; }
        public decimal Price { get; set; }
        public int? LikeCount { get; set; }
        public bool IsVisible { get; set; }
        public string? Description { get; set; }
        public SeoDataViewModel SeoData { get; set; }
    }

    public class EditProductViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long CategoryId { get; set; }
        public IFormFile? Image { get; set; }
        public decimal Price { get; set; }
        public int? LikeCount { get; set; }
        public bool IsVisible { get; set; }
        public string? Description { get; set; }
        public SeoDataViewModel SeoData { get; set; }
    }
}
