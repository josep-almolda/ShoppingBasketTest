using ShoppingBasket.Models;
using ShoppingBasket.Utils;
using System;
using System.Collections.Generic;

namespace ShoppingBasket
{
    public class ShoppingBasketManager
    {
        public List<Product> ProductsList { get; private set; } = new List<Product>();

        IPriceCalculator _priceCalculator;

        public ShoppingBasketManager(IPriceCalculator priceCalculator)
        {
            _priceCalculator = priceCalculator;
        }

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
