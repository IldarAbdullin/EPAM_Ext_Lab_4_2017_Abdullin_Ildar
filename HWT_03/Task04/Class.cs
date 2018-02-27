namespace Task04
{
    using System;

    public class Class
    {
        public static void RandomArray(ref int[,] arr, int size1, int size2)
        {
            Random rnd = new Random();
            for (int i = 0; i < size1; i++)
            {
                for (int j = 0; j < size2; j++)
                {
                    arr[i, j] = rnd.Next(0, 10);
                }
            }
        }

        public static void SumEven(int[,] arr, int size1, int size2)
        {
            int sum = 0;
            for (int i = 0; i < size1; i++)
            {
                for (int j = 0; j < size2; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        sum += arr[i, j];
                    }
                }
            }

            Console.WriteLine("The sum of the elements standing of even postions = {0}", sum);
        }

        public static void PrintArray(int[,] arr, int size1, int size2)
        {
            for (int i = 0; i < size1; i++)
            {
                for (int j = 0; j < size2; j++)
                {
                    Console.Write("{0}\t ", arr[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
