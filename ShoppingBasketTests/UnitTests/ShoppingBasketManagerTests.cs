using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using ShoppingBasket;
using ShoppingBasket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingBasketTests.UnitTests
{
    [TestClass]
    public class ShoppingBasketManagerTests
    {
        [TestMethod]
        public void WhenFirstProductIsAddedTheListIsUpdated()
        {
            // Arrange
            var systemUnderTest = new ShoppingBasketManager();

            // Act
            systemUnderTest.AddProduct(new Product(ProductType.Bread));

            // Assert
            Check.That(systemUnderTest.ProductsList.Count).Equals(1);
            Check.That(systemUnderTest.ProductsList.First().Type).Equals(ProductType.Bread);
        }

        [TestMethod]
        public void WhenProductIsAddedToExistingListProductIsAddedLast()
        {
            // Arrange
            var systemUnderTest = new ShoppingBasketManager();
            systemUnderTest.AddProduct(new Product(ProductType.Butter));
            systemUnderTest.AddProduct(new Product(ProductType.Bread));
            systemUnderTest.AddProduct(new Product(ProductType.Milk));

            // Act
            systemUnderTest.AddProduct(new Product(ProductType.Bread));

            // Assert
            Check.That(systemUnderTest.ProductsList.Count).Equals(4);
            Check.That(systemUnderTest.ProductsList[0].Type).Equals(ProductType.Butter);
            Check.That(systemUnderTest.ProductsList[1].Type).Equals(ProductType.Bread);
            Check.That(systemUnderTest.ProductsList[2].Type).Equals(ProductType.Milk);
            Check.That(systemUnderTest.ProductsList[3].Type).Equals(ProductType.Bread);
        }
    }
}
