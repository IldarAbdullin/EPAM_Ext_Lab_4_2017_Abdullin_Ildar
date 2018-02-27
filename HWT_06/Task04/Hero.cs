namespace Task04
{
    using System;

    public class Hero : IPersona
    {
        private const int StartHP = 100;
        private const int StartSpeed = 50;
        private const int StartMana = 100;
        private const int StarDamage = 10;

        public Hero(string nick)
        {
            this.NickName = nick;
            this.HP = StartHP;
            this.Speed = StartSpeed;
            this.Mana = StartMana;
            this.Damage = StarDamage;

            ////помещение героя в заранее установленное на карте место
        }

        public int HP { get; set; }

        public int Speed { get; set; }

        public int Mana { get; set; }

        public int Damage { get; set; }

        public int Invulnerability { get; set; }

        public string NickName { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public void POTRACHENO()
        {
            ////смерть героя по причине, настпуление на смертельный барьер, закончилось HP и тд
        }

        public void Move()
        {
            ////движение с учетом всех барьеров,монстров и тд
        }

        public void Attack()
        {
        }
    }
}
