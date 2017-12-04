/*
 Если выписать все натуральные числа меньше 10, кратные 3, или 5, то получим 3, 5, 6 и 9. Сумма этих чисел будет равна 23.
 Напишите программу, которая выводит на экран сумму всех чисел меньше 1000, кратных 3, или 5.
 */

namespace Task5
{
    using System;

    public class Program
    {
        public static void Main(string[] args)//todo pn частное решение
		{
            int sum = 0;
            int num = 1;
            while (sum + num < 1000)//todo pn хардкод
			{ 
                if ((num % 3 == 0) || (num % 5 == 0))//todo pn хардкод
				{
                    sum += num;
                }

                num++;
            }

            Console.WriteLine("The sum of the numbers of multiples of 3 or 5 is less than 1000 = {0}", sum);//todo pn хардкод (1000)
			Console.ReadKey();
        }
    }
}
