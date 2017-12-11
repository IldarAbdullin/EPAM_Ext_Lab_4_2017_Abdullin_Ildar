namespace Task02
{
    using System;

    class Triangle
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public Triangle(int a, int b, int c)
        {
            if ((a < b + c) & (b < a + c) & (c < a + b))
            {
                if (a > 0)
                {
                    A = a;
                }


                if (b > 0)
                {
                    B = b;
                }

                if (a > 0)
                {
                    C = c;
                }
            }
            else
            {
                A = B = C = 0;
                Console.WriteLine("A triangle with such sides does not exist!");
            }

        }

        public double GetPerimeter()
        {
            return A + B + C;
        }

        public double GetArea()
        {
            double SemiPerimeter = GetPerimeter() / 2;
            return Math.Sqrt(SemiPerimeter * (SemiPerimeter - A) * (SemiPerimeter - B) * (SemiPerimeter - C));
        }
    }
}
