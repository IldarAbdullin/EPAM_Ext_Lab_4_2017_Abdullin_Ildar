namespace Task02
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class Program
    {
        public static void Main(string[] args)
        {
            Text text = new Text();
            Console.WriteLine("Enter 1 if you want to enter the string in your hand or type 2 if you want to read text from a file.");
            int.TryParse(Console.ReadLine(), out int n);
            switch (n)
            {
                case 1:
                    text.InputStr();
                    break;
                case 2:
                    text.FileStr();
                    break;
                case 0:
                    Console.WriteLine("Invalid value entered!");
                    break;
            }
                        
            text.CalcRepeat();
            text.PrintDict();
            Console.ReadKey();
        }
    }
}
