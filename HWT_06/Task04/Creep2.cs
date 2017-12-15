/// <summary>
/// и куча подоных крипов с разными с показателями, атаками и тд
/// </summary>
namespace Task04
{
    using System;

    public class Creep2 : IPersona
    {
        public Creep2()
        {
            /*здесь инициализация начальных параметров*/
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

        public void FarAttack()
        {
        }
    }
}
