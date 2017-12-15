namespace Task03
{
    using System;

    public class Ring : Figure
    {
        public Ring() : base()
        {
            this.OutterRadius = 0;
            this.InnerRadius = 0;
        }

        public Ring(int centerX, int centerY, int outterRadius, int innerRadius) : base(centerX, centerY)
        {
            this.OutterRadius = outterRadius;
            this.InnerRadius = innerRadius;
        }

        public int OutterRadius { get; set; }

        public int InnerRadius { get; set; }

        public new double Length
        {
            get
            {
                return (2 * (Math.PI * this.OutterRadius)) + (2 * (Math.PI * this.InnerRadius));
            }
        }

        public new double Area
        {
            get
            {
                return (Math.PI * this.OutterRadius * this.OutterRadius) - (Math.PI * this.InnerRadius * this.InnerRadius);
            }
        }

        public new void Print()
        {
            Console.WriteLine($"This is Ring, Centre: ({this.CenterX},{CenterY}), Radius: {this.OutterRadius} , Lenght: {this.Length:0.00}, Area:{Area:0.00}");
        }
    }
}
