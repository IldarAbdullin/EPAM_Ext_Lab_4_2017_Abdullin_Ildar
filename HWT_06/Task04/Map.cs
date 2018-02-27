namespace Task04
{
    using System;
    using System.Collections.Generic;

    public class Map
    {
        private Barriers[,] barriers;
        private List<IPersona> creeps;  ////не уверен, что так можно делать, но умнее ничего не смог придумать
        private Offers[,] offers;

        //// Конструктор Map(int Width, int Height) который сразу генерирует полностью карту,крипов,бонусы и тд

        public int Width { get; set; }

        public int Height { get; set; }

        public List<IPersona> Creeps { get => this.creeps; set => this.creeps = value; }

        public Offers[,] Offers { get => this.offers; set => this.offers = value; }

        public Barriers[,] Barriers { get => this.barriers; set => this.barriers = value; }

        public void IsFinish()
        {
            ////определения конца игры
        }
    }
}
