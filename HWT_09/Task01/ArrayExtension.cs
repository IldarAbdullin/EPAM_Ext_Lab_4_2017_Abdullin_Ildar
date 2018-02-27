namespace HWT_09
{
    using System;
    using System.Collections.Generic;

    public static class ArrayExtension
    {
        public static int Sum(this IEnumerable<int> array)
        {
            int sum = 0;
            foreach (var c in array)
            {
                sum += c;
            }

            return sum;
        }

        public static void Print(this IEnumerable<int> array)
        {
            foreach (var c in array)
            {
                Console.Write($"{c} ");
            }

            Console.WriteLine();
        }
    }
}
