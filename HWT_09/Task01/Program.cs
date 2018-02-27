/*Напишите расширяющий метод, который определяет сумму элементов массива.*/

namespace HWT_09
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            const int Random = 100;

            Console.WriteLine("Enter the size of the array");
            int.TryParse(Console.ReadLine(), out int size);
            int[] array = new int[size];
            Random rnd = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(Random);                
            }

            array.Print();
            int sumArray = array.Sum();
            Console.WriteLine($"The sum of array elements is {sumArray}");
            Console.ReadLine();
        }
    }
}
