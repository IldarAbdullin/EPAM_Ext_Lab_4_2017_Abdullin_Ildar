namespace HWT_04
{
    using System;
    using System.Linq;

    public static class Class//todo pn как интересно. что же делает этот класс?
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
			//todo pn то чувство, когда говорил ребятам не использовать хардкод, а использовать Char.IsSeparator, но они всё равно используют хардкод :С
            int averageLenght = words.Aggregate(0, (count, nextWord) => count += nextWord.Length) / words.Length;
            Console.WriteLine("average word length = {0}", averageLenght);
        }
    }
}
/* просто оставлю это здесь
------ StyleCop 5.0 (build 5.0.6419.0) started ------

Pass 1:   Task01 - \Class.cs
Pass 1:   Task01 - \Program.cs
Pass 1:   Task01 - \Properties\AssemblyInfo.cs
Pass 1:   Task02 - \Class.cs
Pass 1:   Task02 - \Program.cs
Pass 1:   Task02 - \Properties\AssemblyInfo.cs
Pass 1:   Task03 - \Class.cs
Pass 1:   Task03 - \Program.cs
Pass 1:   Task03 - \Properties\AssemblyInfo.cs

------ StyleCop completed ------

========== Violation Count: 6 ==========*/
