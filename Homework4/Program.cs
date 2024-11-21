using System;

namespace Homework4
{
    class Program
    {/// <summary>
     /// Генерирует массив из 20 случайных чисел и позволяет пользователю ввести два числа для обмена местами в массиве.
     /// Если оба числа присутствуют в массиве, их значения меняются местами, и результат выводится на экран.
     /// </summary>
        static void Ex1()
        {
            Random rnd = new Random();
            int[] list = new int[20];
            for (int i = 0; i < 20; i++)
            {
                list[i] = rnd.Next();
            }
            foreach (int number in list)
            {
                Console.WriteLine(number);
            }
            Console.Write("Введите 2 цифры, которые вы хотите поменять местами: ");
            if ((int.TryParse(Console.ReadLine(), out int number1) && int.TryParse(Console.ReadLine(), out int number2)))
            {
                Console.WriteLine();
                if (list.Contains(number1) && list.Contains(number2))
                {
                    for (int i = 0; i < 20; i++)
                    {
                        if (list[i] == number1)
                        {
                            list[i] = number2;
                        }
                        else if (list[i] == number2)
                        {
                            list[i] = number1;
                        }
                    }
                    foreach (int number in list)
                    {
                        Console.WriteLine(number);
                    }
                }
                else
                {
                    Console.WriteLine("Нужно, чтобы оба числа были из массива");
                }
            }
            else
            {
                Console.WriteLine("Ошибка ввода данных");
            }
        }
        /// <summary>
        /// Вычисляет сумму элементов массива, произведение всех элементов и среднее арифметическое элементов массива.
        /// Результаты возвращаются через параметры `ref` (произведение) и `out` (среднее арифметическое).
        /// </summary>
        /// <param name="numbers">Массив чисел.</param>
        /// <param name="product">Произведение элементов массива (выходной параметр, передается по ссылке).</param>
        /// <param name="average">Среднее арифметическое элементов массива (выходной параметр, передается по ссылке).</param>
        /// <returns>Сумма элементов массива.</returns>

        static double Ex2(double[] numbers, ref double product, out double average)
        {
            double sum = 0;
            product = 1;

            foreach (var number in numbers)
            {
                sum += number;
                product *= number;
            }

            average = numbers.Length > 0 ? sum / numbers.Length : 0;

            return sum;
        }
        /// <summary>
        /// Запрашивает у пользователя ввод числа. Если введённое число от 0 до 9, рисует его в виде символов `#`.
        /// Если введено некорректное число или слово "exit" или "закрыть", программа завершает работу.
        /// В случае ввода нечислового значения выбрасывает исключение.
        /// </summary>
        static void Ex3()
        {
            try
            {
                Console.Write("Введите число (или 'exit'/'закрыть' для завершения): ");
                string input = Console.ReadLine();

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase) ||
                    input.Equals("закрыть", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Программа завершена.");
                    return;
                }

                if (!int.TryParse(input, out int number))
                {
                    throw new FormatException("Введено не число.");
                }

                if (number >= 0 && number <= 9)
                {
                    DrawNumber(number);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка: число должно быть от 0 до 9!");
                    Thread.Sleep(3000);
                    Console.ResetColor();
                }
            }
            catch (FormatException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Ошибка: {ex.Message}");
                Thread.Sleep(3000);
                Console.ResetColor();
            }

            Ex3();
        }

        /// <summary>
        /// Отображает число в виде символа `#` в формате цифры от 0 до 9, используя многократные строки.
        /// </summary>
        /// <param name="number">Число от 0 до 9.</param>
        static void DrawNumber(int number)
        {
            string[] digits = new string[]
            {
                "###\n# #\n# #\n# #\n###", // 0
                "  #\n  #\n  #\n  #\n  #", // 1
                "###\n  #\n###\n#  \n###", // 2
                "###\n  #\n###\n  #\n###", // 3
                "# #\n# #\n###\n  #\n  #", // 4
                "###\n#  \n###\n  #\n###", // 5
                "###\n#  \n###\n# #\n###", // 6
                "###\n  #\n  #\n  #\n  #", // 7
                "###\n# #\n###\n# #\n###", // 8
                "###\n# #\n###\n  #\n###"  // 9
            };

            Console.WriteLine(digits[number]);
        }

        /// <summary>
        /// Перечисление, описывающее уровни ворчливости деда.
        /// </summary>
        enum GrumpinessLevel
        {
            Low,
            Medium,
            High,
            Extreme
        }
        /// <summary>
        /// Структура, представляющая "Деда" с именем, уровнем ворчливости, массивом фраз и количеством синяков.
        /// Включает метод для подсчета фингалов, если дед использует матерные слова из переданного списка.
        /// </summary>
        struct Ded
        {
            public string Name;
            public GrumpinessLevel Grumpiness;
            public string[] Phrases;
            public int Bruises;

            public Ded(string name, GrumpinessLevel grumpiness, string[] phrases)
            {
                Name = name;
                Grumpiness = grumpiness;
                Phrases = phrases;
                Bruises = 0;
            }
            /// <summary>
            /// Проверяет наличие матерных слов в фразах деда и увеличивает количество фингалов за каждое найденное слово.
            /// </summary>
            /// <param name="swearWords">Список матерных слов для проверки.</param>
            /// <returns>Количество фингалов, полученных дедом.</returns>
            public int CheckSwearWords(params string[] swearWords)
            {
                int bruisesAdded = 0;

                foreach (var phrase in Phrases)
                {
                    foreach (var swear in swearWords)
                    {
                        if (phrase.Contains(swear, StringComparison.OrdinalIgnoreCase))
                        {
                            Bruises++;
                            bruisesAdded++;
                        }
                    }
                }

                return bruisesAdded;
            }
        }
        /// <summary>
        /// Основной метод программы, который выполняет все упражнения:
        /// 1. Выводит массив случайных чисел и меняет местами два выбранных числа.
        /// 2. Вычисляет сумму, произведение и среднее арифметическое элементов массива.
        /// 3. Запрашивает ввод числа и рисует его, если оно от 0 до 9, или завершает программу.
        /// 4. Создает 5 дедов и проверяет их фразы на наличие матерных слов, увеличивая количество фингалов.
        /// </summary>
        /// <param name="args">Аргументы командной строки (не используются).</param>

        static void Main(string[] args)
        {
            Console.WriteLine("№1");
            /*Вывести на экран массив из 20 случайных чисел. Ввести два числа из этого массива,
которые нужно поменять местами. Вывести на экран получившийся массив.*/
            Ex1();

            Console.WriteLine("№2");
            /*Написать метод, где в качества аргумента будет передан массив (ключевое слово
params). Вывести сумму элементов массива (вернуть). Вывести (ref) произведение
массива. Вывести (out) среднее арифметическое в массиве.*/
            double product = 0;
            double sum = Ex2(new double[] { 1, 2, 3, 4, 5 }, ref product, out double average);

            Console.WriteLine($"Массив: [1, 2, 3, 4, 5]");
            Console.WriteLine($"Сумма: {sum}");
            Console.WriteLine($"Произведение: {product}");
            Console.WriteLine($"Среднее: {average}");


            Console.WriteLine("№3");
            /*Пользователь вводит числа. Если числа от 0 до 9, то необходимо в консоли нарисовать
изображение цифры в виде символа #.Если число больше 9 или меньше 0, то консоль
должна окраситься в красный цвет на 3 секунды и вывести сообщение об ошибке. Если
пользователь ввёл не цифру, то программа должна выпасть в исключение. Программа
завершает работу, если пользователь введёт слово: exit или закрыть (оба варианта
должны сработать) - консоль закроется.*/
            Ex3();


            Console.WriteLine("№4");
            /*Создать структуру Дед. У деда есть имя, уровень ворчливости (перечисление), массив
фраз для ворчания (прим.: “Проститутки!”, “Гады!”), количество синяков от ударов
бабки = 0 по умолчанию. Создать 5 дедов. У каждого деда - разное количество фраз для
ворчания. Напишите метод (внутри структуры), который на вход принимает деда,
список матерных слов (params). Если дед содержит в своей лексике матерные слова из
списка, то бабка ставит фингал за каждое слово. Вернуть количество фингалов.*/
            Ded ded1 = new Ded("Иван", GrumpinessLevel.Low, new[] { "Проститутки!", "Лень кругом!" });
            Ded ded2 = new Ded("Пётр", GrumpinessLevel.Medium, new[] { "Гады!", "Опять интернет включили!", "Жизнь плохая!", "Проститутки!" });
            Ded ded3 = new Ded("Семен", GrumpinessLevel.High, new[] { "Пошляки!", "Бездельники!" });
            Ded ded4 = new Ded("Григорий", GrumpinessLevel.Low, new[] { "Почему хлеб дорогой?" });
            Ded ded5 = new Ded("Алексей", GrumpinessLevel.Medium, new[] { "Работы нет!", "Все уехали!" });

            Ded[] dedArray = { ded1, ded2, ded3, ded4, ded5 };
            string[] swearWords = { "Проститутки", "Гады", "Пошляки" };
            foreach (var ded in dedArray)
            {
                int bruises = ded.CheckSwearWords(swearWords);
                Console.WriteLine($"Дед {ded.Name} получил {bruises} фингал(а/ов). Всего фингалов: {ded.Bruises}");
            }
        }
    }


}


