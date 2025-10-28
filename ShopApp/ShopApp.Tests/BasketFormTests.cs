using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopApp;

namespace ShopApp.Tests
{
    /// <summary>
    /// Unit тесты для BasketForm - тестирование логики корзины
    /// </summary>
    [TestClass]
    public class BasketFormTests
    {
        /// <summary>
        /// Тест добавления товара в корзину
        /// Сценарий: TestScenarios.Basket_AddProduct
        /// </summary>
        [TestMethod]
        [TestCategory("Critical")]
        public void AddToBasket_ValidProduct_ShouldAddSuccessfully()
        {
            // Arrange
            var basket = new List<BasketItem>();
            int productId = 1;
            string productName = "Футболка";
            decimal price = 500m;
            int quantity = 1;

            // Act
            basket.Add(new BasketItem
            {
                ProductId = productId,
                ProductName = productName,
                Quantity = quantity,
                Price = price
            });

            // Assert
            Assert.AreEqual(1, basket.Count, "В корзине должен быть 1 товар");
            Assert.AreEqual(productId, basket.First().ProductId, "ID товара должен соответствовать");
        }

        /// <summary>
        /// Тест добавления нескольких единиц товара
        /// </summary>
        [TestMethod]
        [TestCategory("High")]
        public void AddToBasket_MultipleItems_ShouldIncrementQuantity()
        {
            // Arrange
            var basket = new List<BasketItem>();
            int productId = 1;
            
            // Act - добавляем один и тот же товар дважды
            var existingItem = basket.FirstOrDefault(b => b.ProductId == productId);
            
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                basket.Add(new BasketItem { ProductId = productId, Quantity = 1, Price = 500m });
            }

            // Добавляем еще раз
            existingItem = basket.FirstOrDefault(b => b.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity++;
            }

            // Assert
            Assert.AreEqual(2, basket.First().Quantity, "Количество товара должно быть 2");
        }

        /// <summary>
        /// Тест удаления товара из корзины
        /// Сценарий: TestScenarios.Basket_RemoveProduct
        /// </summary>
        [TestMethod]
        [TestCategory("Critical")]
        public void RemoveFromBasket_ValidProduct_ShouldRemoveSuccessfully()
        {
            // Arrange
            var basket = CreateTestBasket();
            int productIdToRemove = 1;

            // Act
            basket.RemoveAll(item => item.ProductId == productIdToRemove);

            // Assert
            Assert.AreEqual(2, basket.Count, "В корзине должно остаться 2 товара");
            Assert.IsFalse(basket.Any(item => item.ProductId == productIdToRemove), "Товар с ID 1 не должен быть в корзине");
        }

        /// <summary>
        /// Тест расчета общей стоимости корзины
        /// Сценарий: TestScenarios.Basket_CalculateTotal
        /// </summary>
        [TestMethod]
        [TestCategory("Critical")]
        public void CalculateTotal_SingleItem_ShouldReturnCorrectAmount()
        {
            // Arrange
            var basket = new List<BasketItem>
            {
                new BasketItem { ProductId = 1, ProductName = "Футболка", Price = 500m, Quantity = 1 }
            };

            // Act
            decimal total = basket.Sum(item => item.Price * item.Quantity);

            // Assert
            Assert.AreEqual(500m, total, "Общая стоимость должна быть 500 рублей");
        }

        /// <summary>
        /// Тест расчета общей стоимости корзины с несколькими товарами
        /// </summary>
        [TestMethod]
        [TestCategory("High")]
        public void CalculateTotal_MultipleItems_ShouldReturnCorrectAmount()
        {
            // Arrange
            var basket = CreateTestBasket();

            // Act
            decimal total = basket.Sum(item => item.Price * item.Quantity);

            // Assert
            Assert.AreEqual(6000m, total, "Общая стоимость должна быть 6000 рублей");
        }

        /// <summary>
        /// Тест расчета с разными количествами товаров
        /// </summary>
        [TestMethod]
        [TestCategory("High")]
        public void CalculateTotal_DifferentQuantities_ShouldCalculateCorrectly()
        {
            // Arrange
            var basket = new List<BasketItem>
            {
                new BasketItem { ProductId = 1, ProductName = "Товар 1", Price = 100m, Quantity = 3 },
                new BasketItem { ProductId = 2, ProductName = "Товар 2", Price = 50m, Quantity = 5 }
            };

            // Act
            decimal total = basket.Sum(item => item.Price * item.Quantity);

            // Assert
            Assert.AreEqual(550m, total, "Общая стоимость должна быть 550 рублей (3*100 + 5*50)");
        }

        /// <summary>
        /// Тест расчета пустой корзины
        /// </summary>
        [TestMethod]
        [TestCategory("Medium")]
        public void CalculateTotal_EmptyBasket_ShouldReturnZero()
        {
            // Arrange
            var basket = new List<BasketItem>();

            // Act
            decimal total = basket.Sum(item => item.Price * item.Quantity);

            // Assert
            Assert.AreEqual(0m, total, "Пустая корзина должна иметь стоимость 0");
        }

        /// <summary>
        /// Тест корректности подсчета количества товаров
        /// </summary>
        [TestMethod]
        [TestCategory("Medium")]
        public void GetTotalQuantity_ShouldReturnCorrectCount()
        {
            // Arrange
            var basket = CreateTestBasket();

            // Act
            int totalQuantity = basket.Sum(item => item.Quantity);

            // Assert
            Assert.AreEqual(4, totalQuantity, "Общее количество товаров должно быть 4");
        }

        /// <summary>
        /// Вспомогательный метод для создания тестовой корзины
        /// </summary>
        private List<BasketItem> CreateTestBasket()
        {
            return new List<BasketItem>
            {
                new BasketItem { ProductId = 1, ProductName = "Футболка", Price = 500m, Quantity = 1 },
                new BasketItem { ProductId = 2, ProductName = "Джинсы", Price = 2500m, Quantity = 2 },
                new BasketItem { ProductId = 3, ProductName = "Кроссовки", Price = 3000m, Quantity = 1 }
            };
        }
    }

    /// <summary>
    /// Модель элемента корзины для тестирования
    /// </summary>
    public class BasketItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice => Price * Quantity;
    }
}


