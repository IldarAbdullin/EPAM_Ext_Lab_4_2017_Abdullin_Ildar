/*
Написать класс User, описывающий человека (Фамилия, Имя,
Отчество, Дата рождения, Возраст). Написать программу,
демонстрирующую использование этого класса.
 */

namespace Task03
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            User user = new User("Владимир", "Путин", "Владимирович", new DateTime(2000,12,30)); //todo pn а ты дерзкий!1952, 10, 7
            Console.WriteLine($"Фамилия: {user.Surname}");
            Console.WriteLine($"Имя: {user.Name}");
            Console.WriteLine($"Отчество: {user.Patronymic}");
            Console.WriteLine($"Дата рождения: {user.GetBirthday().ToShortDateString()}");
            Console.WriteLine($"Возраст: {user.GetAge().ToString()}");
            Console.ReadKey();
        }
    }
}
