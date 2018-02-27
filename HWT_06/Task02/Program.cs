/*
 * 
 */

namespace Task02
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Ring ring = new Ring(0, 0, 5, 2);
            ring.Print();
            Ring ring2 = new Ring(0, 0, 4, 5);
            ring2.Print();
            Console.ReadKey();
        }
    }
}
