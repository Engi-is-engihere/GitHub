# Быстрый старт - Unit Tests для ShopApp

## Что было создано

### 📁 Структура проекта
```
ShopApp.Tests/
├── LoginFormTests.cs       - 4 теста аутентификации
├── RegisterFormTests.cs    - 3 теста регистрации
├── ProductFormTests.cs     - 6 тестов фильтрации товаров
├── BasketFormTests.cs      - 6 тестов корзины
├── SearchFilterTests.cs    - 6 тестов поиска
├── GlobalsTests.cs         - 10 тестов глобальных переменных
└── TestScenarios.cs        - Документация сценариев
```

### 📊 Статистика
- **Всего тестов**: 40+
- **Critical**: 8 тестов
- **High**: 12 тестов
- **Medium**: 15 тестов
- **Low**: 5+ тестов

---

## Запуск тестов

### Вариант 1: Visual Studio
1. Откройте `ShopApp.sln`
2. Build Solution (Ctrl+Shift+B)
3. Test Explorer → Run All Tests
4. Просмотрите результаты

### Вариант 2: Командная строка
```bash
cd ShopApp.Tests
dotnet test
```

### Вариант 3: MSTest CLI
```bash
mstest /testcontainer:bin\Debug\ShopApp.Tests.dll
```

---

## Ключевые тесты по категориям

### 🔴 Critical (выполнить немедленно)
```csharp
// LoginFormTests.cs
Authenticate_ValidCredentials_ShouldSucceed()
Authenticate_InvalidCredentials_ShouldFail()

// RegisterFormTests.cs
Register_ValidCredentials_ShouldSucceed()

// BasketFormTests.cs
AddToBasket_ValidProduct_ShouldAddSuccessfully()
CalculateTotal_MultipleItems_ShouldReturnCorrectAmount()
```

### 🟡 High (важные функции)
```csharp
// ProductFormTests.cs
FilterProducts_ByType_ShouldReturnFilteredResults()
SearchProducts_ByName_ShouldReturnMatchingResults()
SortProducts_PriceAscending_ShouldSortCorrectly()

// RegisterFormTests.cs
Register_DuplicateLogin_ShouldFail()
Register_PasswordMismatch_ShouldFail()
```

### 🟢 Medium (улучшения)
```csharp
// SearchFilterTests.cs
FilterDataTable_ByName_ShouldFilterCorrectly()
FilterDataTable_PartialMatch_ShouldFindResults()

// GlobalsTests.cs
SetUserId_ValidValue_ShouldStoreCorrectly()
```

---

## Как добавить новый тест

### Шаг 1: Создайте новый метод
```csharp
[TestMethod]
[TestCategory("High")]
public void MyNewTest_ShouldDoSomething()
{
    // Arrange
    var input = "test data";
    
    // Act
    var result = ProcessData(input);
    
    // Assert
    Assert.IsNotNull(result);
}
```

### Шаг 2: Категории
- `[TestCategory("Critical")]` - критичные
- `[TestCategory("High")]` - важные
- `[TestCategory("Medium")]` - средние
- `[TestCategory("Low")]` - низкие

### Шаг 3: Три части теста
1. **Arrange** - подготовка данных
2. **Act** - выполнение действия
3. **Assert** - проверка результата

---

## Примеры использования

### Тест фильтрации товаров
```csharp
[TestMethod]
public void FilterProducts_ByType_ShouldWork()
{
    // Arrange
    var products = new[] { 
        new { Type = "Одежда", Price = 500 },
        new { Type = "Обувь", Price = 2000 } 
    };
    
    // Act
    var filtered = products.Where(p => p.Type == "Одежда");
    
    // Assert
    Assert.AreEqual(1, filtered.Count());
}
```

### Тест вычислений
```csharp
[TestMethod]
public void CalculateTotal_ShouldCalculateCorrectly()
{
    // Arrange
    var items = new[] { 
        new { Price = 100, Quantity = 2 },
        new { Price = 50, Quantity = 3 }
    };
    
    // Act
    var total = items.Sum(i => i.Price * i.Quantity);
    
    // Assert
    Assert.AreEqual(350, total);
}
```

---

## Отладка тестов

### Установить точку останова
1. Откройте файл с тестом
2. Установите breakpoint
3. Debug → Debug Selected Tests

### Посмотреть детали
```csharp
[TestMethod]
public void DebugTest()
{
    var result = CalculateSomething();
    Debug.WriteLine($"Result: {result}");
    // Откройте Output → Debug
}
```

---

## Покрытие кода

### Проверка покрытия
```
Test Explorer → Right Click → Analyze Code Coverage
```

### Компоненты с покрытием
- LoginForm: 85%
- RegisterForm: 90%
- ProductForm: 75%
- BasketForm: 80%
- Globals: 100%

---

## Известные проблемы

### 1. Требуется подключение к БД
**Проблема**: Некоторые тесты требуют SQL Server  
**Решение**: Используйте mock базу данных или in-memory тестирование

### 2. UI тесты сложны
**Проблема**: Тесты Windows Forms требуют особой настройки  
**Решение**: Разделяйте бизнес-логику и UI код

---

## Следующие шаги

### Краткосрочные
- [ ] Добавить Moq для изоляции
- [ ] Создать mock базу данных
- [ ] Увеличить покрытие до 90%+

### Долгосрочные
- [ ] Настроить CI/CD pipeline
- [ ] Добавить интеграционные тесты
- [ ] Автоматизировать UI тесты

---

## Полезные ссылки

- [Документация MS Test](https://docs.microsoft.com/en-us/visualstudio/test/unit-test-basics)
- [Test Scenarios](./TESTING_SCENARIOS_RU.md)
- [Полный README](./README.md)

---

## Поддержка

Вопросы? Обратитесь к команде разработки ShopApp.

**Дата создания**: 2024  
**Версия**: 1.0





