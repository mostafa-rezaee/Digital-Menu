using Common.Application;
using DigiMenu.Domain.CategoryAgg;

namespace DigiMenu.Application.Categories.Create
{
    public class CreateCategoryCommandHandler : IBaseCommandHandler<CreateCategoryCommand>
    {
        private readonly ICategoryRepository _repository;

        public CreateCategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category(request.title, request.isVisible, request.seoData);
            await _repository.AddAsync(category);
            await _repository.SaveAsync();

            return OperationResult.Success();
        }
    }
}
