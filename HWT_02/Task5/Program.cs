/*
 Если выписать все натуральные числа меньше 10, кратные 3, или 5, то получим 3, 5, 6 и 9. Сумма этих чисел будет равна 23.
 Напишите программу, которая выводит на экран сумму всех чисел меньше 1000, кратных 3, или 5.
 */

namespace Task5
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int sum = 0;
            int multiple1 = 3;
            int multiple2 = 5;
            int numberOfTerms = 1000;
            for (int i = 1; i < numberOfTerms; i++)
            { 
                if ((i % multiple1 == 0) || (i % multiple2 == 0))
                {
                    sum += i;
                }
            }

            Console.WriteLine("the sum of all numbers less than {0}, multiples of {1} or {2} = {3} ", numberOfTerms, multiple1, multiple2, sum);
            Console.ReadKey();
        }
        
        
    }
}
