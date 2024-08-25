using Common.Application;
using DigiMenu.Application.Products.AddImage;
using DigiMenu.Domain.ProductAgg;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Application.Products.RemoveImage
{
    public class RemoveProductImageCommand : IBaseCommand
    {
        public RemoveProductImageCommand(long imageFile, long productId, int displayOrder)
        {
            ImageId = imageFile;
            ProductId = productId;
            DisplayOrder = displayOrder;
        }

        public long ImageId { get; private set; }
        public long ProductId { get; private set; }
        public int DisplayOrder { get; private set; }
    }
      
}
