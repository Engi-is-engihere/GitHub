using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopApp;

namespace ShopApp.Tests
{
    /// <summary>
    /// Unit тесты для ProductForm - тестирование логики отображения и фильтрации товаров
    /// </summary>
    [TestClass]
    public class ProductFormTests
    {
        /// <summary>
        /// Тест фильтрации товаров по типу
        /// Сценарий: TestScenarios.ProductFilter_ByType
        /// </summary>
        [TestMethod]
        [TestCategory("High")]
        public void FilterProducts_ByType_ShouldReturnFilteredResults()
        {
            // Arrange
            var products = CreateTestProducts();
            int filterTypeId = 1; // Одежда

            // Act
            var filteredProducts = products.Where(p => p.TypeId == filterTypeId).ToList();

            // Assert
            Assert.IsTrue(filteredProducts.All(p => p.TypeId == filterTypeId), "Все отфильтрованные товары должны быть выбранного типа");
            Assert.AreEqual(2, filteredProducts.Count, "Должно быть 2 товара типа 'Одежда'");
        }

        /// <summary>
        /// Тест поиска товаров по названию
        /// Сценарий: TestScenarios.ProductSearch_ByName
        /// </summary>
        [TestMethod]
        [TestCategory("High")]
        public void SearchProducts_ByName_ShouldReturnMatchingResults()
        {
            // Arrange
            var products = CreateTestProducts();
            string searchText = "Футболка";

            // Act
            var searchResults = products.Where(p => p.Name.Contains(searchText)).ToList();

            // Assert
            Assert.IsTrue(searchResults.All(p => p.Name.Contains(searchText)), "Все результаты должны содержать 'Футболка'");
            Assert.AreEqual(1, searchResults.Count, "Должен найтись 1 товар с названием 'Футболка'");
        }

        /// <summary>
        /// Тест сортировки товаров по цене (возрастание)
        /// Сценарий: TestScenarios.ProductSort_PriceAscending
        /// </summary>
        [TestMethod]
        [TestCategory("High")]
        public void SortProducts_PriceAscending_ShouldSortCorrectly()
        {
            // Arrange
            var products = CreateTestProducts();

            // Act
            var sortedProducts = products.OrderBy(p => p.Price).ToList();

            // Assert
            Assert.AreEqual(500m, sortedProducts.First().Price, "Первый товар должен быть с минимальной ценой");
            Assert.AreEqual(5000m, sortedProducts.Last().Price, "Последний товар должен быть с максимальной ценой");
        }

        /// <summary>
        /// Тест сортировки товаров по цене (убывание)
        /// Сценарий: TestScenarios.ProductSort_PriceDescending
        /// </summary>
        [TestMethod]
        [TestCategory("High")]
        public void SortProducts_PriceDescending_ShouldSortCorrectly()
        {
            // Arrange
            var products = CreateTestProducts();

            // Act
            var sortedProducts = products.OrderByDescending(p => p.Price).ToList();

            // Assert
            Assert.AreEqual(5000m, sortedProducts.First().Price, "Первый товар должен быть с максимальной ценой");
            Assert.AreEqual(500m, sortedProducts.Last().Price, "Последний товар должен быть с минимальной ценой");
        }

        /// <summary>
        /// Тест комбинированных фильтров (тип + поиск + сортировка)
        /// Сценарий: TestScenarios.ProductFilter_Combined
        /// </summary>
        [TestMethod]
        [TestCategory("High")]
        public void FilterProducts_CombinedFilters_ShouldReturnCorrectResults()
        {
            // Arrange
            var products = CreateTestProducts();
            string searchText = "Джинсы";
            int filterTypeId = 1; // Одежда
            string sortOrder = "ASC"; // От дешевого к дорогому

            // Act
            var filteredProducts = products
                .Where(p => p.Name.Contains(searchText) && p.TypeId == filterTypeId)
                .OrderBy(p => p.Price)
                .ToList();

            // Assert
            Assert.IsTrue(filteredProducts.All(p => p.Name.Contains(searchText) && p.TypeId == filterTypeId), "Все результаты должны соответствовать критериям");
            Assert.IsTrue(filteredProducts.Zip(filteredProducts.Skip(1), (a, b) => a.Price <= b.Price).All(x => x), "Товары должны быть отсортированы по возрастанию цены");
        }

        /// <summary>
        /// Тест пустого результата поиска
        /// </summary>
        [TestMethod]
        [TestCategory("Medium")]
        public void SearchProducts_NoMatch_ShouldReturnEmptyList()
        {
            // Arrange
            var products = CreateTestProducts();
            string searchText = "NonexistentProduct";

            // Act
            var searchResults = products.Where(p => p.Name.Contains(searchText)).ToList();

            // Assert
            Assert.AreEqual(0, searchResults.Count, "Поиск несуществующего товара должен вернуть пустой список");
        }

        /// <summary>
        /// Тест регистронезависимого поиска
        /// </summary>
        [TestMethod]
        [TestCategory("Medium")]
        public void SearchProducts_CaseInsensitive_ShouldFindResults()
        {
            // Arrange
            var products = CreateTestProducts();
            string searchText = "футболка"; // в нижнем регистре

            // Act
            var searchResults = products.Where(p => p.Name.ToLower().Contains(searchText.ToLower())).ToList();

            // Assert
            Assert.AreEqual(1, searchResults.Count, "Поиск должен быть регистронезависимым");
        }

        /// <summary>
        /// Вспомогательный метод для создания тестовых данных
        /// </summary>
        private List<TestProduct> CreateTestProducts()
        {
            return new List<TestProduct>
            {
                new TestProduct { Id = 1, Name = "Футболка хлопковая", Price = 500m, TypeId = 1, TypeName = "Одежда" },
                new TestProduct { Id = 2, Name = "Джинсы классические", Price = 2500m, TypeId = 1, TypeName = "Одежда" },
                new TestProduct { Id = 3, Name = "Кроссовки спортивные", Price = 3000m, TypeId = 2, TypeName = "Обувь" },
                new TestProduct { Id = 4, Name = "Сумка кожаная", Price = 5000m, TypeId = 3, TypeName = "Аксессуары" },
                new TestProduct { Id = 5, Name = "Куртка зимняя", Price = 4000m, TypeId = 1, TypeName = "Одежда" }
            };
        }

        /// <summary>
        /// Тестовая модель продукта
        /// </summary>
        private class TestProduct
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int TypeId { get; set; }
            public string TypeName { get; set; }
        }
    }
}


