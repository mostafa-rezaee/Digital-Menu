using Common.Application;
using Common.Application.Utilities.File.Services;
using DigiMenu.Application._Helpers;
using DigiMenu.Domain.ProductAgg.Repositories;

namespace DigiMenu.Application.Products.RemoveImage
{
    public class RemoveProductImageCommandHandler : IBaseCommandHandler<RemoveProductImageCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IFileService _fileService;

        public RemoveProductImageCommandHandler(IProductRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(RemoveProductImageCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetTrackingAsync(request.ProductId);
            if (product == null) return OperationResult.NotFound();

            var imageName = product.RemoveImage(request.ImageId);
            _fileService.DeleteFile(Directories.ProductImageGallery, imageName);
            await _repository.SaveAsync();
            return OperationResult.Success();
        }
    }
      
}
