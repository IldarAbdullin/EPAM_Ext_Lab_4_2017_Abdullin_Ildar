/*
 Для выделения текстовой надписи можно использовать выделение жирным, курсивом и подчёркиванием. 
 Предложите способ хранения информации о выделении надписи и напишите программу, 
 которая позволяет назначать и удалять текстовой надписи выделение:
 */

namespace Task6
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            string style = "None";//todo pn хардкод
            bool flagBold, flagItalic, flagUnderline;
            flagBold = flagItalic = flagUnderline = false;
            while (true)
            {
                Class.PrintMenu(style);
                int.TryParse(Console.ReadLine(), out int n);
                Class.Restyle(n, ref flagBold, ref flagItalic, ref flagUnderline, ref style);
                if (n == 0)
                {
                    break;
                }
            }
        }      
    }
}
