using Common.Application;
using DigiMenu.Domain.CategoryAgg;

namespace DigiMenu.Application.Categories.Edit
{
    public class EditCategoryCommandHandler : IBaseCommandHandler<EditCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;
        public EditCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<OperationResult> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetTrackingAsync(request.Id);
            if (category == null)
            {
                return OperationResult.NotFound();
            }
            category.Edit(request.title, request.isVisible, request.seoData);
            await _categoryRepository.SaveAsync();
            return OperationResult.Success();
        }
    }

}
