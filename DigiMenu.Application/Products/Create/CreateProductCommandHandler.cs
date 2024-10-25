using Common.Application;
using Common.Application.Utilities.File.Services;
using DigiMenu.Application._Helpers;
using DigiMenu.Domain.ProductAgg;
using DigiMenu.Domain.ProductAgg.Repositories;

namespace DigiMenu.Application.Products.Create
{
    public class CreateProductCommandHandler : IBaseCommandHandler<CreateProductCommand>
    {
        private readonly IProductRepository _repository;
        private readonly IFileService _fileService;

        public CreateProductCommandHandler(IProductRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            string imageName = await _fileService.SaveFileAndGenerateName(request.Image, Directories.ProductImage);
            var product = new Product(request.Title, request.CategoryId, imageName, request.Price, request.LikeCount, request.IsVisible,
                request.Description, request.SeoData/*, request.specifications*/);

            await _repository.AddAsync(product);

            //var specifications = new List<ProductSpecification>();
            //request.Specifications.ToList().ForEach(specification =>
            //{
            //    specifications.Add(new ProductSpecification(specification.Key, specification.Value));
            //});

            //product.SetSpecification(specifications);

            await _repository.SaveAsync();
            return OperationResult.Success();
        }
    }
}
