/*
 Написать программу, которая запрашивает с клавиатуры число N и выводит на экран следующее «изображение», состоящее из N строк:
 */

namespace Task2
{
    using System;

    public class Program2
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the number N.");
            int.TryParse(Console.ReadLine(), out int n);
            Print1(n, '*');
            Console.ReadKey();
        }

        public static void Print1(int n, char symbol)
        {
            for (int i = 0; i < n; i++)
            {
                int count = i;
                while (count >= 0)
                { 
                    Console.Write("{0}", symbol);
                    count -= 1;
                }

                Console.WriteLine();
            }
        }
    }
}
