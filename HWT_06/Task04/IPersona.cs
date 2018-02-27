namespace Task04
{
    public interface IPersona
    {
        int HP { get; set; }

        int Speed { get; set; }

        int Mana { get; set; }

        int Damage { get; set; }

        int X { get; set; }

        int Y { get; set; }

        void Move();
    }
}
