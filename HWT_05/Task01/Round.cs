namespace Task01
{
    using System;

    public class Round
    {
        private double r;

        public double X { get; set; }

        public double Y { get; set; }

        public double Radius
        {
            get
            {
                return this.r;
            }

            set
            {
                if (value > 0)
                {
                    this.r = value;
                }
            }
        }

        public double GetArea
        {
            get
            {
                return Math.PI * this.r * this.r;
            }
        }

        public double Length
        {
            get
            {
                return 2 * Math.PI * this.r;
            }
        }
    }
}