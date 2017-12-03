namespace HMT_01
{
    using System;

    public static class Diagram
    {
        public static void Message(double x, double y, string figure, bool flag)
        {
            Console.WriteLine("Точка [({0}; {1})] {2}принадлежит фигуре [{3}]", x, y, flag == true ? "" : "не ", figure);
        }

        public static void OwnK(double x, double y, string figure)
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

        public static void OwnI(double x, double y, string figure)
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

        public static void OwnZ(double x, double y, string figure)
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
        public static bool IsInTriangle(double x1, double y1, double x2, double y2, double x3, double y3, double x, double y)
        {
            double k, m, n;
            k = ((x1 - x) * (y2 - y1)) - ((x2 - x1) * (y1 - y));
            m = ((x2 - x) * (y3 - y2)) - ((x3 - x2) * (y2 - y));
            n = ((x3 - x) * (y1 - y3)) - ((x1 - x3) * (y3 - y));
            return (k >= 0 && m >= 0 && n >= 0) || (k <= 0 && m <= 0 && n <= 0);
        }

        public static void OwnZH(double x, double y, string figure)
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

        public static void OwnE(double x, double y, string figure)
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

        public static void OwnD(double x, double y, string figure)
        {
            Message(x, y, figure, ((2 * Math.Abs(x)) + Math.Abs(y)) == 1);
        }

        public static void OwnG(double x, double y, string figure)
        {
            Message(x, y, figure, Math.Abs(x) + Math.Abs(y) == 1);
        }

        public static void OwnV(double x, double y, string figure)
        {
            Message(x, y, figure, (x * x) + (y * y) <= 2);
        }

        public static void OwnB(double x, double y, string figure)
        {
            Message(x, y, figure, ((x * x) + (y * y) <= 1) && ((x * x) + (y * y) >= 0.5));
        }

        public static void OwnA(double x, double y, string figure)
        {
            Message(x, y, figure, (x * x) + (y * y) <= 1);
        }
    }
}
