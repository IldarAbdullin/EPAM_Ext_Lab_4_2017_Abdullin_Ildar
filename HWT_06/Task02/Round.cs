namespace Task02
{
    using System;

    public class Round
    {
        private double outterRadius;

        public Round(double radius, double x, double y)
        {
            this.Radius = radius;
            this.X = x;
            this.Y = y;
        }

        public double Radius
        {
            get
            {
                return this.OutterRadius;
            }

            set
            {
                if (value > 0)
                {
                    this.OutterRadius = value;
                }
            }
        }

        public double Length
        {
            get
            {
                return 2 * Math.PI * this.Radius;
            }
        }

        public double GetArea
        {
            get
            {
                return Math.PI * this.Radius * this.Radius;
            }
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double OutterRadius { get => this.outterRadius; set => this.outterRadius = value; }

        public void Print()
        {
            Console.WriteLine($"Coordinates x = {this.X} , y = {this.Y}  ");
            Console.WriteLine($"OutterRadius  = {this.Radius}");
            Console.WriteLine($"Area of a circle = {this.GetArea}");
            Console.WriteLine($"Length  = {this.Length}\n");
        }
    }
}