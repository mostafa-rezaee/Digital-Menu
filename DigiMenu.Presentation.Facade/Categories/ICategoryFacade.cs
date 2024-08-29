using Common.Application;
using DigiMenu.Application.Categories.Create;
using DigiMenu.Application.Categories.Edit;
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
        Task<OperationResult> Create(CreateCategoryCommand command);
        Task<OperationResult> Edit(EditCategoryCommand command);


        //Queries
        Task<CategoryDto?> GetCategoryById(long id);
        Task<List<CategoryDto>> GetCategories();

    }
}
