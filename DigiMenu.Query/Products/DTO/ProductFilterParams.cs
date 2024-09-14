using Common.Query;

namespace DigiMenu.Query.Products.DTO
{
    public class ProductFilterParams : BaseFilterParam
    {
        public string? Title { get; set; }
        public long? CategoryId { get; set; }
    }
}
