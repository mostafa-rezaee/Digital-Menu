namespace DigiMenu.Api.ViewModels.Product
{
    public class AddProductImageViewModel
    {
        public IFormFile ImageFile { get; set; }
        public long ProductId { get; set; }
        public int DisplayOrder { get; set; }
    }

    public class RemoveProductImageViewModel
    {
        public long ImageId { get; set; }
        public long ProductId { get; set; }
        public int DisplayOrder { get; set; }
    }
}
