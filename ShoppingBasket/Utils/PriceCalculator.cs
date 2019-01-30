using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShoppingBasket.Models;

namespace ShoppingBasket.Utils
{
    public class PriceCalculator : IPriceCalculator
    {
        private Dictionary<ProductType, decimal> _prices;

        public PriceCalculator()
        {
            _prices = new Dictionary<ProductType, decimal>
            {
                { ProductType.Butter, 0.8M },
                { ProductType.Milk, 1.15M },
                { ProductType.Bread, 1.0M }
            };
        }

        private decimal CalculateButterBreadDiscount(int numberOfButters, int numberOfBreads)
        {
            var breadDiscounts = numberOfButters / 2;

            return Math.Min(breadDiscounts, numberOfBreads) * 0.5M;
        }

        private decimal CalculateMilkDiscount(int numberOfMilks)
        {
            var milkDiscounts = numberOfMilks / 4;

            return milkDiscounts * 1.15M;
        }

        public decimal CalculateBasketTotal(List<Product> products)
        {
            var numberOfBreads = products
                .Count(product => product.Type == ProductType.Bread);
            var numberOfButters = products
                .Count(product => product.Type == ProductType.Butter);
            var numberOfMilks = products
                .Count(product => product.Type == ProductType.Milk);

            var basePrice = numberOfBreads * _prices[ProductType.Bread] +
                numberOfButters * _prices[ProductType.Butter] +
                numberOfMilks * _prices[ProductType.Milk];

            var discountsValue =
                CalculateButterBreadDiscount(numberOfButters, numberOfBreads) +
                CalculateMilkDiscount(numberOfMilks);

            return basePrice - discountsValue;
        }
    }
}
