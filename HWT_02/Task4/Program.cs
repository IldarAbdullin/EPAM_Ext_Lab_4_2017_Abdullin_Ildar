/*
 Написать программу, которая запрашивает с клавиатуры число N и выводит на экран следующее «изображение», состоящее из N треугольников:
 */

namespace Task4
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the number N.");
            int.TryParse(Console.ReadLine(), out int n);
            for (int i = 0; i < n; i++)
            {
                Print4(n, i);
            }

            Console.ReadKey();
        }

        ////выводит i-ый треугольник, среди n треугольников
        public static void Print4(int n, int i)
        {
            int space = ((n * 2) - 1) / 2;
            int space2 = i;
            int sign = 1;
            while (space2 > -1)
            {
                Print3(space, ' ', false);
                Print3(sign, '*', true);
                sign += 2;
                space--;
                space2--;
            }
        }

        ////печает symbol n-раз и если flag=true, переносит каретку на новую строку
        public static void Print3(int n, char symbol, bool flag)
        {
            while (n > 0)
            {
                Console.Write("{0}", symbol);
                n--;
            }

            if (flag)
            {
                Console.WriteLine();
            }
        }
    }
}
