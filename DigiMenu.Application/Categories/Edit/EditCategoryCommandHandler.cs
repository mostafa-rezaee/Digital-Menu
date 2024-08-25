using Common.Application;
using Common.Application.Utilities.File.Services;
using DigiMenu.Application._Helpers;
using DigiMenu.Domain.CategoryAgg;
using DigiMenu.Domain.ProductAgg;
using Microsoft.AspNetCore.Http;

namespace DigiMenu.Application.Categories.Edit
{
    public class EditCategoryCommandHandler : IBaseCommandHandler<EditCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IFileService _fileService;
        public EditCategoryCommandHandler(ICategoryRepository categoryRepository, IFileService fileService)
        {
            _categoryRepository = categoryRepository;
            _fileService = fileService;
        }
        public async Task<OperationResult> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetTrackingAsync(request.id);
            if (category == null)
            {
                return OperationResult.NotFound();
            }
            category.Edit(request.title, request.isVisible, request.seoData);

            string oldImageName = category.ImageName;

            if (request.image != null)
            {
                var imageName = await _fileService.SaveFileAndGenerateName(request.image, Directories.CategoryImage);
                category.SetCategoryImage(imageName);
            }

            await _categoryRepository.SaveAsync();
            RemoveOldImage(request.image, oldImageName);
            return OperationResult.Success();
        }

        private void RemoveOldImage(IFormFile imageFile, string oldImageName)
        {
            if (imageFile != null)
            {
                _fileService.DeleteFile(Directories.CategoryImage, oldImageName);
            }
        }
    }

}
