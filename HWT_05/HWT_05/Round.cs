namespace Task01
{
    using System;

    class Round
    {
        private double r;
        public double X { get; set; }
        public double Y { get; set; }
        public double Radius
        {
            get
            {
                return r;
            }

            set
            {
                if (value > 0)
                {
                    r = value;
                }
            }
        }

        public double GetArea
        {
            get
            {
                return Math.PI * r * r;
            }
        }

        public double Length
        {
            get
            {
                return 2 * Math.PI * r;
            }
        }
    }
}

