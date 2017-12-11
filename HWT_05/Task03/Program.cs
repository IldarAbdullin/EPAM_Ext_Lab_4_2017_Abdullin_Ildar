/*
Написать класс User, описывающий человека (Фамилия, Имя,
Отчество, Дата рождения, Возраст). Написать программу,
демонстрирующую использование этого класса.
 */

namespace Task03
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Владимир", "Путин", "Владимирович", new DateTime(1952, 10, 7));
            Console.WriteLine($"Фамилия: {user.Surname}");
            Console.WriteLine($"Имя: {user.Name}");
            Console.WriteLine($"Отчество: {user.Patronymic}");
            Console.WriteLine($"Дата рождения: {user.GetBirthday().ToString()}");
            Console.WriteLine($"Возраст: {user.GetAge().ToString()}");
            Console.ReadKey();
        }
    }
}
