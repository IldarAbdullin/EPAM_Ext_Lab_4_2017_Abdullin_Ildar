namespace Task02
{
    using System;

    public class Ring : Round
    {
        private double innerRadius;

        public Ring(double x, double y, double r, double innerR) : base(r, x, y)
        {
            this.InnerRadius = innerR;
        }
        
        public double InnerRadius
        {
            get
            {
                return this.innerRadius;
            }

            set
            {
                if (value < this.OutterRadius)
                {
                    this.innerRadius = value;
                }
                else
                {
                    Console.WriteLine($"{value} - Incorrect data\n");
                    this.innerRadius = 0;
                }
            }
        }

        public new double Length
        {
            get
            {
                return (2 * (Math.PI * this.Radius)) + (2 * (Math.PI * this.InnerRadius));
            }
        }

        public new double GetArea
        {
            get
            {
                return (Math.PI * this.Radius * this.Radius) - (Math.PI * this.InnerRadius * this.InnerRadius);
            }
        }

        public new void Print()
        {
            Console.WriteLine($"Coordinates x = {this.X} , y = {this.Y}  ");
            Console.WriteLine($"OutterRadius  = {this.Radius}");
            Console.WriteLine($"InnerRadius  = {this.InnerRadius}");
            Console.WriteLine($"Area of a ring = {this.GetArea}");
            Console.WriteLine($"Total length  = {this.Length}\n");
        }
    }
}
