/*
 На основе класса User (см. задание 3 из предыдущей темы), создать класс Employee, 
 описывающий сотрудника фирмы. В дополнение к полям пользователя добавить поля «стаж работы» и «должность». 
 Обеспечить нахождение класса в заведомо корректном состоянии.
 */

namespace HWT_06
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Employee fisrt = new Employee("Vladimir", "Putin", "Vladimirovich", new DateTime(1952, 10, 7), 16 * 12, "Mr.President");
            fisrt.PrintInformation();
            Employee two = new Employee("Vasya", "Petrov", "Ivanovich", new DateTime(1000, 10, 7), -10, "None");
            two.PrintInformation();
            Console.ReadKey();
        }
    }
}
