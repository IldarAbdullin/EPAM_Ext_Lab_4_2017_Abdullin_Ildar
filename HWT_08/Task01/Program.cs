/*
 Написать программу, выполняющую сортировку массива строк по возрастанию длины. 
 Если строки состоят из равного числа символов, их следует отсортировать по алфавиту. 
 Реализовать метод сравнения строк отдельным методом, передаваемым в сортировку через делегат.
 */

namespace HWT_08
{
    using System;

    public class Program
    {
        public delegate bool Comparison(ref string str1, ref string str2);

        public static void Main(string[] args)
        {
            Comparison comparison = new Comparison(Compare);
            string[] arr = InputLine();
            Sort(ref arr, comparison);
            foreach (var c in arr)
            {
                Console.WriteLine($"{c} ");
            }

            Console.ReadLine();
        }

        public static bool Compare(ref string str1, ref string str2)
        {
            int contrast = str1.CompareTo(str2);
            return contrast == 1;
        }

        public static void Sort(ref string[] arr, Comparison comparison)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (comparison(ref arr[j], ref arr[j + 1]))
                    {
                        var elem = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = elem;
                    }
                }
            }
        }

        public static string[] InputLine()
        {
            Console.WriteLine("Enter words separated by spaces");
            string str = Console.ReadLine();
            string[] mas = str.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return mas;
        }
    }
}
