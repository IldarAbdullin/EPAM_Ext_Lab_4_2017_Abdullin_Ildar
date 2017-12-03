namespace HWT03
{
    using System;

    public static class Class
    {
        public static void RandomArr(ref int[] arr, int rndMax, int rndMin)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(rndMin, rndMax);
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

        public static void BubleSort(ref int[] arr)
        {
            for (int j = 0; j < arr.Length; j++)
            {
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        int temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                    }
                }
            }

            Console.WriteLine("The array was sorted");
        }
    }
}
