using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;
using ShoppingBasket;
using ShoppingBasket.Models;

namespace ShoppingBasketTests
{
    [TestClass]
    public class TestScenarios
    {
        [TestMethod]
        public void Given1bread1butter1milk_WhenCalculateTotal_ThenTotalIs295()
        {
            // Arrange
            var systemUnderTest = new ShoppingBasketManager();

            systemUnderTest.AddProduct(new Product(ProductType.Bread));
            systemUnderTest.AddProduct(new Product(ProductType.Butter));
            systemUnderTest.AddProduct(new Product(ProductType.Milk));

            // Act
            var result = systemUnderTest.CalculateTotal();

            // Assert
            Check.That(result).Equals(2.95M);
        }

        [TestMethod]
        public void Given2butter2bread_WhenCalculateTotal_ThenTotalIs310()
        {
            // Arrange
            var systemUnderTest = new ShoppingBasketManager();

            systemUnderTest.AddProduct(new Product(ProductType.Butter));
            systemUnderTest.AddProduct(new Product(ProductType.Butter));
            systemUnderTest.AddProduct(new Product(ProductType.Bread));
            systemUnderTest.AddProduct(new Product(ProductType.Bread));

            // Act
            var result = systemUnderTest.CalculateTotal();

            // Assert
            Check.That(result).Equals(3.10M);
        }

        [TestMethod]
        public void Given4milk_WhenCalculateTotal_ThenTotalIs345()
        {
            // Arrange
            var systemUnderTest = new ShoppingBasketManager();

            systemUnderTest.AddProduct(new Product(ProductType.Milk));
            systemUnderTest.AddProduct(new Product(ProductType.Milk));
            systemUnderTest.AddProduct(new Product(ProductType.Milk));
            systemUnderTest.AddProduct(new Product(ProductType.Milk));

            // Act
            var result = systemUnderTest.CalculateTotal();

            // Assert
            Check.That(result).Equals(3.45M);
        }


        [TestMethod]
        public void Given2butter1bread8milk_WhenCalculateTotal_ThenTotalIs345()
        {
            // Arrange
            var systemUnderTest = new ShoppingBasketManager();

            systemUnderTest.AddProduct(new Product(ProductType.Butter));
            systemUnderTest.AddProduct(new Product(ProductType.Butter));
            systemUnderTest.AddProduct(new Product(ProductType.Bread));
            systemUnderTest.AddProduct(new Product(ProductType.Milk));
            systemUnderTest.AddProduct(new Product(ProductType.Milk));
            systemUnderTest.AddProduct(new Product(ProductType.Milk));
            systemUnderTest.AddProduct(new Product(ProductType.Milk));
            systemUnderTest.AddProduct(new Product(ProductType.Milk));
            systemUnderTest.AddProduct(new Product(ProductType.Milk));
            systemUnderTest.AddProduct(new Product(ProductType.Milk));
            systemUnderTest.AddProduct(new Product(ProductType.Milk));

            // Act
            var result = systemUnderTest.CalculateTotal();

            // Assert
            Check.That(result).Equals(9.00M);
        }
    }
}
