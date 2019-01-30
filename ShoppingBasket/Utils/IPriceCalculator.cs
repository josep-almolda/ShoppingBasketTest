using ShoppingBasket.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Utils
{
    public interface IPriceCalculator
    {
        decimal CalculateBasketTotal(List<Product> products);
    }
}
