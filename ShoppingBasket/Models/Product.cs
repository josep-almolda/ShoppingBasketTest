using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Models
{
    public class Product
    {
        public ProductType Type { get; }

        public Product(ProductType type)
        {
            Type = type;
        }
    }
}
