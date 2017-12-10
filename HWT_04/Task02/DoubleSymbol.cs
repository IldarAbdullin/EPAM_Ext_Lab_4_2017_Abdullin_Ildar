namespace Task02
{
    using System;
    using System.Linq;

    public class DoubleSymbol
    {
        public static void InputAndCalc()
        {
            int flag = 1;
            while (flag == 1)
            {
                Console.WriteLine("Enter a new line:\n");
                string str = Console.ReadLine();

                Console.WriteLine("Enter a substring:\n");
                string substr = Console.ReadLine();
                DoublingSymbols(ref str, substr);
                Console.WriteLine("If you want to enter a new line, enter 1, otherwise 0:\n");
                int.TryParse(Console.ReadLine(), out flag);
                if (flag == 1)
                {
                    Console.Clear();
                }
            }
        }

        public static void UniqueSymbols(ref string str)
        {
            int i = 0;
            while (true)
            {
                var tmp = str[i].ToString();
                str = str.Replace(tmp, String.Empty);
                str = str.Insert(i, tmp);
                i++;
                if (str.Length - 1 < i)
                {
                    break;
                }
            }
        }

        public static void DoublingSymbols(ref string str, string substr)
        {
            UniqueSymbols(ref substr);
            Console.WriteLine(substr);
            for (int i = 0; i < substr.Length; i++)
            {
                if (str.Contains(substr[i]))
                {
                    str = str.Replace(substr[i].ToString(), string.Format("{0}{1}", substr[i], substr[i]));
                }
            }

            Console.WriteLine("The string after doubling the characters\n {0}", str);
        }
    }
}
