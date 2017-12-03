/*
Написать программу, которая определяет сумму неотрицательных элементов в одномерном массиве. 
Число элементов в массиве и их тип определяются разработчиком.
  */

namespace Task03
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of the array");
            int.TryParse(Console.ReadLine(), out int size);
            int[] arr = new int[size];

            Class.RandomArr(ref arr, -10, 10);
            Class.PrintArray(arr);
            Class.SumPositive(arr);
            Console.ReadKey();
        }      
    }
}
