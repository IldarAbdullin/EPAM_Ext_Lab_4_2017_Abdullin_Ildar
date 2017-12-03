/*
  Написать программу, которая генерирует случайным образом элементы массива (число элементов в массиве и их тип определяются разработчиком),
  определяет для него максимальное и минимальное значения, сортирует массив и выводит полученный результат на экран.
Примечание: LINQ запросы и готовые функции языка (Sort, Max и т.д.) использовать в данном задании запрещается.
  */

namespace HWT03
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of the array");
            int.TryParse(Console.ReadLine(), out int size);
            int[] arr = new int[size];

            int rndMax = 100;
            int rndMin = -100;
            Class.RandomArr(ref arr, rndMax, rndMin);
            Class.PrintArray(arr);
            Class.BubleSort(ref arr);
            Class.PrintArray(arr);
            Console.ReadKey();
        }
    }
}
