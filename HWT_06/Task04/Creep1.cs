namespace Task04
{
    using System;

    public class Creep1 : IPersona
    {
        public Creep1()
        {
            ////здесь инициализация начальных параметров
        }

        /// <summary>
        /// здесь типа все стартовые значения по умолчанию
        /// </summary>
        public int HP { get; set; }

        public int Speed { get; set; }

        public int Mana { get; set; }

        public int Damage { get; set; }

        public string NickName { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public void Move()
        {
        }

        public void Attack()
        {
        }
    }
}
