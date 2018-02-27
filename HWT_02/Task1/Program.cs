/*
 Написать программу, которая определяет площадь прямоугольника со сторонами a и b. 
 Если пользователь вводит некорректные значения (отрицательные, или 0), должно выдаваться сообщение об ошибке. 
 Возможность ввода пользователем строки вида «абвгд», или нецелых чисел игнорировать.
*/

namespace Task1
{
    using System;

    public class Program1
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the length of the rectangle.");
            int a = InputAndCheck();
            Console.WriteLine("Enter the width of the rectangle.");
            int b = InputAndCheck();
            int areaRectangle = a * b;
            Console.WriteLine("The area of the rectangle = {0}", areaRectangle);
            Console.ReadKey();
        }

        public static int InputAndCheck()
        {
            int.TryParse(Console.ReadLine(), out int a);
            while (a <= 0)
            {
                Console.WriteLine("Enter a positive non-zero value");
                int.TryParse(Console.ReadLine(), out a);
            }

            return a;
        }
    }
}
