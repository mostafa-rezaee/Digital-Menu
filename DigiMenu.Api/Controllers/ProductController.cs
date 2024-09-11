using Common.NetCore;
using DigiMenu.Api.Infrastructure;
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
    [PermissionCheck(Domain.RoleAgg.Enums.Permissions.ManageProducts)]
    public class ProductController : BaseApiController
    {
        private readonly IProductFacade _productFacade;

        public ProductController(IProductFacade productFacade)
        {
            _productFacade = productFacade;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ApiResult<ProductFilterResult>> GetProducts([FromQuery]ProductFilterParams filterParams)
        {
            var result = await _productFacade.GetProductByFilter(filterParams);
            return QueryResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<ProductDto?>> GetProduct(long id)
        {
            var result = await _productFacade.GetProductById(id);
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult> CreateProduct([FromForm]CreateProductCommand command)
        {
            var result = await _productFacade.Create(command);
            return CommandResult(result);
        }

        [HttpPut]
        public async Task<ApiResult> EditProduct([FromForm]EditProductCommand command)
        {
            var result = await _productFacade.Edit(command);
            return CommandResult(result);
        }

        [HttpPost("image")]
        public async Task<ApiResult> AddProductImage([FromForm] AddProductImageCommand command)
        {
            var result = await _productFacade.AddImage(command);
            return CommandResult(result);
        }

        [HttpDelete("image")]
        public async Task<ApiResult> RemoveProductImage(RemoveProductImageCommand command)
        {
            var result = await _productFacade.RemoveImage(command);
            return CommandResult(result);
        }

    }
}
