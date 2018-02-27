namespace Task03
{
    using System;

    public abstract class Figure
    {
        public Figure()
        {
            this.CenterX = 0;
            this.CenterY = 0;
        }

        public Figure(int centerX, int centerY)
        {
            this.CenterX = centerX;
            this.CenterY = centerY;
        }

        public int CenterX { get; set; }

        public int CenterY { get; set; }

        public double Length
        {
            get
            {
                return 0;
            }
        }

        public double Area
        {
            get
            {
                return 0;
            }
        }

        public void Print()
        {
            Console.WriteLine("This is figure");
        }
    }
}
