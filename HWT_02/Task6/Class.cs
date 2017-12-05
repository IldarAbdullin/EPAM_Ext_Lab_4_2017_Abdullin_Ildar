namespace Task6
{
    using System;

    public class Class
    {
        public static void Restyle(int n, ref bool flagBold, ref bool flagItalic, ref bool flagUnderline, ref string style)
        {
            switch (n)
            {
                case 1:
                    Check("Bold", ref flagBold, ref flagBold, ref flagItalic, ref flagUnderline, ref style);
                    break;
                case 2:
                    Check("Italic", ref flagItalic, ref flagBold, ref flagItalic, ref flagUnderline, ref style);
                    break;
                case 3:
                    Check("Underline", ref flagUnderline, ref flagBold, ref flagItalic, ref flagUnderline, ref style);
                    break;
            }
        }

        public static void PrintMenu(string style = "None")
        {
            Console.WriteLine("Введите 0, если хотите закончить\n\nПармаетр надписи:  {0}\n Введите:\n\t 1:  bold\n\t 2:  italic\n\t 3:  underline", style);
        }

        public static void Check(string str, ref bool flag, ref bool flagBold, ref bool flagItalic, ref bool flagUnderline, ref string style)
        {
            string str2 = ", " + str + ",";
            string str3 = ", " + str;
            string str4 = str + ", ";
            string str5 = "";

            if (flag)
            {
                if (style.Contains(str2))
                {
                    style = style.Replace(str2, str5);
                }
                else if (style.Contains(str3))
                {
                    style = style.Replace(str3, str5);
                }
                else if (style.Contains(str4))
                {
                    style = style.Replace(str4, str5);
                }
                else if (style.Contains(str))
                {
                    style = style.Replace(str, str5);
                }

                flag = false;

                if ((!flagItalic) && (!flagUnderline) && (!flagBold))
                {
                    style = "None";
                }
            }
            else
            {
                flag = true;

                if ((style == "None") || (style == str5))
                {
                    style = str;
                }
                else
                {
                    style = style + str3;
                }
            }
        }
    }
}
