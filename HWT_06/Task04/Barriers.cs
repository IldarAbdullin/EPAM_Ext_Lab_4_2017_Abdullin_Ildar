namespace Task04
{
    using System;

    public class Barriers
    {
        public Barriers()
        {
            ////здесь конруктор со всеми необязательными параметрами, кроме Width, Height, BeginX, BeginY
        }

        public int Width { get; set; }

        public int Height { get; set; }

        public int BeginX { get; set; }

        public int BeginY { get; set; }
        ////поля от которых завист какой будет барьер, будет ли вредить герою, крипам и тд
        public int IsDoor { get; set; }

        public int IsTree { get; set; }

        public int IsPortal { get; set; }

        public int IsThorns { get; set; }

        public int Damage { get; set; }
        //// и тд 
    }
}
