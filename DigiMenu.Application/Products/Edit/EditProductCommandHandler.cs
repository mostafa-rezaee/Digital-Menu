using Common.Application;
using Common.Application.Utilities.File.Services;
using DigiMenu.Application._Helpers;
using DigiMenu.Domain.ProductAgg.Repositories;
using Microsoft.AspNetCore.Http;

namespace DigiMenu.Application.Products.Edit
{
    public class EditProductCommandHandler : IBaseCommandHandler<EditProductCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IFileService _fileService;

        public EditProductCommandHandler(IProductRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }
        public async Task<OperationResult> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetTrackingAsync(request.id);
            if (product == null)
            {
                return OperationResult.NotFound();
            }
            product.Edit(request.title, request.categoryId, request.price, request.likeCount, request.isVisible,
                request.description, request.seoData);

            string oldImageName = product.ImageName;

            if (request.image != null)
            {
                var imageName = await _fileService.SaveFileAndGenerateName(request.image, Directories.ProductImage);
                product.SetProductImage(imageName);
            }

            await _repository.SaveAsync();
            RemoveOldImage(request.image, oldImageName);
            return OperationResult.Success();
        }

        private void RemoveOldImage(IFormFile? oldImageFile, string oldImageName)
        {
            if (oldImageFile != null)
            {
                _fileService.DeleteFile(Directories.ProductImage, oldImageName);
            }
        }
    }
}
