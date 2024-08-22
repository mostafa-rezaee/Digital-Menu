using Common.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Application.Products.AddImage
{
    public class AddProductImageCommand : IBaseCommand
    {
        public AddProductImageCommand(IFormFile imageFile, long productId, int displayOrder)
        {
            ImageFile = imageFile;
            ProductId = productId;
            DisplayOrder = displayOrder;
        }

        public IFormFile ImageFile { get; private set; }
        public long ProductId { get; private set; }
        public int DisplayOrder { get; private set; }
    }
}
