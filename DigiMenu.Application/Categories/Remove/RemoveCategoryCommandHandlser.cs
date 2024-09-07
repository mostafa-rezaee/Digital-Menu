using Common.Application;
using DigiMenu.Domain.CategoryAgg;

namespace DigiMenu.Application.Categories.Remove
{
    public class RemoveCategoryCommandHandlser : IBaseCommandHandler<RemoveCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public RemoveCategoryCommandHandlser(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<OperationResult> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.Delete(request.id);
            if (result)
            {
                await _categoryRepository.SaveAsync();
                return OperationResult.Success();
            }
            return OperationResult.Error("امکان حذف دسته بندی مورد نظر وجود ندارد");
        }
    }
}
