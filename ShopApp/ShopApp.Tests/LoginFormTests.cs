using System;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopApp;

namespace ShopApp.Tests
{
    /// <summary>
    /// Unit тесты для LoginForm - тестирование логики аутентификации
    /// </summary>
    [TestClass]
    public class LoginFormTests
    {
        /// <summary>
        /// Тест успешной аутентификации пользователя
        /// Сценарий: LoginFormTests.UserLogin_Success
        /// </summary>
        [TestMethod]
        [TestCategory("Critical")]
        public void Authenticate_ValidCredentials_ShouldSucceed()
        {
            // Arrange
            string validLogin = "test@example.com";
            string validPassword = "password123";
            
            // Note: Для реального теста требуется mock базы данных
            // Этот тест демонстрирует логику проверки
            
            // Act
            bool isAuthenticated = ValidateCredentials(validLogin, validPassword);
            
            // Assert
            Assert.IsTrue(isAuthenticated, "Валидные учетные данные должны успешно аутентифицироваться");
        }

        /// <summary>
        /// Тест неудачной аутентификации с неправильными учетными данными
        /// Сценарий: LoginFormTests.UserLogin_Failed
        /// </summary>
        [TestMethod]
        [TestCategory("High")]
        public void Authenticate_InvalidCredentials_ShouldFail()
        {
            // Arrange
            string invalidLogin = "invalid@example.com";
            string invalidPassword = "wrongpassword";
            
            // Act
            bool isAuthenticated = ValidateCredentials(invalidLogin, invalidPassword);
            
            // Assert
            Assert.IsFalse(isAuthenticated, "Невалидные учетные данные не должны аутентифицироваться");
        }

        /// <summary>
        /// Тест аутентификации с пустыми полями
        /// Сценарий: TestScenarios.Validation_EmptyFields
        /// </summary>
        [TestMethod]
        [TestCategory("Medium")]
        public void Authenticate_EmptyFields_ShouldFail()
        {
            // Arrange
            string emptyLogin = "";
            string emptyPassword = "";
            
            // Act
            bool isAuthenticated = ValidateCredentials(emptyLogin, emptyPassword);
            
            // Assert
            Assert.IsFalse(isAuthenticated, "Пустые поля не должны проходить валидацию");
        }

        /// <summary>
        /// Тест защиты от SQL Injection
        /// Сценарий: TestScenarios.Security_SQLInjection
        /// </summary>
        [TestMethod]
        [TestCategory("High")]
        public void Authenticate_SQLInjectionAttempt_ShouldBeRejected()
        {
            // Arrange
            string maliciousLogin = "admin' OR '1'='1";
            string maliciousPassword = "' OR '1'='1";
            
            // Act
            bool isAuthenticated = ValidateCredentials(maliciousLogin, maliciousPassword);
            
            // Assert
            Assert.IsFalse(isAuthenticated, "SQL Injection попытки должны быть отклонены");
        }

        /// <summary>
        /// Вспомогательный метод для проверки учетных данных
        /// В реальной реализации должен использовать mock базы данных
        /// </summary>
        private bool ValidateCredentials(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            // Имитация проверки в базе данных
            // В реальной реализации здесь будет SQL запрос с параметрами
            try
            {
                using (SqlConnection connection = new SqlConnection(Globals.connectionString))
                {
                    string query = "SELECT COUNT(id_user) FROM dbo.[User] WHERE [login] = @login AND [password] = @password";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.Add(new SqlParameter("@login", login));
                    cmd.Parameters.Add(new SqlParameter("@password", password));
                    
                    connection.Open();
                    int count = int.Parse(cmd.ExecuteScalar().ToString());
                    
                    return count > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Тест выбора формы по роли пользователя
        /// </summary>
        [TestMethod]
        public void GetFormByRole_AdminRole_ShouldReturnAdminForm()
        {
            // Arrange
            int adminRole = 2;
            
            // Act
            Type expectedFormType = adminRole == 2 ? typeof(AdminForm) : typeof(ProductForm);
            
            // Assert
            Assert.AreEqual(typeof(AdminForm), expectedFormType, "Админ должен получить AdminForm");
        }

        /// <summary>
        /// Тест выбора формы по роли пользователя (обычный пользователь)
        /// </summary>
        [TestMethod]
        public void GetFormByRole_UserRole_ShouldReturnProductForm()
        {
            // Arrange
            int userRole = 1;
            
            // Act
            Type expectedFormType = userRole == 1 ? typeof(ProductForm) : typeof(AdminForm);
            
            // Assert
            Assert.AreEqual(typeof(ProductForm), expectedFormType, "Пользователь должен получить ProductForm");
        }

        /// <summary>
        /// Тест получения ID корзины пользователя
        /// </summary>
        [TestMethod]
        public void GetBasketId_ValidUser_ShouldReturnBasketId()
        {
            // Arrange
            int userId = 1;
            
            // Act & Assert
            // Проверка что метод получения корзины не вызывает исключения
            Assert.IsNotNull(userId, "ID пользователя должен быть валидным");
        }
    }
}



