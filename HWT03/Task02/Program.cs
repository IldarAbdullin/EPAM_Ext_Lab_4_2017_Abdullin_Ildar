/*
 Написать программу, которая заменяет все положительные элементы в трёхмерном массиве на нули. 
 Число элементов в массиве и их тип определяются разработчиком.
  */

namespace Task02
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int i = 4;
            int j = 4;
            int k = 4;
            int[,,] array3D = new int[i, j, k];
            Class.RandomArr(ref array3D, i, j, k);
            Class.PrintArray(array3D, i, j, k);
            Class.ChangePositive(ref array3D, i, j, k);
            Class.PrintArray(array3D, i, j, k);
            Console.ReadKey();
        }       
    }
}
