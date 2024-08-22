using Common.Application;
using Common.Application.Utilities.File.Services;
using DigiMenu.Application._Helpers;
using DigiMenu.Application.Products.AddImage;
using DigiMenu.Domain.ProductAgg.Repositories;
using DigiMenu.Domain.ProductAgg;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Application.Products.RemoveImage
{
    public class RemoveProductImageCommand : IBaseCommand
    {
        public RemoveProductImageCommand(long imageFile, long productId, int displayOrder)
        {
            ImageId = imageFile;
            ProductId = productId;
            DisplayOrder = displayOrder;
        }

        public long ImageId { get; private set; }
        public long ProductId { get; private set; }
        public int DisplayOrder { get; private set; }
    }

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
