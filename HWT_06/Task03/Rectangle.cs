namespace Task03
{
    using System;

    public class Rectangle : Figure
    {
        public Rectangle() : base()
        {
            this.SideA = 0;
            this.SideB = 0;
        }

        public Rectangle(int centerX, int centerY, int sideA, int sideB) : base(centerX, centerY)
        {
            this.SideA = sideA;
            this.SideB = sideB;
        }

        public int SideA { get; set; }

        public int SideB { get; set; }

        public new double Length
        {
            get
            {
                return 2 * (this.SideA + this.SideB);
            }
        }

        public new double Area
        {
            get
            {
                return this.SideA * this.SideB;
            }
        }

        public new void Print()
        {
            Console.WriteLine($"This is Rectangle, Centre: ({this.CenterX},{CenterY}), Area: {this.Area:0.00} , Lenght: {this.Length:0.00}");
        }
    }
}
