using Common.Query;

namespace DigiMenu.Query.Products.DTO
{
    public class ProductFilterParams : BaseFilterParam
    {
        public long? Id { get; set; }
        public string? Title { get; set; }
        public long? CategoryId { get; set; }
    }
}
