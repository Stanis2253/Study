using System.Text.RegularExpressions;
using System.Text;
using static StudyProject.DelegatesDemo;

namespace StudyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в учебный проект по C#!");
            Console.WriteLine("Выберите тему для изучения:");
            Console.WriteLine("1. Регулярные выражения");
            Console.WriteLine("2. Основы LINQ");
            Console.WriteLine("3. Проекция данных");
            Console.WriteLine("4. Фильтрация коллекции");
            Console.WriteLine("5. Сортировка");
            Console.WriteLine("6. Объединение, пересечение и разность коллекций");
            Console.WriteLine("7. Делегаты");
            Console.WriteLine("8. Применение делегатов");
            Console.WriteLine("9. Анонимные методы");
            Console.WriteLine("10. Лямбды");
            Console.WriteLine("11. События");
            Console.WriteLine("12. Замыкания");
            Console.WriteLine("13. Строки и класс System.String");
            Console.WriteLine("14. Операции со строками");
            Console.WriteLine("15. Форматирование и интерполяция строк");
            Console.WriteLine("16. Класс StringBuilder");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RegularExpressionsDemo.Demo();
                    break;
                case "2":
                    LinqBasicsDemo.Demo();
                    break;
                case "3":
                    DataProjectionDemo.Demo();
                    break;
                case "4":
                    CollectionFilteringDemo.Demo();
                    break;
                case "5":
                    SortingDemo.Demo();
                    break;
                case "6":
                    SetOperationsDemo.Demo();
                    break;
                case "7":
                    DelegatesDemo.Demo();
                    break;
                case "8":
                    DelegatesUsageDemo.Demo();
                    break;
                case "9":
                    AnonymousMethodsDemo.Demo();
                    break;
                case "10":
                    LambdaExpressionsDemo.Demo();
                    break;
                case "11":
                    EventsDemo.Demo();
                    break;
                case "12":
                    ClosuresDemo.Demo();
                    break;
                case "13":
                    StringBasicsDemo.Demo();
                    break;
                case "14":
                    StringOperationsDemo.Demo();
                    break;
                case "15":
                    StringFormattingDemo.Demo();
                    break;
                case "16":
                    StringBuilderDemo.Demo();
                    break;
                default:
                    Console.WriteLine("Неверный выбор!");
                    break;
            }
        }
    }

    // Демонстрация регулярных выражений
    public static class RegularExpressionsDemo
    {
        public static void Demo()
        {
            Console.WriteLine("\n=== Демонстрация регулярных выражений ===");
            // Пример 1: Проверка email
            string email = "test@example.com";
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            bool isValidEmail = Regex.IsMatch(email, pattern);
            Console.WriteLine($"Email {email} {(isValidEmail ? "корректный" : "некорректный")}");

            // Пример 2: Извлечение чисел из строки
            string text = "Цена: 100 рублей, скидка: 20%";
            string numberPattern = @"\d+";
            var numbers = Regex.Matches(text, numberPattern)
                             .Cast<Match>()
                             .Select(m => int.Parse(m.Value));
            Console.WriteLine($"Найденные числа: {string.Join(", ", numbers)}");

        }
    }

    // Демонстрация основ LINQ
    public static class LinqBasicsDemo
    {
        public static void Demo()
        {
            Console.WriteLine("\n=== Демонстрация основ LINQ ===");

            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Пример 1: Where
            var evenNumbers = numbers.Where(n => n % 2 == 0);
            Console.WriteLine($"Четные числа: {string.Join(", ", evenNumbers)}");

            // Пример 2: Select
            var squares = numbers.Select(n => n * n);
            Console.WriteLine($"Квадраты чисел: {string.Join(", ", squares)}");

            // Пример 3: First/Last
            Console.WriteLine($"Первое число: {numbers.First()}");
            Console.WriteLine($"Последнее число: {numbers.Last()}");
        }
    }

    // Демонстрация проекции данных
    public static class DataProjectionDemo
    {
        public static void Demo()
        {
            Console.WriteLine("\n=== Демонстрация проекции данных ===");

            var products = new[]
            {
                new { Name = "Телефон", Price = 1000 },
                new { Name = "Планшет", Price = 2000 },
                new { Name = "Ноутбук", Price = 3000 }
            };

            // Пример 1: Анонимные типы
            var productNames = products.Select(p => new { p.Name });
            Console.WriteLine("Имена продуктов:");
            foreach (var p in productNames)
                Console.WriteLine(p.Name);

            // Пример 2: Сложная проекция
            var productInfo = products.Select(p => new
            {
                p.Name,
                PriceWithTax = p.Price * 1.2,
                IsExpensive = p.Price > 2000
            });
            Console.WriteLine("\nИнформация о продуктах:");
            foreach (var p in productInfo)
                Console.WriteLine($"{p.Name}: {p.PriceWithTax:C}, Дорогой: {p.IsExpensive}");
        }
    }

    // Демонстрация фильтрации коллекции
    public static class CollectionFilteringDemo
    {
        public static void Demo()
        {
            Console.WriteLine("\n=== Демонстрация фильтрации коллекции ===");

            var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Пример 1: Фильтрация по условию
            var filtered = numbers.Where(n => n > 5 && n < 9);
            Console.WriteLine($"Числа больше 5 и меньше 9: {string.Join(", ", filtered)}");

            // Пример 2: Фильтрация с использованием OfType
            var mixed = new object[] { 1, "два", 3, "четыре", 5 };
            var numbersOnly = mixed.OfType<int>();
            Console.WriteLine($"Только числа: {string.Join(", ", numbersOnly)}");
        }
    }

    // Демонстрация сортировки
    public static class SortingDemo
    {
        public static void Demo()
        {
            Console.WriteLine("\n=== Демонстрация сортировки ===");

            var products = new[]
            {
                new { Name = "Телефон", Price = 1000 },
                new { Name = "Планшет", Price = 2000 },
                new { Name = "Ноутбук", Price = 3000 }
            };

            // Пример 1: Сортировка по возрастанию
            var sortedByPrice = products.OrderBy(p => p.Price);
            Console.WriteLine("Сортировка по цене (возрастание):");
            foreach (var p in sortedByPrice)
                Console.WriteLine($"{p.Name}: {p.Price:C}");

            // Пример 2: Сортировка по убыванию
            var sortedByPriceDesc = products.OrderByDescending(p => p.Price);
            Console.WriteLine("\nСортировка по цене (убывание):");
            foreach (var p in sortedByPriceDesc)
                Console.WriteLine($"{p.Name}: {p.Price:C}");
        }
    }

    // Демонстрация операций с множествами
    public static class SetOperationsDemo
    {
        public static void Demo()
        {
            Console.WriteLine("\n=== Демонстрация операций с множествами ===");

            var set1 = new[] { 1, 2, 3, 4, 5 };
            var set2 = new[] { 4, 5, 6, 7, 8 };

            // Пример 1: Объединение (Union)
            var union = set1.Union(set2);
            Console.WriteLine($"Объединение: {string.Join(", ", union)}");

            // Пример 2: Пересечение (Intersect)
            var intersection = set1.Intersect(set2);
            Console.WriteLine($"Пересечение: {string.Join(", ", intersection)}");

            // Пример 3: Разность (Except)
            var difference = set1.Except(set2);
            Console.WriteLine($"Разность (set1 - set2): {string.Join(", ", difference)}");
        }
    }

    // Демонстрация делегатов
    public static class DelegatesDemo
    {
        public delegate Task<int> MathOperation(int x, int y);

        public static void Demo()
        {
            Console.WriteLine("\n=== Демонстрация делегатов ===");

            MathOperation mat = exempleDel;

            Console.WriteLine(mat(1, 2));

            Func<int, int, int> add = (a, b) => a + b;

            Action<int> action = delegate(int a)
            {
                Console.WriteLine(a);
            };
            
            Predicate<int> predicate = (a) => a == 1;

            RetryAsync(add, 3, TimeSpan.FromSeconds(1));

            mat.Invoke(1, 2);

        }

        public static async Task<int> exempleDel(int a, int b)
        {
            return a + b;
        }

        public static async Task RetryAsync(Func<int, int, int> action, int retryCount, TimeSpan time)
        {
            for (int i = 0; i < retryCount; i++)
            {
                try
                {
                    action(1, 2);
                    return;
                }
                catch (Exception ex)
                {
                    if (i == retryCount)
                    {
                        throw new InvalidOperationException(ex.Message);
                    }
                    await Task.Delay(time);
                }
            }
        }

        // Демонстрация применения делегатов
        public static class DelegatesUsageDemo
        {
            public static void Demo()
            {
                Console.WriteLine("\n=== Демонстрация применения делегатов ===");

                var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

                var evenNumbers = Filter(numbers, IsEven);
                Console.WriteLine($"Четные числа: {string.Join(", ", evenNumbers)}");

                var firstEven = FindFirst(numbers, IsEven);
                Console.WriteLine($"Первое четное число: {firstEven}");
            }

            private static IEnumerable<T> Filter<T>(IEnumerable<T> source, Predicate<T> predicate)
            {
                return source.Where(item => predicate(item));
            }

            private static T FindFirst<T>(IEnumerable<T> source, Predicate<T> predicate)
            {
                return source.First(item => predicate(item));
            }

            private static bool IsEven(int number) => number % 2 == 0;
        }

        // Демонстрация анонимных методов
        public static class AnonymousMethodsDemo
        {
            public delegate void MessageHandler(string message);

            public static void Demo()
            {
                Console.WriteLine("\n=== Демонстрация анонимных методов ===");

                MessageHandler handler = delegate (string message)
                {
                    Console.WriteLine($"Получено сообщение: {message}");
                };

                handler("Привет, мир!");

                Action<int, int> sum = delegate (int x, int y)
                {
                    Console.WriteLine($"Сумма: {x + y}");
                };

                sum(5, 3);
            }
        }

        // Демонстрация лямбда-выражений
        public static class LambdaExpressionsDemo
        {
            public static void Demo()
            {
                Console.WriteLine("\n=== Демонстрация лямбда-выражений ===");

                Func<int, int> square = x => x * x;
                Console.WriteLine($"Квадрат числа 5: {square(5)}");

                Func<int, int, int> add = (x, y) => x + y;
                Console.WriteLine($"Сумма чисел 3 и 4: {add(3, 4)}");

                Action<string> print = message =>
                {
                    Console.WriteLine($"Сообщение: {message}");
                    Console.WriteLine($"Длина сообщения: {message.Length}");
                };

                print("Тестовое сообщение");
            }
        }

        // Демонстрация событий
        public static class EventsDemo
        {
            public class Button
            {
                public event EventHandler Click;
                public event EventHandler<string> MessageReceived;

                public void SimulateClick()
                {
                    Click?.Invoke(this, EventArgs.Empty);
                }

                public void SimulateMessage(string message)
                {
                    MessageReceived?.Invoke(this, message);
                }
            }

            public static void Demo()
            {
                Console.WriteLine("\n=== Демонстрация событий ===");

                var button = new Button();

                // Подписка на событие
                button.Click += (sender, args) => Console.WriteLine("Кнопка нажата!");
                button.MessageReceived += (sender, message) => Console.WriteLine($"Получено сообщение: {message}");

                // Вызов событий
                button.SimulateClick();
                button.SimulateMessage("Привет!");
            }
        }

        // Демонстрация замыканий
        public static class ClosuresDemo
        {
            public static void Demo()
            {
                Console.WriteLine("\n=== Демонстрация замыканий ===");

                int counter = 0;

                Func<int> increment = () =>
                {
                    counter++;
                    return counter;
                };

                Console.WriteLine($"Счетчик: {increment()}"); 
                Console.WriteLine($"Счетчик: {increment()}"); 
                Console.WriteLine($"Счетчик: {increment()}"); 

            }
        }

        // Демонстрация строк и класса System.String
        public static class StringBasicsDemo
        {
            public static void Demo()
            {
                Console.WriteLine("\n=== Демонстрация строк и класса System.String ===");

                // Создание строк
                string str1 = "Hello";
                string str2 = new string(new char[] { 'H', 'e', 'l', 'l', 'o' });
                string str3 = String.Intern("Hello");

                // Сравнение строк
                Console.WriteLine($"str1 == str2: {str1 == str2}");
                Console.WriteLine($"ReferenceEquals(str1, str2): {ReferenceEquals(str1, str2)}");
                Console.WriteLine($"ReferenceEquals(str1, str3): {ReferenceEquals(str1, str3)}");

                // Свойства строки
                Console.WriteLine($"Длина строки: {str1.Length}");
                Console.WriteLine($"Пустая строка: {String.Empty}");
                Console.WriteLine($"Null строка: {(string)null}");
            }
        }

        // Демонстрация операций со строками
        public static class StringOperationsDemo
        {
            public static void Demo()
            {
                Console.WriteLine("\n=== Демонстрация операций со строками ===");

                string text = "Hello, World!";

                // Основные операции
                Console.WriteLine($"Верхний регистр: {text.ToUpper()}");
                Console.WriteLine($"Нижний регистр: {text.ToLower()}");
                Console.WriteLine($"Подстрока: {text.Substring(0, 5)}");
                Console.WriteLine($"Замена: {text.Replace("World", "C#")}");
                Console.WriteLine($"Разделение: {string.Join(", ", text.Split(','))}");

                // Поиск
                Console.WriteLine($"Содержит 'World': {text.Contains("World")}");
                Console.WriteLine($"Индекс 'World': {text.IndexOf("World")}");
                Console.WriteLine($"Начинается с 'Hello': {text.StartsWith("Hello")}");
                Console.WriteLine($"Заканчивается на '!': {text.EndsWith("!")}");
            }
        }

        // Демонстрация форматирования и интерполяции строк
        public static class StringFormattingDemo
        {
            public static void Demo()
            {
                Console.WriteLine("\n=== Демонстрация форматирования и интерполяции строк ===");

                string name = "Иван";
                int age = 25;
                double price = 1234.56;

                string format1 = String.Format("Имя: {0}, Возраст: {1}", name, age);
                Console.WriteLine(format1);

                string format2 = $"Имя: {name}, Возраст: {age}";
                Console.WriteLine(format2);

                Console.WriteLine($"Цена: {price:C}"); 
                Console.WriteLine($"Цена: {price:F2}"); 
                Console.WriteLine($"Цена: {price:N2}"); 

                DateTime now = DateTime.Now;
                Console.WriteLine($"Дата: {now:dd.MM.yyyy}");
                Console.WriteLine($"Время: {now:HH:mm:ss}");
            }
        }

        // Демонстрация класса StringBuilder
        public static class StringBuilderDemo
        {
            public static void Demo()
            {
                Console.WriteLine("\n=== Демонстрация класса StringBuilder ===");

                StringBuilder sb = new StringBuilder();

                sb.Append("Привет");
                sb.Append(" ");
                sb.Append("мир!");
                Console.WriteLine($"Результат: {sb}");

                sb.AppendLine();
                sb.AppendLine("Новая строка");
                Console.WriteLine($"Результат: {sb}");

                sb.Insert(6, " красивый");
                Console.WriteLine($"Результат: {sb}");

                sb.Remove(6, 9);
                Console.WriteLine($"Результат: {sb}");

                // Очистка
                sb.Clear();
                Console.WriteLine($"Результат после очистки: {sb}");

                // Эффективное построение строки
                for (int i = 0; i < 1000; i++)
                {
                    sb.Append(i.ToString());
                }
                Console.WriteLine($"Длина строки: {sb.Length}");
            }
        }
    }
}
