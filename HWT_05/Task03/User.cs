namespace Task03
{
    using System;

    public class User
    {
        public string Name, Surname, Patronymic;
        private int age;
        private DateTime birthday;

        public User()
        {
            this.Name = "Иван";
            this.Surname = "Иванов";
            this.Patronymic = "Иванович";
            this.SetBirthday(new DateTime(1990, 01, 01));
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
            if (value.Year > 1900)
            {
                this.birthday = value;
            }
            else
            {
                Console.WriteLine("Invalid date");
            }
        }

        public int GetAge()
        {
            DateTime nowDate = DateTime.Today;
            return nowDate.Year - this.GetBirthday().Year;
        }
    }
}
