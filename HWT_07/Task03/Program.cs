namespace Task03
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            MyDynamicArray<int> array1 = new MyDynamicArray<int>();
            int[] array2 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            MyDynamicArray<int> array3 = new MyDynamicArray<int>(array2);

            for (int i = 0; i < array1.Capacity; i++)
            {
                array1.Add(i);
                Console.Write($" {array1[i]} ");
            }

            Console.WriteLine();
            ////array1.AddRange(array2);
            array3.Insert(100, 5);
            bool res = array3.Remove(9);
            Console.WriteLine(res);
            for (int i = 0; i < array3.Length; i++)
            {
                Console.Write($" {array3[i]} ");
            }
            
            Console.ReadLine();
        }
    }
}
