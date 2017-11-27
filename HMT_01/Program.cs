/*
Написать консольное приложение, которое проверяет принадлежность точки заштрихованной области.  
Пользователь вводит координаты точки (x; y) и выбирает букву графика (a-к).
В консоли должно высветиться сообщение: «Точка [(x; y)] принадлежит фигуре [г]». 
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HMT_01
{
    class Program
    {




        static void Main(string[] args)
        {
            int flag = 1;
            while (flag == 1)
            {

                Console.WriteLine("Введите букву фигуры");
                string figure = Console.ReadLine();

                Console.WriteLine("Введите координату x");
                double.TryParse(Console.ReadLine(), out double x);

                Console.WriteLine("Введите координату y");
                double.TryParse(Console.ReadLine(), out double y);


                switch (figure)
                {
                    case "а":
                        OwnA(x, y);
                        break;
                    case "б":
                        OwnB(x, y);
                        break;
                    case "в":
                        OwnV(x, y);
                        break;
                    case "г":
                        OwnG(x, y);
                        break;
                    case "д":
                        OwnD(x, y);
                        break;
                    case "е":
                        OwnE(x, y);
                        break;
                    case "ж":
                        OwnZH(x, y);
                        break;
                    case "з":
                        OwnZ(x, y);
                        break;
                    case "и":
                        OwnI(x, y);
                        break;
                    case "к":
                        OwnK(x, y);
                        break;
                }

                Console.WriteLine("Если хотите ввести координаты и букву еще раз введите 1, инчае 0");
                int.TryParse(Console.ReadLine(), out flag);
                if (flag == 1)
                    Console.Clear();
            }


        }

        private static void OwnK(double x, double y)
        {
            int flag = 0;
            if (y >= 1)
            {
                Console.WriteLine("Точка [({0}; {1})] принадлежит фигуре [к]", x, y);
                flag = 1;
            }
            else
            {
                if ((x >= -y) && (x <= y))
                {
                    Console.WriteLine("Точка [({0}; {1})] принадлежит фигуре [и]", x, y);
                    flag = 1;
                }

            }

            if (flag == 0)
            {
                Console.WriteLine("Точка [({0}; {1})] не принадлежит фигуре [з]", x, y);
            }
        }

        private static void OwnI(double x, double y)
        {
            int flag = 0;
            if (y <= 0)
            {
                if ((x >= (y-3)/2) && (x <= 3*y + 1))
                {
                    Console.WriteLine("Точка [({0}; {1})] принадлежит фигуре [и]", x, y);
                    flag = 1;
                }
            }
            else
            {
                if ((x >= (y - 3) / 2) && (x <= -y))
                {
                    Console.WriteLine("Точка [({0}; {1})] принадлежит фигуре [и]", x, y);
                    flag = 1;
                }



            }

            if (flag == 0)
            {
                Console.WriteLine("Точка [({0}; {1})] не принадлежит фигуре [з]", x, y);
            }
        }

        private static void OwnZ(double x, double y)
        {
            int flag = 0;
            if (y <= 0)
            {
                if ((y >= -2) && (Math.Abs(x) <= 1))
                {
                    Console.WriteLine("Точка [({0}; {1})] принадлежит фигуре [з]", x, y);
                    flag = 1;
                }
            }
            else
            {
                if (x <= 0)
                {
                    if (IsInTriangle(0, 0, -1, 1, -1, 0, x, y))
                    {
                        Console.WriteLine("Точка [({0}; {1})] принадлежит фигуре [з]", x, y);
                        flag = 1;
                    }
                }
                else
                {
                    if (IsInTriangle(0, 0, 1, 1, 1, 0, x, y))
                    {
                        Console.WriteLine("Точка [({0}; {1})] принадлежит фигуре [з]", x, y);
                        flag = 1;
                    }
                }
            }

            if (flag == 0)
            {
                Console.WriteLine("Точка [({0}; {1})] не принадлежит фигуре [з]", x, y);
            }
        }

        //Метод принимает точку (x,y), три вершины треугольник и проверяет принадлежность точки, данному треугольнику
        private static bool IsInTriangle(double x1, double y1, double x2, double y2, double x3, double y3, double x, double y)
        {
            double k, m, n;
            k = (x1 - x) * (y2 - y1) - (x2 - x1) * (y1 - y);
            m = (x2 - x) * (y3 - y2) - (x3 - x2) * (y2 - y);
            n = (x3 - x) * (y1 - y3) - (x1 - x3) * (y3 - y);
            if ((k >= 0 && m >= 0 && n >= 0) || (k <= 0 && m <= 0 && n <= 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private static void OwnZH(double x, double y)
        {
            int flag = 0;

            if ((y <= 2) && (y >= -1))
            {
                if ((x <= (-y/2) + 1) && (x >= (y / 2) - 1))
                {
                    Console.WriteLine("Точка [({0}; {1})] принадлежит фигуре [з]", x, y);
                    flag = 1;
                }
                
            }

            if (flag == 0)
            {
                Console.WriteLine("Точка [({0}; {1})] не принадлежит фигуре [з]", x, y);
            }

        }

        private static void OwnE(double x, double y)
        {
            double sum = x + y;
            double diff = x - y;
            int flag = 0;
            if (x < 0)
            {
                if ((sum <= 1) && (sum >= -2) && (diff >= -2) && (diff <= -1))
                {
                    Console.WriteLine("Точка [({0}; {1})] принадлежит фигуре [е]", x, y);
                    flag = 1;
                }
                
            }
            else if (x >= 0)
            {
                if (x * x + y * y <= 1)
                {
                    Console.WriteLine("Точка [({0}; {1})] принадлежит фигуре [е]", x, y);
                    flag = 1;
                }

            }

            if (flag == 0)
            {
                Console.WriteLine("Точка [({0}; {1})] не принадлежит фигуре [е]", x, y);
            }

        }

        
     

        private static void OwnD(double x, double y)
        {
            if ((2 * Math.Abs(x) + Math.Abs(y)) == 1)
                Console.WriteLine("Точка [({0}; {1})] принадлежит фигуре [д]", x, y);
            else
                Console.WriteLine("Точка [({0}; {1})] не принадлежит фигуре [д]", x, y);
        }

        private static void OwnG(double x, double y)
        {
            if (Math.Abs(x) + Math.Abs(y) == 1)
                Console.WriteLine("Точка [({0}; {1})] принадлежит фигуре [г]", x, y);
            else
                Console.WriteLine("Точка [({0}; {1})] не принадлежит фигуре [г]", x, y);
        }

        private static void OwnV(double x, double y)
        {
            if (x * x + y * y <= 2)
                Console.WriteLine("Точка [({0}; {1})] принадлежит фигуре [в]", x, y);
            else
                Console.WriteLine("Точка [({0}; {1})] не принадлежит фигуре [в]", x, y);
        }

        private static void OwnB(double x, double y)
        {
            if ((x * x + y * y <= 1) && (x * x + y * y >= 0.5))
                Console.WriteLine("Точка [({0}; {1})] принадлежит фигуре [б]", x, y);
            else
                Console.WriteLine("Точка [({0}; {1})] не принадлежит фигуре [б]", x, y);
        }



        public static void OwnA(double x, double y)
        {
            if (x * x + y * y <= 1)
                Console.WriteLine("Точка [({0}; {1})] принадлежит фигуре [а]", x, y);
            else
                Console.WriteLine("Точка [({0}; {1})] не принадлежит фигуре [а]", x, y);
        }
    }
}
