/*
 Дано действительно число h. Выяснить имеет ли уравнение ax^2+bx+c=0 действительные корни
 */

namespace Task02
{
    using System;

	public static class Program
    {
        public static void Main(string[] args)
        {
            Func<double, double> sin = Math.Sin; 
            Func<double, double> cos = Math.Cos;
            Func<double, double> tg = Math.Tan;
            Func<double, double> abs = Math.Abs;
            Func<double, double> sqrt = Math.Sqrt;

            int flag = 1;
            while (flag == 1)
            {
                Console.WriteLine("Введите число h");
                double.TryParse(Console.ReadLine(), out double h);

                double num = abs(sin(8 * h)) + 17;
                double den = 1 - (sin(4 * h) * cos((h * h) + 18));
                double a = sqrt(num / (den * den));

                double b = 1 - sqrt(3 / (3 + abs(tg(a * h * h) - sin(a * h))));

                double c = (a * h * sin(b * h)) + (b * h * h * h * cos(a * h));
                Console.WriteLine("a = {0}  ", a);
                Console.WriteLine("b = {0}  ", b);
                Console.WriteLine("c = {0}  ", c);

                double d = (b * b) - (4 * a * c);
                Console.WriteLine("Дискриминант = {0}  ", d);
                if ((d > 0) && (a != 0))
                {
                    double x1 = (-b - sqrt(d)) / (2 * a);
                    double x2 = (-b + sqrt(d)) / (2 * a);
                    Console.WriteLine("Корни уравнения:");
                    Console.WriteLine("x1 = {0},   x2 = {1} ", x1, x2);
                }
                else if (d == 0)
                {
                    double x1 = -b  / (2 * a);
                    Console.WriteLine("Корень уравнения:");
                    Console.WriteLine("x1 = {0}", x1);
                }
                else
                {
                    Console.WriteLine("Действительных корней нет");
                }

                Console.WriteLine("Если хотите ввести новое число  введите 1, инчае 0");
                int.TryParse(Console.ReadLine(), out flag);
                if (flag == 1)
                {
                    Console.Clear();
                }
            }
        }
    }
}
