using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using NSubstitute;
using ShoppingBasket;
using ShoppingBasket.Models;
using ShoppingBasket.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasketTests.ShoppingBasketManagerTests
{
    [TestClass]
    public class CalculateTotal
    {
        [TestMethod]
        public void PriceCalculatorIsCalledWithListOfProducts()
        {
            // Arrange
            var priceCalculatorMock = Substitute.For<IPriceCalculator>();
            var systemUnderTest = new ShoppingBasketManager(priceCalculatorMock);

            systemUnderTest.AddProduct(new Product(ProductType.Bread));
            systemUnderTest.AddProduct(new Product(ProductType.Butter));

            // Act
            systemUnderTest.CalculateTotal();

            // Assert
            priceCalculatorMock.Received()
                .CalculateBasketTotal(Arg.Is<List<Product>>(x => x.Count == 3));
            priceCalculatorMock.Received()
                .CalculateBasketTotal(Arg.Is<List<Product>>(x => x[0].Type == ProductType.Bread));
            priceCalculatorMock.Received()
                .CalculateBasketTotal(Arg.Is<List<Product>>(x => x[1].Type == ProductType.Butter));
        }

        [TestMethod]
        public void PriceCalculatorReturnsTotalPrice()
        {
            // Arrange
            var priceCalculatorMock = Substitute.For<IPriceCalculator>();
            priceCalculatorMock.CalculateBasketTotal(Arg.Any<List<Product>>()).Returns(1.0M);
            var systemUnderTest = new ShoppingBasketManager(priceCalculatorMock);

            // Act
            var result = systemUnderTest.CalculateTotal();

            // Assert
            Check.That(result).Equals(1.0M);
        }
    }
}
