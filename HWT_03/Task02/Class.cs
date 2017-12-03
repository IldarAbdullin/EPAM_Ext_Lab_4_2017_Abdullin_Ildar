namespace Task02
{
    using System;

    public class Class
    {
        public static void RandomArr(ref int[,,] arr, int size1, int size2, int size3)
        {
            Random rnd = new Random();
            for (int i = 0; i < size1; i++)
            {
                for (int j = 0; j < size2; j++)
                {
                    for (int k = 0; k < size3; k++)
                    {
                        arr[i, j, k] = rnd.Next(-10, 10);
                    }
                }
            }
        }

        public static void ChangePositive(ref int[,,] arr, int size1, int size2, int size3)
        {
            for (int i = 0; i < size1; i++)
            {
                for (int j = 0; j < size2; j++)
                {
                    for (int k = 0; k < size3; k++)
                    {
                        if (arr[i, j, k] > 0)
                        {
                            arr[i, j, k] = 0;
                        }
                    }
                }
            }

            Console.WriteLine("Positive numbers are changed to 0");
        }

        public static void PrintArray(int[,,] arr, int size1, int size2, int size3)
        {
            for (int i = 0; i < size1; i++)
            {
                for (int j = 0; j < size2; j++)
                {
                    for (int k = 0; k < size3; k++)
                    {
                        Console.Write("{0}\t ", arr[i, j, k]);
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
