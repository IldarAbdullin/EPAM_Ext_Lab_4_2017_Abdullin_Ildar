namespace Task02
{
    using System;

    public class Triangle
    {
        public Triangle(int a, int b, int c)
        {
            if ((a < b + c) & (b < a + c) & (c < a + b))
            {
                if (a > 0)
                {
                    this.A = a;
                }

                if (b > 0)
                {
                    this.B = b;
                }

                if (c > 0)
                {
                    this.C = c;
                }
            }
            else
            {
                this.A = this.B = this.C = 0;
                Console.WriteLine("A triangle with such sides does not exist!");
            }
        }

        public double A
        {
            get
            {
                return A;
            }

            set
            {
                if (CheckParam(value))
                {
                    this.A = value;
                }
            }
        }

        public double B
        {
            get
            {
                return B;
            }

            set
            {
                if (CheckParam(value))
                {
                    this.B = value;
                }
            }
        }

        public double C
        {
            get
            {
                return C;
            }

            set
            {
                if (CheckParam(value))
                {
                    this.C = value;
                }
            }
        }

        public bool CheckParam(double value)
        {
            if (value <= 0)
            {
                Console.WriteLine($"{value} - Inccorect data");
                return false;
            }
            else
            {
                return true;
            }
        }

        public double GetPerimeter()
        {
            return this.A + this.B + this.C;
        }

        public double GetArea()
        {
            double semiPerimeter = this.GetPerimeter() / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - this.A) * (semiPerimeter - this.B) * (semiPerimeter - this.C));
        }
    }
}
