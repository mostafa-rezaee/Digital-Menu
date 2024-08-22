using Common.Application;
using Common.Application.Utilities.File.Services;
using DigiMenu.Application._Helpers;
using DigiMenu.Domain.ProductAgg;
using DigiMenu.Domain.ProductAgg.Repositories;

namespace DigiMenu.Application.Products.AddImage
{
    public class AddProductImageCommandHandler : IBaseCommandHandler<AddProductImageCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IFileService _fileService;

        public AddProductImageCommandHandler(IProductRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(AddProductImageCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetTrackingAsync(request.ProductId);
            if (product == null) return OperationResult.NotFound();

            var imageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.ProductImageGallery);
            var productImage = new ProductImage(imageName, request.DisplayOrder);
            product.AddImage(productImage);
            await _repository.SaveAsync();
            return OperationResult.Success();
        }
    }
}
