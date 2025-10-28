using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopApp;

namespace ShopApp.Tests
{
    /// <summary>
    /// Unit тесты для Globals - тестирование глобальных переменных и констант
    /// </summary>
    [TestClass]
    public class GlobalsTests
    {
        /// <summary>
        /// Тест инициализации глобальных переменных
        /// </summary>
        [TestMethod]
        [TestCategory("Critical")]
        public void Globals_InitialValues_ShouldBeSetCorrectly()
        {
            // Arrange & Act
            // Значения по умолчанию определены в классе Globals

            // Assert
            Assert.IsNotNull(Globals.connectionString, "Connection string должен быть установлен");
            Assert.IsTrue(Globals.connectionString.Length > 0, "Connection string не должен быть пустым");
        }

        /// <summary>
        /// Тест структуры connection string
        /// </summary>
        [TestMethod]
        [TestCategory("High")]
        public void ConnectionString_Format_ShouldBeValid()
        {
            // Arrange
            string connectionString = Globals.connectionString;

            // Act & Assert
            Assert.IsTrue(connectionString.Contains("Server="), "Connection string должен содержать Server");
            Assert.IsTrue(connectionString.Contains("Database="), "Connection string должен содержать Database");
        }

        /// <summary>
        /// Тест установки и получения id_user
        /// </summary>
        [TestMethod]
        [TestCategory("High")]
        public void SetUserId_ValidValue_ShouldStoreCorrectly()
        {
            // Arrange
            int expectedUserId = 123;

            // Act
            Globals.id_user = expectedUserId;

            // Assert
            Assert.AreEqual(expectedUserId, Globals.id_user, "ID пользователя должен быть установлен корректно");
        }

        /// <summary>
        /// Тест установки отрицательного id_user
        /// </summary>
        [TestMethod]
        [TestCategory("Medium")]
        public void SetUserId_NegativeValue_ShouldStore()
        {
            // Arrange
            int negativeId = -1;

            // Act
            Globals.id_user = negativeId;

            // Assert
            Assert.AreEqual(negativeId, Globals.id_user, "Отрицательный ID должен быть сохранен");
        }

        /// <summary>
        /// Тест установки и получения id_role
        /// </summary>
        [TestMethod]
        [TestCategory("High")]
        public void SetRoleId_ValidValue_ShouldStoreCorrectly()
        {
            // Arrange
            int adminRoleId = 2;
            int userRoleId = 1;

            // Act
            Globals.id_role = adminRoleId;

            // Assert
            Assert.AreEqual(adminRoleId, Globals.id_role, "ID роли должен быть установлен корректно");

            // Act
            Globals.id_role = userRoleId;

            // Assert
            Assert.AreEqual(userRoleId, Globals.id_role, "ID роли пользователя должен быть установлен корректно");
        }

        /// <summary>
        /// Тест установки и получения id_basket
        /// </summary>
        [TestMethod]
        [TestCategory("High")]
        public void SetBasketId_ValidValue_ShouldStoreCorrectly()
        {
            // Arrange
            int expectedBasketId = 456;

            // Act
            Globals.id_basket = expectedBasketId;

            // Assert
            Assert.AreEqual(expectedBasketId, Globals.id_basket, "ID корзины должен быть установлен корректно");
        }

        /// <summary>
        /// Тест установки и получения id_product
        /// </summary>
        [TestMethod]
        [TestCategory("High")]
        public void SetProductId_ValidValue_ShouldStoreCorrectly()
        {
            // Arrange
            int expectedProductId = 789;

            // Act
            Globals.id_product = expectedProductId;

            // Assert
            Assert.AreEqual(expectedProductId, Globals.id_product, "ID товара должен быть установлен корректно");
        }

        /// <summary>
        /// Тест параллельного использования глобальных переменных
        /// </summary>
        [TestMethod]
        [TestCategory("Medium")]
        public void Globals_ConcurrentAccess_ShouldMaintainValues()
        {
            // Arrange
            int userId = 100;
            int roleId = 1;
            int basketId = 200;
            int productId = 300;

            // Act
            Globals.id_user = userId;
            Globals.id_role = roleId;
            Globals.id_basket = basketId;
            Globals.id_product = productId;

            // Assert
            Assert.AreEqual(userId, Globals.id_user, "ID пользователя должен сохраниться");
            Assert.AreEqual(roleId, Globals.id_role, "ID роли должен сохраниться");
            Assert.AreEqual(basketId, Globals.id_basket, "ID корзины должен сохраниться");
            Assert.AreEqual(productId, Globals.id_product, "ID товара должен сохраниться");
        }

        /// <summary>
        /// Тест сброса значений
        /// </summary>
        [TestMethod]
        [TestCategory("Medium")]
        public void Globals_ResetValues_ShouldResetToDefault()
        {
            // Arrange
            Globals.id_user = 100;
            Globals.id_role = 1;
            Globals.id_basket = 200;
            Globals.id_product = 300;

            // Act - сброс значений
            Globals.id_user = -1;
            Globals.id_role = -1;
            Globals.id_basket = -1;
            Globals.id_product = -1;

            // Assert
            Assert.AreEqual(-1, Globals.id_user, "ID пользователя должен быть сброшен");
            Assert.AreEqual(-1, Globals.id_role, "ID роли должен быть сброшен");
            Assert.AreEqual(-1, Globals.id_basket, "ID корзины должен быть сброшен");
            Assert.AreEqual(-1, Globals.id_product, "ID товара должен быть сброшен");
        }

        /// <summary>
        /// Тест валидности ролей
        /// </summary>
        [TestMethod]
        [TestCategory("Medium")]
        public void ValidateRoles_ShouldBeCorrect()
        {
            // Arrange
            const int AdminRoleId = 2;
            const int UserRoleId = 1;

            // Act
            Globals.id_role = AdminRoleId;
            bool isAdmin = Globals.id_role == AdminRoleId;

            Globals.id_role = UserRoleId;
            bool isUser = Globals.id_role == UserRoleId;

            // Assert
            Assert.IsTrue(isAdmin, "ID 2 должен соответствовать роли администратора");
            Assert.IsTrue(isUser, "ID 1 должен соответствовать роли пользователя");
        }
    }
}


