namespace Task02
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Text
    {
        private Dictionary<string, int> words = new Dictionary<string, int>();
        private List<string> masWord = new List<string>();
        private string str  = string.Empty;

        public Text()
        {           
        }

        public void InputStr()
        {
            Console.WriteLine("Enter the string");
            while (true)
            {
                this.str = Console.ReadLine();
                if (this.str != string.Empty)
                {
                    break;
                }

                Console.WriteLine("An empty string is entered. Re-enter");
            }

            this.str = this.str.ToLower();
            Console.WriteLine($"The resulting string: {this.str}");
            string[] mas = this.str.Split(new[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);
            this.masWord.AddRange(mas);
        }

        public void FileStr()
        {
            using (var sr = new StreamReader(@"C:\Users\1\Documents\Visual Studio 2017\Projects\EPam\EPAM_Ext_Lab_4_2017_Abdullin_Ildar\HWT_07\Task02\text.txt"))
            {
                while (!sr.EndOfStream)
                {
                    this.str = sr.ReadLine().ToLower();
                }
            }

            Console.WriteLine($"The resulting string: {this.str}");
            string[] mas = this.str.Split(new[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);
            this.masWord.AddRange(mas);
        }

        public void CalcRepeat()
        {
            foreach (var i in this.masWord)
            {
                if (this.words.ContainsKey(i))
                {
                    this.words.TryGetValue(i, out int count);
                    this.words[i] = ++count;
                }
                else
                {
                    this.words.Add(i, 1);
                }
            }
        }

        public void PrintDict()
        {
            foreach (var i in this.words)
            {
                Console.WriteLine($"Word: {i.Key} - number of occurrences: {i.Value}");
            }
        }
    }
}
