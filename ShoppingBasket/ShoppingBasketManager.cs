using ShoppingBasket.Models;
using System;
using System.Collections.Generic;

namespace ShoppingBasket
{
    public class ShoppingBasketManager
    {
        public List<Product> ProductsList { get; private set; } = new List<Product>();

        public void AddProduct(Product product)
        {
            ProductsList.Add(product);
        }

        public decimal CalculateTotal()
        {
            throw new NotImplementedException();
        }
    }
}
