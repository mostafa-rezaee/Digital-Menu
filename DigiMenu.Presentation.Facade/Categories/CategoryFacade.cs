using Common.Application;
using DigiMenu.Application.Categories.Create;
using DigiMenu.Application.Categories.Edit;
using DigiMenu.Query.Categories.DTO;
using DigiMenu.Query.Categories.GetById;
using DigiMenu.Query.Categories.GetList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Presentation.Facade.Categories
{
    internal class CategoryFacade : ICategoryFacade
    {
        private readonly IMediator mediator;

        public CategoryFacade(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<OperationResult> Create(CreateCategoryCommand command)
        {
            return await mediator.Send(command);
        }

        public async Task<OperationResult> Edit(EditCategoryCommand command)
        {
            return await mediator.Send(command);
        }

        public async Task<List<CategoryDto>> GetCategories()
        {
            return await mediator.Send(new GetCategoryListQuery());
        }

        public async Task<CategoryDto?> GetCategoryById(long id)
        {
            return await mediator.Send(new GetCategoryByIdQuery(id));
        }
    }
}
