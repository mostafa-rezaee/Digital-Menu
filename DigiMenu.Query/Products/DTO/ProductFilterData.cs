using Common.Query;

namespace DigiMenu.Query.Products.DTO
{
    public class ProductFilterData : BaseDto
    {
        public string Title { get; set; }
        public string ImageName { get; set; }
        public decimal Price { get; set; }
        public int LikeCount { get; set; }
        public string Description { get; set; }
    }
}
