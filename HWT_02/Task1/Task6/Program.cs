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
        enum Params
        {
            Bold,
            Italic,
            underline
        }

        public static void Main(string[] args)
        {
            string style = "None";
            bool flag = true;
            bool flagBold, flagItalic, flagUnderline;
            flagBold = flagItalic = flagUnderline = false;
            PrintMenu(style);
            int.TryParse(Console.ReadLine(), out int n);
            Restyle(n, flagBold, flagItalic, flagUnderline);

        }

        public static void Restyle(int n, bool flagBold, bool flagItalic, bool flagUnderline, string  style)
        {
            switch (n)
            {
                case 1:
                    if (flagBold)
                    {
                        if (style.Contains(", bold"))
                        {
                            style = style.Replace(", bold", "");
                        }
                        else if ((style.Contains("bold,")))
                        {
                            style = style.Replace("bold,", "");
                        }
                        else if ((style.Contains("bold")))
                        {
                            style = style.Replace("bold", "");
                        }

                        flagBold = false;

                    }
                    else
                    {
                        flagBold = true;
                        style = style + ", bold";
                    }

                    if ((!flagItalic) && (!flagUnderline) && (!flagBold))
                    {
                        style = "None";
                    }
            }
        }

        public static void PrintMenu(string style)
        {
            Console.WriteLine("Пармаетр надписи:  {0}\n Введите:\n\t 1:  bold\n\t 2:  italic\n\t 3:  underline",style);
        }
    }
}
