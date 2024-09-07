using Common.NetCore;
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
    [Authorize]
    public class CategoryController : BaseApiController
    {
        private readonly ICategoryFacade _categoryFacade;

        public CategoryController(ICategoryFacade categoryFacade)
        {
            _categoryFacade = categoryFacade;
        }

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
        public async Task<ApiResult<long>> CreateCategory([FromForm] CreateCategoryCommand command)
        {
            var result = await _categoryFacade.Create(command);
            var url = Url.Action("GetCategoryById", "category", new { id = result.Data});
            return CommandResult(result, System.Net.HttpStatusCode.Created, url??"");
        }

        [HttpPut]
        public async Task<ApiResult> EditCategory([FromForm] EditCategoryCommand command)
        {
            var result = await _categoryFacade.Edit(command);
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
