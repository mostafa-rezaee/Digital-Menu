using Common.Domain.ValueObjects;
using Common.NetCore;
using DigiMenu.Api.Infrastructure;
using DigiMenu.Api.ViewModels.Product;
using DigiMenu.Application.Categories.Create;
using DigiMenu.Application.Categories.Edit;
using DigiMenu.Application.Products.AddImage;
using DigiMenu.Application.Products.Create;
using DigiMenu.Application.Products.Edit;
using DigiMenu.Application.Products.RemoveImage;
using DigiMenu.Presentation.Facade.Categories;
using DigiMenu.Presentation.Facade.Products;
using DigiMenu.Query.Products.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigiMenu.Api.Controllers
{
    //[PermissionCheck(Domain.RoleAgg.Enums.Permissions.ManageProducts)]
    [Authorize]
    public class ProductController : BaseApiController
    {
        private readonly IProductFacade _productFacade;

        public ProductController(IProductFacade productFacade)
        {
            _productFacade = productFacade;
        }

        [HttpGet]
        public async Task<ApiResult<ProductFilterResult>> GetProducts([FromQuery]ProductFilterParams filterParams)
        {
            var result = await _productFacade.GetProductByFilter(filterParams);
            return QueryResult(result);
        }

        [AllowAnonymous]
        [HttpGet("categoryProducts")]
        public async Task<ApiResult<ProductFilterResult>> GetCategoryProducts(int page, int takeCount, long categoryId)
        {
            var result = await _productFacade.GetProductByFilter(new ProductFilterParams { 
                CategoryId = categoryId,
                PageCount = takeCount,
                PageNumber = page,
                Title = null

            });
            return QueryResult(result);
        }


        [HttpGet("{id}")]
        public async Task<ApiResult<ProductDto?>> GetProduct(long id)
        {
            var result = await _productFacade.GetProductById(id);
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult> CreateProduct([FromForm]CreateProductViewModel command)
        {
            var seoData = new SeoData(command.SeoData.MetaDescription, command.SeoData.MetaTitle,
                command.SeoData.MetaKeywords, command.SeoData.IsIndexed, command.SeoData.Canonicial, command.SeoData.Schema);

            var result = await _productFacade.Create(new CreateProductCommand(command.Title, command.CategoryId, command.Image, command.Price,
                command.LikeCount, command.IsVisible, command.Description, seoData));
            return CommandResult(result);
        }

        [HttpPut]
        public async Task<ApiResult> EditProduct([FromForm]EditProductViewModel command)
        {
            var seoData = new SeoData(command.SeoData.MetaDescription, command.SeoData.MetaTitle,
                command.SeoData.MetaKeywords, command.SeoData.IsIndexed, command.SeoData.Canonicial, command.SeoData.Schema);

            var result = await _productFacade.Edit(new EditProductCommand(command.Id, command.Title, command.CategoryId, command.Image, command.Price,
                command.LikeCount, command.IsVisible, command.Description, seoData));
            return CommandResult(result);
        }

        [HttpPost("image")]
        public async Task<ApiResult> AddProductImage([FromForm] AddProductImageViewModel command)
        {
            var result = await _productFacade.AddImage(new AddProductImageCommand(
                command.ImageFile, 
                command.ProductId, 
                command.DisplayOrder));
            return CommandResult(result);
        }

        [HttpDelete("image")]
        public async Task<ApiResult> RemoveProductImage(RemoveProductImageViewModel command)
        {
            var result = await _productFacade.RemoveImage(new RemoveProductImageCommand(
                command.ImageId,
                command.ProductId,
                command.DisplayOrder));
            return CommandResult(result);
        }

    }
}
