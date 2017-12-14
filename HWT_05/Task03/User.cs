namespace Task03
{
    using System;

    public class User
    {
        public string Name, Surname, Patronymic; // todo pn плохо проверяешь stylecop. Ругается на модификатор доступа.
        private int age;
        private DateTime birthday;

        public User()
        {
            this.Name = "Иван";//todo pn hardcode
            this.Surname = "Иванов";//todo pn hardcode
			this.Patronymic = "Иванович";//todo pn hardcode
			this.SetBirthday(new DateTime(1990, 01, 01));//todo pn hardcode
			this.age = this.GetAge();
        }

        public User(string name, string surname, string patronymic, DateTime birthday)
        {
            this.Name = name;
            this.Surname = surname;
            this.Patronymic = patronymic;
            this.SetBirthday(birthday);
            this.age = this.GetAge();
        }

        public DateTime GetBirthday()
        {
            return this.birthday;
        }

        public void SetBirthday(DateTime value)
        {
            if (value.Year > 1900)//todo pn hardcode
			{
                this.birthday = value;
            }
            else
            {
                Console.WriteLine("Invalid date");//todo pn сильная связность (использование UI в слое бизнес логики)
			}
        }

        public int GetAge()
        {
            DateTime nowDate = DateTime.Today;
            return nowDate.Year - this.GetBirthday().Year;//todo pn некорректное вычисление даты (а если день рождения ещё не настал в текущем году)
        }
    }
}
