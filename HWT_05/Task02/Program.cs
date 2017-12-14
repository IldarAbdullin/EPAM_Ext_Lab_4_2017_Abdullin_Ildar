/*
Написать класс, описывающий треугольник со сторонами a, b, c, и
позволяющий осуществить расчёт его площади и периметра. Написать
программу, демонстрирующую использование данного треугольника.
 */

namespace Task02
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Triangle triangle = new Triangle(4, 5, 6);
            Console.WriteLine($"Triangle with sides a = {triangle.A}, b = {triangle.B}, c = {triangle.C}");
            Console.WriteLine($"Perimeter of the triangle = {triangle.GetPerimeter()}");
            Console.WriteLine($"Area of the triangle = {triangle.GetArea()}"); //todo pn я не Флэш, чтобы успеть посмотреть что вывела консоль
        }
    }
}
