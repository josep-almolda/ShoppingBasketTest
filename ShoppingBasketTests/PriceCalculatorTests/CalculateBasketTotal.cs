using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using ShoppingBasket.Models;
using ShoppingBasket.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasketTests.PriceCalculatorTests
{
    [TestClass]
    public class CalculateBasketTotal
    {
        [TestMethod]
        public void BasketWith1ButterReturns080()
        {
            // Arrange
            var systemUnderTest = new PriceCalculator();

            // Act
            var result = systemUnderTest.CalculateBasketTotal(new List<Product>
            {
                new Product(ProductType.Butter)
            });

            // Assert
            Check.That(result).Equals(0.80M);
        }

        [TestMethod]
        public void BasketWith1BreadReturns100()
        {
            // Arrange
            var systemUnderTest = new PriceCalculator();

            // Act
            var result = systemUnderTest.CalculateBasketTotal(new List<Product>
            {
                new Product(ProductType.Bread)
            });

            // Assert
            Check.That(result).Equals(1.0M);
        }

        [TestMethod]
        public void BasketWith1MilkReturns115()
        {
            // Arrange
            var systemUnderTest = new PriceCalculator();

            // Act
            var result = systemUnderTest.CalculateBasketTotal(new List<Product>
            {
                new Product(ProductType.Milk)
            });

            // Assert
            Check.That(result).Equals(1.15M);
        }

        [TestMethod]
        public void BasketWith3DifferentProductsReturnsSum()
        {
            // Arrange
            var systemUnderTest = new PriceCalculator();

            // Act
            var result = systemUnderTest.CalculateBasketTotal(new List<Product>
            {
                new Product(ProductType.Butter),
                new Product(ProductType.Milk),
                new Product(ProductType.Bread)
            });

            // Assert
            Check.That(result).Equals(2.95M);
        }

        [TestMethod]
        public void BasketWith2butters1breadReturns210()
        {
            // Arrange
            var systemUnderTest = new PriceCalculator();

            // Act
            var result = systemUnderTest.CalculateBasketTotal(new List<Product>
            {
                new Product(ProductType.Butter),
                new Product(ProductType.Butter),
                new Product(ProductType.Bread)
            });

            // Assert
            Check.That(result).Equals(2.10M);
        }

        [TestMethod]
        public void BasketWith4butters2breadReturns420()
        {
            // Arrange
            var systemUnderTest = new PriceCalculator();

            // Act
            var result = systemUnderTest.CalculateBasketTotal(new List<Product>
            {
                new Product(ProductType.Butter),
                new Product(ProductType.Butter),
                new Product(ProductType.Bread),
                new Product(ProductType.Butter),
                new Product(ProductType.Butter),
                new Product(ProductType.Bread)
            });

            // Assert
            Check.That(result).Equals(4.20M);
        }

        [TestMethod]
        public void BasketWith4milkReturns345()
        {
            // Arrange
            var systemUnderTest = new PriceCalculator();

            // Act
            var result = systemUnderTest.CalculateBasketTotal(new List<Product>
            {
                new Product(ProductType.Milk),
                new Product(ProductType.Milk),
                new Product(ProductType.Milk),
                new Product(ProductType.Milk)
            });

            // Assert
            Check.That(result).Equals(3.45M);
        }

        [TestMethod]
        public void BasketWith8milkReturns690()
        {
            // Arrange
            var systemUnderTest = new PriceCalculator();

            // Act
            var result = systemUnderTest.CalculateBasketTotal(new List<Product>
            {
                new Product(ProductType.Milk),
                new Product(ProductType.Milk),
                new Product(ProductType.Milk),
                new Product(ProductType.Milk),
                new Product(ProductType.Milk),
                new Product(ProductType.Milk),
                new Product(ProductType.Milk),
                new Product(ProductType.Milk)
            });

            // Assert
            Check.That(result).Equals(6.90M);
        }
    }
}
