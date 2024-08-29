using Common.Application;
using DigiMenu.Application.Products.AddImage;
using DigiMenu.Application.Products.Create;
using DigiMenu.Application.Products.Edit;
using DigiMenu.Application.Products.RemoveImage;
using DigiMenu.Query.Products.DTO;
using DigiMenu.Query.Products.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Presentation.Facade.Products
{
    public interface IProductFacade
    {
        //Commands
        Task<OperationResult> AddImage(AddProductImageCommand command);
        Task<OperationResult> RemoveImage(RemoveProductImageCommand command);
        Task<OperationResult> Create(CreateProductCommand command);
        Task<OperationResult> Edit(EditProductCommand command);


        //Queries
        Task<ProductDto?> GetProductById(long id);
        Task<ProductFilterResult> GetProductByFilter(ProductFilterParams filterParams);
    }
}
