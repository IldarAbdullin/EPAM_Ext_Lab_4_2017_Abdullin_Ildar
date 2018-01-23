/* 
  Напишите расширяющий метод, который определяет, является ли строка положительным целым числом. 
  Методы Parse и TryParse не использовать.
 */

namespace Task02
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the string");
            string str = Console.ReadLine();
            string message = string.Empty;
            message = str.IsPositiveNum() ? string.Empty : "not";            
            Console.WriteLine($"The entered string is {message} a positive number.");
            Console.ReadLine();
        }
    }
}
