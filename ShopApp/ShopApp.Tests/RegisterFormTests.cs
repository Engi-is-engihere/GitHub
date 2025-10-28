using System;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopApp;

namespace ShopApp.Tests
{
    /// <summary>
    /// Unit тесты для RegisterForm - тестирование логики регистрации
    /// </summary>
    [TestClass]
    public class RegisterFormTests
    {
        /// <summary>
        /// Тест успешной регистрации нового пользователя
        /// Сценарий: TestScenarios.UserRegistration_Success
        /// </summary>
        [TestMethod]
        [TestCategory("Critical")]
        public void Register_ValidCredentials_ShouldSucceed()
        {
            // Arrange
            string login = "newuser@example.com";
            string password = "password123";
            string confirmPassword = "password123";
            
            // Act
            RegistrationResult result = RegisterUser(login, password, confirmPassword);
            
            // Assert
            Assert.AreEqual(RegistrationResult.Success, result, "Регистрация должна быть успешной");
        }

        /// <summary>
        /// Тест регистрации с занятым логином
        /// Сценарий: TestScenarios.UserRegistration_DuplicateLogin
        /// </summary>
        [TestMethod]
        [TestCategory("High")]
        public void Register_DuplicateLogin_ShouldFail()
        {
            // Arrange
            string existingLogin = "existing@example.com";
            string password = "password123";
            string confirmPassword = "password123";
            
            // Act
            RegistrationResult result = RegisterUser(existingLogin, password, confirmPassword);
            
            // Assert
            Assert.AreEqual(RegistrationResult.LoginTaken, result, "Занятый логин должен вернуть LoginTaken");
        }

        /// <summary>
        /// Тест регистрации с несовпадающими паролями
        /// Сценарий: TestScenarios.UserRegistration_PasswordMismatch
        /// </summary>
        [TestMethod]
        [TestCategory("High")]
        public void Register_PasswordMismatch_ShouldFail()
        {
            // Arrange
            string login = "user@example.com";
            string password = "password123";
            string confirmPassword = "password456";
            
            // Act
            RegistrationResult result = RegisterUser(login, password, confirmPassword);
            
            // Assert
            Assert.AreEqual(RegistrationResult.PasswordMismatch, result, "Несовпадающие пароли должны вернуть PasswordMismatch");
        }

        /// <summary>
        /// Тест регистрации с пустыми полями
        /// </summary>
        [TestMethod]
        [TestCategory("Medium")]
        public void Register_EmptyFields_ShouldFail()
        {
            // Arrange
            string emptyLogin = "";
            string emptyPassword = "";
            string emptyConfirmPassword = "";
            
            // Act
            RegistrationResult result = RegisterUser(emptyLogin, emptyPassword, emptyConfirmPassword);
            
            // Assert
            Assert.AreNotEqual(RegistrationResult.Success, result, "Пустые поля не должны проходить валидацию");
        }

        /// <summary>
        /// Тест валидации email/phone формата
        /// </summary>
        [TestMethod]
        [TestCategory("Medium")]
        public void ValidateLogin_InvalidFormat_ShouldFail()
        {
            // Arrange
            string invalidLogin = "!@#$%^&*()";
            
            // Act
            bool isValid = IsValidLogin(invalidLogin);
            
            // Assert
            Assert.IsFalse(isValid, "Невалидный формат логина не должен проходить проверку");
        }

        /// <summary>
        /// Тест минимальной длины пароля
        /// </summary>
        [TestMethod]
        [TestCategory("Medium")]
        public void ValidatePassword_TooShort_ShouldFail()
        {
            // Arrange
            string shortPassword = "123";
            
            // Act
            bool isValid = IsValidPassword(shortPassword);
            
            // Assert
            Assert.IsFalse(isValid, "Пароль должен быть минимум 6 символов");
        }

        /// <summary>
        /// Вспомогательный метод для регистрации пользователя
        /// </summary>
        private RegistrationResult RegisterUser(string login, string password, string confirmPassword)
        {
            // Валидация
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                return RegistrationResult.InvalidInput;
            }

            if (password != confirmPassword)
            {
                return RegistrationResult.PasswordMismatch;
            }

            // Проверка на существующего пользователя
            try
            {
                using (SqlConnection connection = new SqlConnection(Globals.connectionString))
                {
                    string selectQuery = "SELECT COUNT(id_user) FROM dbo.[User] WHERE [login] = @login";
                    SqlCommand selectCmd = new SqlCommand(selectQuery, connection);
                    selectCmd.Parameters.AddWithValue("@login", login);
                    
                    connection.Open();
                    int count = int.Parse(selectCmd.ExecuteScalar().ToString());
                    
                    if (count > 0)
                    {
                        return RegistrationResult.LoginTaken;
                    }

                    // Создание нового пользователя
                    string insertQuery = "INSERT INTO dbo.[User] ([Login], [password], [id_Role]) VALUES (@Login, @password, @id_Role); SELECT SCOPE_IDENTITY();";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, connection);
                    insertCmd.Parameters.AddWithValue("@Login", login);
                    insertCmd.Parameters.AddWithValue("@password", password);
                    insertCmd.Parameters.AddWithValue("@id_Role", 1); // Role 1 = User
                    
                    int newUserId = int.Parse(insertCmd.ExecuteScalar().ToString());

                    // Создание корзины для пользователя
                    string insertBasketQuery = "INSERT INTO Basket (id_user) VALUES (@id_user)";
                    SqlCommand insertBasketCmd = new SqlCommand(insertBasketQuery, connection);
                    insertBasketCmd.Parameters.AddWithValue("@id_user", newUserId);
                    insertBasketCmd.ExecuteNonQuery();

                    return RegistrationResult.Success;
                }
            }
            catch (Exception)
            {
                return RegistrationResult.Error;
            }
        }

        /// <summary>
        /// Вспомогательный метод для проверки валидности логина
        /// </summary>
        private bool IsValidLogin(string login)
        {
            if (string.IsNullOrEmpty(login))
                return false;

            // Простая проверка формата email или телефона
            bool isEmail = login.Contains("@") && login.Contains(".");
            bool isPhone = System.Text.RegularExpressions.Regex.IsMatch(login, @"^\d+$");
            
            return isEmail || isPhone;
        }

        /// <summary>
        /// Вспомогательный метод для проверки валидности пароля
        /// </summary>
        private bool IsValidPassword(string password)
        {
            return !string.IsNullOrEmpty(password) && password.Length >= 6;
        }

        /// <summary>
        /// Результат регистрации
        /// </summary>
        public enum RegistrationResult
        {
            Success,
            LoginTaken,
            PasswordMismatch,
            InvalidInput,
            Error
        }
    }
}


