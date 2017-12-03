/*
 Написать программу, которая запрашивает с клавиатуры число N и выводит на экран следующее «изображение», состоящее из N строк:
 */

namespace Task3
{
    using System;

    public class Program3
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the number N.");
            int.TryParse(Console.ReadLine(), out int n);
            int space = ((n * 2) - 1) / 2;
            int sign = 1;
            while (space > -1)
            {
                Print2(space, ' ', false);
                Print2(sign, '*', true);
                sign += 2;
                space--;
            }

            Console.ReadKey();
        }

        public static void Print2(int n, char symbol, bool flag)
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
