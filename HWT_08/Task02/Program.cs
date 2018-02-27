/*
 Написать программу, описывающую небольшой офис, в котором работают сотрудники – объекты класса Person, обладающие полем имя (Name).
 Каждый из сотрудников содержит пару методов: приветствие сотрудника, пришедшего на работу (принимает в качестве аргументов
 объект сотрудника и время его прихода)и прощание с ним (принимает только объект сотрудника). В зависимости от времени суток, 
 приветствие может быть различным: до 12 часов – «Доброе утро», с 12 до 17 – «Добрый день», начиная с 17 часов – «Добрый вечер».
 Каждый раз при входе очередного сотрудника в офис, все пришедшие ранее его приветствуют. При уходе сотрудника домой с ним 
 также прощаются все присутствующие. Вызов процедуры приветствия/прощания производить через групповые делегаты. Факт прихода
 и ухода сотрудника отслеживается через генерируемые им события. Событие прихода описывается делегатом, передающим в числе 
 параметров наследника EventArgs, явно содержащего поле с временем прихода.
Продемонстрировать работу офиса при последовательном приходе и уходе сотрудников.
 */

namespace Task02
{
    using System;

    public delegate void Greeting(Person person, TimeSpan time);

    public delegate void Parting(Person person);

    public class Program
    {
        public static void Main(string[] args)
        {
            Office office = new Office();
            Person petya = new Person("Petya");
            Person vasya = new Person("Vasya");
            Person vova = new Person("Vova");
            Person sasha = new Person("Sasha");

            office.CamePerson(petya, new TimeSpan(10, 00, 00));
            office.CamePerson(vasya, new TimeSpan(11, 00, 00));
            office.CamePerson(vova, new TimeSpan(16, 45, 00));
            office.CamePerson(sasha, new TimeSpan(18, 00, 00));

            office.OutPerson(vova);
            office.OutPerson(vasya);
            office.OutPerson(petya);
            office.OutPerson(sasha);
            Console.ReadLine();
        }
    }
}
