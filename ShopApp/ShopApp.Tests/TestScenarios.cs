using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShopApp.Tests
{
    /// <summary>
    /// Документация сценариев тестирования для ShopApp
    /// </summary>
    [TestClass]
    public class TestScenarios
    {
        /// <summary>
        /// Ключевые сценарии тестирования для ShopApp
        /// </summary>
        public enum TestScenariosEnum
        {
            /// <summary>
            /// 1. АУТЕНТИФИКАЦИЯ И РЕГИСТРАЦИЯ
            /// Тестирование входа пользователя в систему
            /// </summary>
            UserLogin_Success = 1,
            
            /// <summary>
            /// Неудачный вход с неправильными учетными данными
            /// </summary>
            UserLogin_Failed = 2,

            /// <summary>
            /// Регистрация нового пользователя
            /// </summary>
            UserRegistration_Success = 3,

            /// <summary>
            /// Регистрация с занятым логином
            /// </summary>
            UserRegistration_DuplicateLogin = 4,

            /// <summary>
            /// Регистрация с несовпадающими паролями
            /// </summary>
            UserRegistration_PasswordMismatch = 5,

            /// <summary>
            /// 2. РАБОТА С ТОВАРАМИ
            /// Отображение списка товаров
            /// </summary>
            ProductList_Display = 6,

            /// <summary>
            /// Фильтрация товаров по типу
            /// </summary>
            ProductFilter_ByType = 7,

            /// <summary>
            /// Поиск товаров по названию
            /// </summary>
            ProductSearch_ByName = 8,

            /// <summary>
            /// Сортировка товаров по цене (возрастание)
            /// </summary>
            ProductSort_PriceAscending = 9,

            /// <summary>
            /// Сортировка товаров по цене (убывание)
            /// </summary>
            ProductSort_PriceDescending = 10,

            /// <summary>
            /// Комбинированные фильтры (тип + поиск + сортировка)
            /// </summary>
            ProductFilter_Combined = 11,

            /// <summary>
            /// 3. РАБОТА С КОРЗИНОЙ
            /// Добавление товара в корзину
            /// </summary>
            Basket_AddProduct = 12,

            /// <summary>
            /// Удаление товара из корзины
            /// </summary>
            Basket_RemoveProduct = 13,

            /// <summary>
            /// Расчет общей стоимости корзины
            /// </summary>
            Basket_CalculateTotal = 14,

            /// <summary>
            /// Оформление заказа
            /// </summary>
            Basket_CreateOrder = 15,

            /// <summary>
            /// Очистка корзины после оформления заказа
            /// </summary>
            Basket_ClearAfterOrder = 16,

            /// <summary>
            /// 4. АДМИНИСТРИРОВАНИЕ
            /// Просмотр списка пользователей
            /// </summary>
            Admin_ViewUsers = 17,

            /// <summary>
            /// Редактирование пользователя
            /// </summary>
            Admin_EditUser = 18,

            /// <summary>
            /// Удаление пользователя
            /// </summary>
            Admin_DeleteUser = 19,

            /// <summary>
            /// Добавление нового товара
            /// </summary>
            Admin_AddProduct = 20,

            /// <summary>
            /// Редактирование товара
            /// </summary>
            Admin_EditProduct = 21,

            /// <summary>
            /// Удаление товара (с каскадным удалением отзывов)
            /// </summary>
            Admin_DeleteProduct = 22,

            /// <summary>
            /// Просмотр заказов
            /// </summary>
            Admin_ViewOrders = 23,

            /// <summary>
            /// Редактирование заказа
            /// </summary>
            Admin_EditOrder = 24,

            /// <summary>
            /// Удаление заказа
            /// </summary>
            Admin_DeleteOrder = 25,

            /// <summary>
            /// 5. БЕЗОПАСНОСТЬ И ВАЛИДАЦИЯ
            /// Проверка валидации пустых полей
            /// </summary>
            Validation_EmptyFields = 26,

            /// <summary>
            /// SQL Injection защита
            /// </summary>
            Security_SQLInjection = 27,

            /// <summary>
            /// Проверка прав доступа (пользователь vs админ)
            /// </summary>
            Security_AccessControl = 28
        }

        /// <summary>
        /// Приоритеты тестирования
        /// </summary>
        public enum TestPriority
        {
            Critical,   // Критичные сценарии, влияющие на основную функциональность
            High,       // Важные бизнес-сценарии
            Medium,     // Сценарии улучшения пользовательского опыта
            Low         // Маловероятные или не критичные сценарии
        }

        /// <summary>
        /// Матрица приоритетов тестирования
        /// </summary>
        public static TestPriority GetPriority(TestScenariosEnum scenario)
        {
            return scenario switch
            {
                TestScenariosEnum.UserLogin_Success => TestPriority.Critical,
                TestScenariosEnum.UserRegistration_Success => TestPriority.Critical,
                TestScenariosEnum.Basket_AddProduct => TestPriority.Critical,
                TestScenariosEnum.Basket_CreateOrder => TestPriority.Critical,
                TestScenariosEnum.ProductList_Display => TestPriority.Critical,
                TestScenariosEnum.UserLogin_Failed => TestPriority.High,
                TestScenariosEnum.UserRegistration_DuplicateLogin => TestPriority.High,
                TestScenariosEnum.ProductFilter_ByType => TestPriority.High,
                TestScenariosEnum.ProductSearch_ByName => TestPriority.High,
                TestScenariosEnum.Basket_CalculateTotal => TestPriority.High,
                TestScenariosEnum.Admin_ViewUsers => TestPriority.Medium,
                TestScenariosEnum.Admin_EditUser => TestPriority.Medium,
                TestScenariosEnum.Security_SQLInjection => TestPriority.High,
                TestScenariosEnum.Validation_EmptyFields => TestPriority.Medium,
                _ => TestPriority.Low
            };
        }

        [TestMethod]
        public void TestScenariosDocumentation()
        {
            // Этот метод служит для документирования сценариев
            // Всего определено {Enum.GetValues(typeof(TestScenariosEnum)).Length} сценариев
            Assert.IsTrue(true, "Сценарии успешно документированы");
        }
    }
}



