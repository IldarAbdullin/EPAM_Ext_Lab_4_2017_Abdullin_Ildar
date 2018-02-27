namespace HWT_04
{
    using System;
    using System.Linq;

    public static class AvgWord
    {
        public static void InputAndCalc()
        {
            int flag = 1;
            while (flag == 1)
            {
                Console.WriteLine("Enter a new line:\n");
                string str = Console.ReadLine();
                AvgWordLength(str);
                Console.WriteLine("If you want to enter a new line, enter 1, otherwise 0:\n");
                int.TryParse(Console.ReadLine(), out flag);
                if (flag == 1)
                {
                    Console.Clear();
                }
            }
        }

        public static void AvgWordLength(string str)
        {
            string[] words = str.Split(new[] { ' ', '-', '!', '?', ':', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            int averageLenght = words.Aggregate(0, (count, nextWord) => count += nextWord.Length) / words.Length;
            Console.WriteLine("average word length = {0}", averageLenght);
        }
    }
}
