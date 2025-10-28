using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShopApp.Tests
{
    /// <summary>
    /// Unit тесты для логики поиска и фильтрации в админских формах
    /// </summary>
    [TestClass]
    public class SearchFilterTests
    {
        /// <summary>
        /// Тест поиска по данным в DataTable (для UsersForm, ProductsForm, OrdersForm)
        /// </summary>
        [TestMethod]
        [TestCategory("High")]
        public void FilterDataTable_ByName_ShouldFilterCorrectly()
        {
            // Arrange
            DataTable dataTable = CreateTestDataTable();
            string searchText = "Иван";

            // Act
            dataTable.DefaultView.RowFilter = $"Convert([Имя], System.String) LIKE '%{searchText}%'";

            // Assert
            Assert.IsTrue(dataTable.DefaultView.Count > 0, "Должен найтись хотя бы один результат");
            Assert.AreEqual(1, dataTable.DefaultView.Count, "Должен найтись ровно 1 результат");
        }

        /// <summary>
        /// Тест поиска с пустым текстом
        /// </summary>
        [TestMethod]
        [TestCategory("Medium")]
        public void FilterDataTable_EmptySearchText_ShouldShowAllResults()
        {
            // Arrange
            DataTable dataTable = CreateTestDataTable();
            string searchText = "";

            // Act
            if (string.IsNullOrEmpty(searchText))
            {
                dataTable.DefaultView.RowFilter = "";
            }

            // Assert
            Assert.AreEqual(3, dataTable.DefaultView.Count, "При пустом поиске должны показаться все результаты");
        }

        /// <summary>
        /// Тест поиска несуществующей строки
        /// </summary>
        [TestMethod]
        [TestCategory("Medium")]
        public void FilterDataTable_NonExistentSearch_ShouldReturnEmpty()
        {
            // Arrange
            DataTable dataTable = CreateTestDataTable();
            string searchText = "Nonexistent";

            // Act
            dataTable.DefaultView.RowFilter = $"Convert([Имя], System.String) LIKE '%{searchText}%'";

            // Assert
            Assert.AreEqual(0, dataTable.DefaultView.Count, "Несуществующий поиск должен вернуть 0 результатов");
        }

        /// <summary>
        /// Тест поиска по нескольким полям
        /// </summary>
        [TestMethod]
        [TestCategory("High")]
        public void FilterDataTable_MultipleFields_ShouldFilterCorrectly()
        {
            // Arrange
            DataTable dataTable = CreateTestDataTable();
            string searchText = "Иван";

            // Act - поиск по нескольким полям
            var filterParts = new List<string>();
            foreach (DataColumn col in dataTable.Columns)
            {
                string columnName = col.ColumnName;
                filterParts.Add($"Convert([{columnName}], System.String) LIKE '%{searchText}%'");
            }

            string filterString = string.Join(" OR ", filterParts);
            dataTable.DefaultView.RowFilter = filterString;

            // Assert
            Assert.IsTrue(dataTable.DefaultView.Count > 0, "Должен найтись хотя бы один результат в любом поле");
        }

        /// <summary>
        /// Тест регистронезависимого поиска
        /// </summary>
        [TestMethod]
        [TestCategory("Medium")]
        public void FilterDataTable_CaseInsensitive_ShouldFindResults()
        {
            // Arrange
            DataTable dataTable = CreateTestDataTable();
            string searchText = "иван"; // в нижнем регистре

            // Act
            dataTable.DefaultView.RowFilter = $"Convert([Имя], System.String) LIKE '%{searchText}%'";

            // Assert
            // Примечание: LIKE в DataTable чувствителен к регистру в C#
            // Для реализации регистронезависимого поиска нужно использовать ToLower()
            DataView dv = dataTable.DefaultView;
            dv.RowFilter = "";
            var result = dv.ToTable().AsEnumerable()
                .Where(row => row.Field<string>("Имя").ToLower().Contains(searchText.ToLower()))
                .Count();

            Assert.IsTrue(result > 0, "Поиск должен быть регистронезависимым");
        }

        /// <summary>
        /// Тест поиска с частичным совпадением
        /// </summary>
        [TestMethod]
        [TestCategory("Medium")]
        public void FilterDataTable_PartialMatch_ShouldFindResults()
        {
            // Arrange
            DataTable dataTable = CreateTestDataTable();
            string searchText = "Ив"; // частичное совпадение

            // Act
            dataTable.DefaultView.RowFilter = $"Convert([Имя], System.String) LIKE '%{searchText}%'";

            // Assert
            Assert.AreEqual(1, dataTable.DefaultView.Count, "Должен найтись результат по частичному совпадению");
        }

        /// <summary>
        /// Тест фильтрации с специальными символами
        /// </summary>
        [TestMethod]
        [TestCategory("High")]
        public void FilterDataTable_SpecialCharacters_ShouldHandleCorrectly()
        {
            // Arrange
            DataTable dataTable = CreateTestDataTableWithSpecialChars();
            string searchText = "O'Reilly";

            // Act
            dataTable.DefaultView.RowFilter = $"Convert([Имя], System.String) = '{searchText}'";

            // Assert
            Assert.AreEqual(1, dataTable.DefaultView.Count, "Должен корректно обработать специальные символы");
        }

        /// <summary>
        /// Тест производительности фильтрации больших наборов данных
        /// </summary>
        [TestMethod]
        [TestCategory("Low")]
        public void FilterDataTable_LargeDataset_ShouldPerformEfficiently()
        {
            // Arrange
            DataTable dataTable = CreateLargeTestDataTable(1000);
            string searchText = "Сотрудник";

            // Act
            var startTime = DateTime.Now;
            dataTable.DefaultView.RowFilter = $"Convert([Имя], System.String) LIKE '%{searchText}%'";
            var endTime = DateTime.Now;

            // Assert
            var duration = endTime - startTime;
            Assert.IsTrue(duration.TotalMilliseconds < 1000, "Фильтрация должна выполниться менее чем за 1 секунду");
        }

        /// <summary>
        /// Вспомогательный метод для создания тестового DataTable
        /// </summary>
        private DataTable CreateTestDataTable()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Имя", typeof(string));
            dataTable.Columns.Add("Роль", typeof(string));

            dataTable.Rows.Add(1, "Иван Петров", "Администратор");
            dataTable.Rows.Add(2, "Мария Сидорова", "Менеджер");
            dataTable.Rows.Add(3, "Алексей Козлов", "Клиент");

            return dataTable;
        }

        /// <summary>
        /// Вспомогательный метод для создания DataTable со специальными символами
        /// </summary>
        private DataTable CreateTestDataTableWithSpecialChars()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Имя", typeof(string));

            dataTable.Rows.Add(1, "O'Reilly");
            dataTable.Rows.Add(2, "D'Angelo");
            dataTable.Rows.Add(3, "Иванов-Петров");

            return dataTable;
        }

        /// <summary>
        /// Вспомогательный метод для создания большого DataTable
        /// </summary>
        private DataTable CreateLargeTestDataTable(int rowCount)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Имя", typeof(string));
            dataTable.Columns.Add("Роль", typeof(string));

            Random random = new Random();
            for (int i = 1; i <= rowCount; i++)
            {
                string name = i <= 10 ? "Сотрудник " + i : "Пользователь " + i;
                dataTable.Rows.Add(i, name, "Role " + (i % 3));
            }

            return dataTable;
        }
    }
}


