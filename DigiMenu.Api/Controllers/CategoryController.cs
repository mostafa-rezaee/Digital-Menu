using Common.Domain.ValueObjects;
using Common.NetCore;
using DigiMenu.Api.Infrastructure;
using DigiMenu.Api.ViewModels.Category;
using DigiMenu.Application.Categories.Create;
using DigiMenu.Application.Categories.Edit;
using DigiMenu.Application.Categories.Remove;
using DigiMenu.Presentation.Facade.Categories;
using DigiMenu.Query.Categories.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigiMenu.Api.Controllers
{
    //[PermissionCheck(Domain.RoleAgg.Enums.Permissions.ManageCategories)]
    [Authorize]
    public class CategoryController : BaseApiController
    {
        private readonly ICategoryFacade _categoryFacade;

        public CategoryController(ICategoryFacade categoryFacade)
        {
            _categoryFacade = categoryFacade;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ApiResult<List<CategoryDto>>> GetCategories()
        { 
            var result = await _categoryFacade.GetCategories();
            return QueryResult(result);
        }

        [HttpGet("{id}")]
        public async Task<ApiResult<CategoryDto?>> GetCategoryById(long id)
        {
            var result = await _categoryFacade.GetCategoryById(id);
            return QueryResult(result);
        }

        [HttpPost]
        public async Task<ApiResult> CreateCategory([FromForm] CreateCategoryViewModel command)
        {
            var seoData = new SeoData(command.SeoData.MetaDescription, command.SeoData.MetaTitle, 
                command.SeoData.MetaKeywords, command.SeoData.IsIndexed, command.SeoData.Canonicial, command.SeoData.Schema);
            var result = await _categoryFacade.Create(new CreateCategoryCommand(
                command.Title, command.Image,command.IsVisible, seoData));
            //var url = Url.Action("GetCategoryById", "category", new { id = result.Data});
            return CommandResult(result); //, System.Net.HttpStatusCode.Created, url??"");
        }

        [HttpPut]
        public async Task<ApiResult> EditCategory([FromForm] EditCategoryViewModel command)
        {
            var seoData = new SeoData(command.SeoData.MetaDescription, command.SeoData.MetaTitle,
                command.SeoData.MetaKeywords, command.SeoData.IsIndexed, command.SeoData.Canonicial, command.SeoData.Schema);
            var result = await _categoryFacade.Edit(new EditCategoryCommand(
                command.Id, command.Title, command.Image, command.IsVisible, seoData));
            return CommandResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<ApiResult> DeleteCategory(long id)
        {
            var result = await _categoryFacade.Remove(id);
            return CommandResult(result);
        }
    }
}
