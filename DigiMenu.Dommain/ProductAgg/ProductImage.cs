using Common.Domain;
using Common.Domain.Exceptions;

namespace DigiMenu.Domain.ProductAgg
{
    public class ProductImage : BaseEntity
    {
        public ProductImage(string imageName, int order)
        {
            NullOrEmptyException.CheckNotEmpty(imageName, nameof(imageName));
            ImageName = imageName;
            Order = order;
        }

        public long ProductId { get; internal set; }
        public string ImageName { get; private set; }
        public int Order { get; private set; }
    }
}
