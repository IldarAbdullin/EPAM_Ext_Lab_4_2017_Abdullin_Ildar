/*
 Элемент двумерного массива считается стоящим на чётной позиции, 
 если сумма номеров его позиций по обеим размерностям является чётным числом (например, [1,1] – чётная позиция, а [1,2] - нет). 
 Определить сумму элементов массива, стоящих на чётных позициях.
  */

namespace Task04
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the size1 of the array");
            int.TryParse(Console.ReadLine(), out int size1);

            Console.WriteLine("Enter the size2 of the array");
            int.TryParse(Console.ReadLine(), out int size2);

            int[,] arr = new int[size1, size2];
            Class.RandomArray(ref arr, size1, size2);
            Class.PrintArray(arr, size1, size2);
            Class.SumEven(arr, size1, size2);
            Class.PrintArray(arr, size1, size2);
            Console.ReadKey();
        }      
    }
}
