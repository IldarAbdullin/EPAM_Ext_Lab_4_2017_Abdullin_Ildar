/*
 * 
 */

namespace Task03
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            bool flag = true;
                       
            while (flag)
            {
                Console.WriteLine("Select a shape: \n 1: Circle \n 2: Round \n 3: Ring \n 4: Line \n 5: Rectangle \n 0: Exit \n");
                double.TryParse(Console.ReadLine(), out double key);

                switch (key)
                {
                    case 0:
                        flag = false;
                        break;
                    case 1:
                        Circle circle = new Circle(4, 4, 5);
                        circle.Print();
                        break;
                    case 2:
                        Round round = new Round(1, 1, 2);
                        round.Print();
                        break;
                    case 3:
                        Ring ring = new Ring(5, 2, 5, 3);
                        ring.Print();
                        break;
                    case 4:
                        Line line = new Line(4, 2, 5, 1);
                        line.Print();
                        break;
                    case 5:
                        Rectangle rectangle = new Rectangle(8, 8, 4, 9);
                        rectangle.Print();
                        break;
                    default:
                        Console.WriteLine("You entered an incorrect number");
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}
