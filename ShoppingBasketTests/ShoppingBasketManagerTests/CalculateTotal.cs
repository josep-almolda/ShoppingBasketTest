using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
