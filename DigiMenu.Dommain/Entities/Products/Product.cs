using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiMenu.Domain.Entities.Products
{
    public class Product
    {
        public Product(string name, decimal price, string description)
        {
            Name = name;
            Price = price;
            Description = description;
        }

        public long Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public decimal Price { get; private set; } = decimal.Zero;
        public string Description { get; private set; }



    }
}
