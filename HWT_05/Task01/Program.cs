/*
 Написать класс Round, задающий круг с указанными координатами
центра, радиусом, а также свойствами, позволяющими узнать длину
описанной окружности и площадь круга. Обеспечить нахождение
объекта в заведомо корректном состоянии. Написать программу,
демонстрирующую использование данного круга.
 */

namespace Task01
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var round = new Round();
            round.Radius = 10;
            round.X = 1;
            round.Y = 1;
            Console.WriteLine("Координаты x = {0} , y = {1}  ", round.X, round.Y);
            Console.WriteLine("Площадь круга = {0}", round.GetArea);
            Console.WriteLine("Длина  = {0}", round.Length);
            Console.ReadKey();
        }
    }
}
