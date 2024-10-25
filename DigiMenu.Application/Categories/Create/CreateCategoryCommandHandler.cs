using Common.Application;
using Common.Application.Utilities.File.Services;
using DigiMenu.Application._Helpers;
using DigiMenu.Domain.CategoryAgg;

namespace DigiMenu.Application.Categories.Create
{
    public class CreateCategoryCommandHandler : IBaseCommandHandler<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _repository;
        private readonly IFileService _fileService;

        public CreateCategoryCommandHandler(ICategoryRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            string imageName = await _fileService.SaveFileAndGenerateName(request.Image, Directories.CategoryImage);
            var category = new Category(request.Title, imageName, request.IsVisible, request.SeoData);
            await _repository.AddAsync(category);
            await _repository.SaveAsync();

            return OperationResult.Success();
        }
    }
}
