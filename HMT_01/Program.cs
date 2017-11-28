/*
Написать консольное приложение, которое проверяет принадлежность точки заштрихованной области.  
Пользователь вводит координаты точки (x; y) и выбирает букву графика (a-к).
В консоли должно высветиться сообщение: «Точка [(x; y)] принадлежит фигуре [г]». 
*/

namespace HMT_01
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main(string[] args)
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
                        OwnA(x, y, figure);
                        break;
                    case "б":
                        OwnB(x, y, figure);
                        break;
                    case "в":
                        OwnV(x, y, figure);
                        break;
                    case "г":
                        OwnG(x, y, figure);
                        break;
                    case "д":
                        OwnD(x, y, figure);
                        break;
                    case "е":
                        OwnE(x, y, figure);
                        break;
                    case "ж":
                        OwnZH(x, y, figure);
                        break;
                    case "з":
                        OwnZ(x, y, figure);
                        break;
                    case "и":
                        OwnI(x, y, figure);
                        break;
                    case "к":
                        OwnK(x, y, figure);
                        break;
                }

                Console.WriteLine("Если хотите ввести координаты и букву еще раз введите 1, инчае 0");
                int.TryParse(Console.ReadLine(), out flag);
                if (flag == 1)
                {
                    Console.Clear();
                }
            }
        }

        private static void Message(double x, double y, string figure, bool flag)
        {
            if (flag)
            {
                Console.WriteLine("Точка [({0}; {1})] принадлежит фигуре [{2}]", x, y, figure);//todo np говорил на лекции о том, что строка должна быть одна, а отображение "не" параметризовано
            }
            else
            {
                Console.WriteLine("Точка [({0}; {1})] не принадлежит фигуре [{2}]", x, y, figure);//todo np говорил на лекции о том, что строка должна быть одна, а отображение "не" параметризовано
			}
        }

        private static void OwnK(double x, double y, string figure)//todo np вынести в отдельный класс
		{
            int flag = 0;
            if (y >= 1)
            {
                Message(x, y, figure, true);
                flag = 1;
            }
            else
            {
                if ((x >= -y) && (x <= y))
                {
                    Message(x, y, figure, false);
                    flag = 1;
                }
            }

            if (flag == 0)
            {
                Message(x, y, figure, false);
            }
        }

        private static void OwnI(double x, double y, string figure)//todo np вынести в отдельный класс
		{
            int flag = 0;
            if (y <= 0)
            {
                if ((x >= (y - 3) / 2) && (x <= (3 * y) + 1))
                {
                    Message(x, y, figure, true);
                    flag = 1;
                }
            }
            else
            {
                if ((x >= (y - 3) / 2) && (x <= -y))
                {
                    Message(x, y, figure, true);
                    flag = 1;
                }
            }

            if (flag == 0)
            {
                Message(x, y, figure, false);
            }
        }

        private static void OwnZ(double x, double y, string figure)//todo np вынести в отдельный класс
		{
            int flag = 0;
            if (y <= 0)
            {
                if ((y >= -2) && (Math.Abs(x) <= 1))
                {
                    Message(x, y, figure, true);
                    flag = 1;
                }
            }
            else
            {
                if (x <= 0)
                {
                    if (IsInTriangle(0, 0, -1, 1, -1, 0, x, y))
                    {
                        Message(x, y, figure, true);
                        flag = 1;
                    }
                }
                else
                {
                    if (IsInTriangle(0, 0, 1, 1, 1, 0, x, y))
                    {
                        Message(x, y, figure, true);
                        flag = 1;
                    }
                }
            }

            if (flag == 0)
            {
                Message(x, y, figure, false);
            }
        }

        //// Метод принимает точку (x,y), три вершины треугольник  и проверяет принадлежность точки, данному треугольнику
        private static bool IsInTriangle(double x1, double y1, double x2, double y2, double x3, double y3, double x, double y)//todo np вынести в отдельный класс
		{
            double k, m, n;
            k = ((x1 - x) * (y2 - y1)) - ((x2 - x1) * (y1 - y));
            m = ((x2 - x) * (y3 - y2)) - ((x3 - x2) * (y2 - y));
            n = ((x3 - x) * (y1 - y3)) - ((x1 - x3) * (y3 - y));
            if ((k >= 0 && m >= 0 && n >= 0) || (k <= 0 && m <= 0 && n <= 0))//todo pn испрвить на return k >= 0 && m >= 0 && n >= 0) || (k <= 0 && m <= 0 && n <= 0);
			{
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void OwnZH(double x, double y, string figure)//todo np вынести в отдельный класс
		{
            int flag = 0;

            if ((y <= 2) && (y >= -1))
            {
                if ((x <= (-y / 2) + 1) && (x >= (y / 2) - 1))
                {
                    Message(x, y, figure, true);
                    flag = 1;
                }
            }

            if (flag == 0)
            {
                Message(x, y, figure, false);
            }
        }

        private static void OwnE(double x, double y, string figure)//todo np вынести в отдельный класс
		{
            double sum = x + y;
            double diff = x - y;
            int flag = 0;
            if (x < 0)
            {
                if ((sum <= 1) && (sum >= -2) && (diff >= -2) && (diff <= -1))
                {
                    Message(x, y, figure, true);
                    flag = 1;
                }
            }
            else if (x >= 0)
            {
                if ((x * x) + (y * y) <= 1)
                {
                    Message(x, y, figure, true);
                    flag = 1;
                }
            }

            if (flag == 0)
            {
                Message(x, y, figure, false);
            }
        }

        private static void OwnD(double x, double y, string figure)//todo np вынести в отдельный класс
		{
            if (((2 * Math.Abs(x)) + Math.Abs(y)) == 1)//todo pn поправить 
			{
                Message(x, y, figure, true);
            }
            else
            {
                Message(x, y, figure, false);
            }
        }

        private static void OwnG(double x, double y, string figure)//todo np вынести в отдельный класс
		{
            if (Math.Abs(x) + Math.Abs(y) == 1)//todo pn поправить 
			{
                Message(x, y, figure, true);
            }
            else
            {
                Message(x, y, figure, false);
            }
        }

        private static void OwnV(double x, double y, string figure)//todo np вынести в отдельный класс
		{
            if ((x * x) + (y * y) <= 2)//todo pn поправить
			{
                Message(x, y, figure, true);
            }
            else
            {
                Message(x, y, figure, false);
            }
        }

        private static void OwnB(double x, double y, string figure)//todo np вынести в отдельный класс
		{
            if (((x * x) + (y * y) <= 1) && ((x * x) + (y * y) >= 0.5))//todo pn поправить
			{
                Message(x, y, figure, true);
            }
            else
            {
                Message(x, y, figure, false);
            }
        }

        private static void OwnA(double x, double y, string figure)//todo np вынести в отдельный класс
		{
            if ((x * x) + (y * y) <= 1) //todo pn можно (и нужно) переписать эти несколько строк в одну: Message(x, y, figure, (x * x) + (y * y) <= 1). Исправь здесь и везде выше. 
			{
                Message(x, y, figure, true);
            }
            else
            {
                Message(x, y, figure, false);
            }
        }
    }
}
