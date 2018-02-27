namespace Task03
{
    using System;
    using static System.Math;

    public class Line : Figure
    {
        public Line() : base()
        {
            this.EndX = 0;
            this.EndY = 0;
        }

        public Line(int beginX, int beginY, int endX, int endY) : base(beginX, beginY)
        {
            this.EndX = endX;
            this.EndY = endY;
        }

        public int EndX { get; set; }

        public int EndY { get; set; }

        public new double Length
        {
            get
            {
                return Sqrt(Pow(this.CenterX - this.EndX, 2) + Pow(this.CenterY - this.EndY, 2));
            } ////The call to Pow must begin with the 'this.', 'base.', 'object.' or 'Line.' or 'Figure.' prefix to indicate the intended method call
            // не понял как исправить, эту проблему
        }

        public new double Area
        {
            get
            {
                return 0;
            }
        }

        public new void Print()
        {
            Console.WriteLine($"This is Line, begin: ({CenterX},{CenterY}) , end: ({EndX},{EndY}), Lenght: {this.Length:0.00}");
        }
    }
}
