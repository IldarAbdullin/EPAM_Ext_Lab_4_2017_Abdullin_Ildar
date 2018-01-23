/*
Написать методы поиска элемента в массиве(например, поиск всех положительных элементов в массиве) в виде:
1. Метода, реализующего поиск напрямую;
2. Метода, которому условие поиска передаётся через делегат;
3. Метода, которому условие поиска передаётся через делегат в виде анонимного метода;
4. Метода, которому условие поиска передаётся через делегат в виде лямбда-выражения;
5. LINQ-выражения
Сравнить скорость выполнения вычислений.
*/

namespace Task03
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public delegate bool Condition(int n);

    public class Program
    {
        public static void Main(string[] args)
        {
            const int Random = 1000;
            Console.WriteLine("Enter the size of the array");
            int.TryParse(Console.ReadLine(), out int size);
            int[] array = new int[size];
            int[] arrayPositive = new int[size];
            long[] testsTime = new long[size];
            Random rnd = new Random();
            Stopwatch stopWatch = new Stopwatch();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(Random) - (Random / 2);
            }

            for (var i = 0; i < size; i++)
            {
                stopWatch.Start();
                arrayPositive = SearchArray.FindPositive(array);
                stopWatch.Stop();
                testsTime[i] = stopWatch.ElapsedMilliseconds;
                stopWatch.Reset();
            }

            double avg = testsTime.Average();
            Array.Sort(testsTime);
            Console.WriteLine($"A method that implements the search directly - {avg}; {testsTime[size / 2]} ms");
            Array.Clear(testsTime, 0, testsTime.Length);

            for (var i = 0; i < size; i++)
            {
                stopWatch.Start();
                Predicate<int> condition = SearchArray.IsPostive;
                arrayPositive = SearchArray.FindPositive(array, condition);
                stopWatch.Stop();
                testsTime[i] = stopWatch.ElapsedMilliseconds;
                stopWatch.Reset();
            }

            avg = testsTime.Average();
            Array.Sort(testsTime);
            Console.WriteLine($"Search condition is passed through the delegate - {avg}; {testsTime[size / 2]} ms");
            Array.Clear(testsTime, 0, testsTime.Length);

            for (var i = 0; i < size; i++)
            {
                stopWatch.Start();
                arrayPositive = SearchArray.FindPositive(array, delegate(int n) { return n > 0; });
                stopWatch.Stop();
                testsTime[i] = stopWatch.ElapsedMilliseconds;
                stopWatch.Reset();
            }

            avg = testsTime.Average();
            Array.Sort(testsTime);
            Console.WriteLine($"Through the delegate in the form of an anonymous method - {avg}; {testsTime[size / 2]} ms");
            Array.Clear(testsTime, 0, testsTime.Length);

            for (var i = 0; i < size; i++)
            {
                stopWatch.Start();
                arrayPositive = SearchArray.FindPositive(array, x => x > 0);
                stopWatch.Stop();
                testsTime[i] = stopWatch.ElapsedMilliseconds;
                stopWatch.Reset();
            }

            avg = testsTime.Average();
            Array.Sort(testsTime);
            Console.WriteLine($"Through the delegate in the form of a lambda expression - {avg}; {testsTime[size / 2]} ms");
            Array.Clear(testsTime, 0, testsTime.Length);

            for (var i = 0; i < size; i++)
            {
                stopWatch.Start();
                arrayPositive = SearchArray.GetPositive(array);
                stopWatch.Stop();
                testsTime[i] = stopWatch.ElapsedMilliseconds;
                stopWatch.Reset();
            }

            avg = testsTime.Average();
            Array.Sort(testsTime);
            Console.WriteLine($"LINQ Expressions - {avg}; {testsTime[size / 2]} ms");
            Array.Clear(testsTime, 0, testsTime.Length);

            Console.ReadLine();
        }
    }
}
