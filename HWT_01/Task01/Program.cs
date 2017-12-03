/*
Написать консольное приложение, которое проверяет принадлежность точки заштрихованной области.  
Пользователь вводит координаты точки (x; y) и выбирает букву графика (a-к).
В консоли должно высветиться сообщение: «Точка [(x; y)] принадлежит фигуре [г]». 
*/

namespace HMT_01
{
    using System;
    
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
                        Diagram.OwnA(x, y, figure);
                        break;
                    case "б":
                        Diagram.OwnB(x, y, figure);
                        break;
                    case "в":
                        Diagram.OwnV(x, y, figure);
                        break;
                    case "г":
                        Diagram.OwnG(x, y, figure);
                        break;
                    case "д":
                        Diagram.OwnD(x, y, figure);
                        break;
                    case "е":
                        Diagram.OwnE(x, y, figure);
                        break;
                    case "ж":
                        Diagram.OwnZH(x, y, figure);
                        break;
                    case "з":
                        Diagram.OwnZ(x, y, figure);
                        break;
                    case "и":
                        Diagram.OwnI(x, y, figure);
                        break;
                    case "к":
                        Diagram.OwnK(x, y, figure);
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
    }
}
