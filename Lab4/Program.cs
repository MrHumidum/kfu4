using System;

namespace Lab_4
{
    class Program
    {
        /// <summary>
        /// Возвращает наибольшее из двух целых чисел.
        /// </summary>
        /// <param name="num1">Первое число.</param>
        /// <param name="num2">Второе число.</param>
        /// <returns>Наибольшее из двух чисел.</returns>

        static int Maximum(int num1, int num2)
        {
            return Math.Max(num1, num2);
        }

        /// <summary>
        /// Меняет местами значения двух передаваемых параметров.
        /// </summary>
        /// <typeparam name="T">Тип передаваемых параметров.</typeparam>
        /// <param name="a">Первый параметр, передаваемый по ссылке.</param>
        /// <param name="b">Второй параметр, передаваемый по ссылке.</param>
        static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Вычисляет факториал числа с использованием выходного параметра.
        /// </summary>
        /// <param name="number">Число, для которого вычисляется факториал (должно быть >= 0).</param>
        /// <param name="result">Результат вычисления факториала.</param>
        /// <returns>Возвращает true, если вычисление успешно, иначе false при переполнении.</returns>
        static bool TryCalculateFactorial(int number, out long result)
        {
            result = 1;

            if (number < 0)
            {
                Console.WriteLine("Факториал определён только для неотрицательных чисел.");
                return false;
            }
            try
            {
                checked
                {
                    for (int i = 1; i <= number; i++)
                    {
                        result *= i;
                    }
                }
                return true;
            }
            catch (OverflowException)
            {
                result = 0;
                return false;
            }
        }
        /// <summary>
        /// Рекурсивно вычисляет факториал числа.
        /// </summary>
        /// <param name="number">Число, для которого вычисляется факториал.</param>
        /// <returns>Факториал числа.</returns>
        static long RecursiveFactorial(int number)
        {
            if (number < 0)
                throw new ArgumentException("Факториал определён только для неотрицательных чисел.");
            if (number == 0 || number == 1)
                return 1;
            return number * RecursiveFactorial(number - 1);
        }
        /// <summary>
        /// Вычисляет НОД (наибольший общий делитель) двух чисел с использованием алгоритма Евклида.
        /// </summary>
        /// <param name="a">Первое число.</param>
        /// <param name="b">Второе число.</param>
        /// <returns>НОД двух чисел.</returns>

        static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        /// <summary>
        /// Вычисляет НОД (наибольший общий делитель) трёх чисел с использованием алгоритма Евклида.
        /// </summary>
        /// <param name="a">Первое число.</param>
        /// <param name="b">Второе число.</param>
        /// <param name="c">Третье число.</param>
        /// <returns>НОД трёх чисел.</returns>

        static int GCD(int a, int b, int c)
        {
            return GCD(GCD(a, b), c);
        }

        /// <summary>
        /// Рекурсивно вычисляет значение n-го числа ряда Фибоначчи.
        /// </summary>
        /// <param name="n">Номер числа в ряду Фибоначчи (должен быть положительным).</param>
        /// <returns>Значение n-го числа ряда Фибоначчи.</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если номер числа меньше или равен 0.</exception>

        static int Fibonacci(int n)
        {
            if (n <= 0)
                throw new ArgumentException("Порядковый номер должен быть положительным числом.");
            if (n == 1 || n == 2)
                return 1;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }



        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 5.1");
            /*
            Написать метод, возвращающий наибольшее из двух чисел. Входные
параметры метода – два целых числа. Протестировать метод.
*/
            Console.WriteLine($"Наибольшее значение из цифр 12 и 2 = {Maximum(12, 2)}");

            Console.WriteLine("Упражнение 5.2");
            /*
Написать метод, который меняет местами значения двух передаваемых
параметров. Параметры передавать по ссылке. Протестировать метод.
            */
            int num1 = 5, num2 = 10;
            Console.WriteLine($"До Swap: num1 = {num1}, num2 = {num2}");
            Swap(ref num1, ref num2);
            Console.WriteLine($"После Swap: num1 = {num1}, num2 = {num2}");

            Console.WriteLine("Упражнение 5.3");
            /*
            Написать метод вычисления факториала числа, результат вычислений
передавать в выходном параметре. Если метод отработал успешно, то вернуть значение true;
если в процессе вычисления возникло переполнение, то вернуть значение false. Для
отслеживания переполнения значения использовать блок checked.
            */
            if (TryCalculateFactorial(20, out long factorial))
            {
                Console.WriteLine($"Факториал числа 20 равен {factorial}.");
            }
            else
            {
                Console.WriteLine("Произошло переполнение при вычислении факториала.");
            }

            Console.WriteLine("Упражнение 5.4");
            /*
Написать рекурсивный метод вычисления факториала числа.
            */
            Console.Write("Введите число для вычисления факториала рекурсивным методом: ");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                Console.WriteLine($"Факториал числа {number} равен {RecursiveFactorial(number)}.");
            }
            else
            {
                Console.WriteLine("Ошибка ввода числа");
            }


            Console.WriteLine("Домашнее задание 5.1");
            /*
Написать метод, который вычисляет НОД двух натуральных чисел
(алгоритм Евклида). Написать метод с тем же именем, который вычисляет НОД трех
натуральных чисел.
            */
            Console.Write("Введите три числа для вычисления НОД: ");
            if (int.TryParse(Console.ReadLine(), out int number1) && int.TryParse(Console.ReadLine(), out int number2) && int.TryParse(Console.ReadLine(), out int number3))
            {
                Console.WriteLine($"НОД чисел({number1}, {number2}) = {GCD(number1, number2)}");
                Console.WriteLine($"НОД({number1}, {number2}, {number3}) = {GCD(number1, number2, number3)}");
            }
            else
            {
                Console.WriteLine("Ошибка ввода трёх чисел для вычисления НОД");
            }

            Console.WriteLine("Домашнее задание 5.2");
            /*
Написать рекурсивный метод, вычисляющий значение n-го числа
ряда Фибоначчи. Ряд Фибоначчи – последовательность натуральных чисел 1, 1, 2, 3, 5, 8,
13... Для таких чисел верно соотношение Fk = Fk-1 + Fk-2 .
            */

            Console.Write("Введите номер числа Фибоначчи: ");

            if (int.TryParse(Console.ReadLine(), out int index))
            {
                Console.WriteLine($"Число Фибоначчи под номером {index} равно {Fibonacci(index)}.");

            }
            else
            {
                Console.WriteLine("Ошибка ввода номерa числа Фибоначчи");
            }
        }




    }
}

