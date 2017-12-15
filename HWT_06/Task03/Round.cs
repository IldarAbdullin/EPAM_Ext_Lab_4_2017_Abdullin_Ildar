namespace Task03
{
    using System;

    public class Round : Figure
    {      
        public Round(int centerX, int centerY, int radius) : base(centerX, centerY)
        {
            this.Radius = radius;
        }
      
        public Round() : base()
        {
            this.Radius = 0;
        }

        public int Radius { get; set; }

        public new double Length
        {
            get
            {
                return 2 * Math.PI * this.Radius;
            }
        }

        public new double Area
        {
            get
            {
                return Math.PI * this.Radius * this.Radius;
            }
        }

        public new void Print()
        {
            Console.WriteLine($"This is Round, Centre: ({this.CenterX},{CenterY}), Radius: {this.Radius} , Lenght: {this.Length:0.00}, Area:{Area:0.00}");
        }
    }
}
