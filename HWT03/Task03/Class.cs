namespace Task03
{
    using System;

    public class Class
    {
        public static void RandomArr(ref int[] arr, int rndMax, int rndMin)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(rndMax, rndMin);
            }
        }

        public static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0} ", arr[i]);
            }

            Console.WriteLine();
        }

        public static void SumPositive(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] >= 0)
                {
                    sum += arr[i];
                }
            }

            Console.WriteLine("The sum of nonnegative elements = {0}", sum);
        }
    }
}
