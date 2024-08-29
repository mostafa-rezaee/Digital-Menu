using Common.Application;
using DigiMenu.Application.Products.AddImage;
using DigiMenu.Application.Products.Create;
using DigiMenu.Application.Products.Edit;
using DigiMenu.Application.Products.RemoveImage;
using DigiMenu.Query.Products.DTO;
using DigiMenu.Query.Products.GetByFilter;
using DigiMenu.Query.Products.GetById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DigiMenu.Presentation.Facade.Products
{
    internal class ProductFacade : IProductFacade
    {
        private readonly IMediator mediator;

        public ProductFacade(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task<OperationResult> AddImage(AddProductImageCommand command)
        {
            return await mediator.Send(command);
        }

        public async Task<OperationResult> Create(CreateProductCommand command)
        {
            return await mediator.Send(command);
        }

        public async Task<OperationResult> Edit(EditProductCommand command)
        {
            return await mediator.Send(command);
        }

        public async Task<ProductFilterResult> GetProductByFilter(ProductFilterParams filterParams)
        {
            return await mediator.Send(new GetProductByFilterQuery(filterParams));
        }

        public async Task<ProductDto?> GetProductById(long id)
        {
            return await mediator.Send(new GetProductByIdQuery(id));
        }

        public Task<OperationResult> RemoveImage(RemoveProductImageCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
