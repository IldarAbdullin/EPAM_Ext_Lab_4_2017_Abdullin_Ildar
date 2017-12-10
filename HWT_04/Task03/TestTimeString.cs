namespace Task03
{
    using System;
    using System.Diagnostics;
    using System.Text;

    public class TestTimeString
    {
        public const int NumTests = 4; ////количество тестов

        public static void InputAndCalc()
        {
            int flag = 1;
            while (flag == 1)
            {
                Console.WriteLine("Enter number of steps:\n");
                int.TryParse(Console.ReadLine(), out int n);
                for (int i = 0; i < NumTests; i++)
                {
                    CheckString(n);
                    CheckStringBuilder(n);
                    n = n * 10;
                    Console.WriteLine();
                }

                Console.WriteLine("If you want to enter a new line, enter 1, otherwise 0:\n");
                int.TryParse(Console.ReadLine(), out flag);
                if (flag == 1)
                {
                    Console.Clear();
                }
            }
        }

        public static void CheckString(int n)
        {
            var sw = new Stopwatch();
            sw.Start();
            string str = "";
            for (int i = 0; i < n; i++)
            {
                str += "*";
            }

            sw.Stop();
            Console.WriteLine($"Operating time string after {n} steps:\n" + sw.Elapsed);
        }

        public static void CheckStringBuilder(int n)
        {
            var sw = new Stopwatch();
            sw.Start();
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                str.Append("*");
            }

            sw.Stop();
            Console.WriteLine($"Operating time StringBuilder after {n} steps:\n" + sw.Elapsed);
        }
    }
}
