namespace Task04
{
    using System;

    public class Offers
    {
        public int X { get; set; }

        public int Y { get; set; }

        public string Name { get; set; }

        ////поля от которых завист какой будет бонус, устанавливается значение равное действую типа +10 добавляет 10 пунктов характеристие и наооборот
        public int HP { get; set; }

        public int Speed { get; set; }

        public int Mana { get; set; }

        public int Damage { get; set; }

        public int Invulnerability { get; set; }

        public int Key { get; set; } ////с помощью ключа можно открыть барьер IsDoor
    }
}
