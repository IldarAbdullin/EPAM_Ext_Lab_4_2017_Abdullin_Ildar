/*
 Дано действительно число h. Выяснить имеет ли уравнение ax^2+bx+c=0 действительные корни
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Task02
{
    class Program
    {
        static void Main(string[] args)
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

                double aNum = (abs(sin(8 * h)) + 17);
                double aDen = (1 - sin(4 * h) * cos(h * h + 18)) * (1 - sin(4 * h) * cos(h * h + 18));
                double a = sqrt(aNum / aDen);

                double b = 1 - sqrt(3 / (3 + abs(tg(a * h * h) - sin(a * h))));

                double c = a * h * sin(b * h) + b * h * h * h * cos(a * h);
                Console.WriteLine("a = {0}  ", a);
                Console.WriteLine("b = {0}  ", b);
                Console.WriteLine("c = {0}  ", c);


                double D = b * b - 4 * a * c;
                Console.WriteLine("Дискриминант = {0}  ", D);
                if ((D > 0) && (a != 0))
                {
                    double x1 = (-b - sqrt(D)) / (2 * a);
                    double x2 = (-b + sqrt(D)) / (2 * a);
                    Console.WriteLine("Корни уравнения:");
                    Console.WriteLine("x1 = {0},   x2 = {1} ", x1, x2);
                }
                else if (D == 0)
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
                    Console.Clear();
            }
        }
    }
}
