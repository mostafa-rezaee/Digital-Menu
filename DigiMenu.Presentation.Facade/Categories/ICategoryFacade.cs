using Common.Application;
using DigiMenu.Application.Categories.Create;
using DigiMenu.Application.Categories.Edit;
using DigiMenu.Application.Categories.Remove;
using DigiMenu.Query.Categories.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Presentation.Facade.Categories
{
    public interface ICategoryFacade
    {
        //Commands
        Task<OperationResult<long>> Create(CreateCategoryCommand command);
        Task<OperationResult> Edit(EditCategoryCommand command);
        Task<OperationResult> Remove(long id);


        //Queries
        Task<CategoryDto?> GetCategoryById(long id);
        Task<List<CategoryDto>> GetCategories();

    }
}
