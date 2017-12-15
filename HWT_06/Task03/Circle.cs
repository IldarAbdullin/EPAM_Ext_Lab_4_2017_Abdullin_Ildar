namespace Task03
{
    using System;

    public class Circle : Figure
    {        
        public Circle() : base()
        {
            this.Radius = 0;
        }

        public Circle(int centerX, int centerY, int radius) : base(centerX, centerY)
        {
            this.Radius = radius;
        }

        public int Radius { get; set; }

        public new double Length
        {
            get
            {
                return 2 * Math.PI * this.Radius;
            }
        }

        public new void Print()
        {
            Console.WriteLine($"This is Circle, Centre: ({this.CenterX},{CenterY}), Radius: {this.Radius} , Lenght: {this.Length:0.00}");
        }
    }
}
