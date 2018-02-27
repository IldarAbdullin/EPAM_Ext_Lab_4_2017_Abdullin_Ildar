namespace HWT_06
{
    using System;

    public class User
    {
        private string patronymic;
        private int age;
        private DateTime birthday;
        private string name;
        private string surname;

        public User(string name, string surname, string patronymic, DateTime birthday)
        {
            this.Name = name;
            this.Surname = surname;
            this.Patronymic = patronymic;
            this.SetBirthday(birthday);
            this.Age = this.GetAge();
        }

        public User()
        {
            this.Name = "None";
            this.Surname = "None";
            this.Patronymic = "None";
            this.SetBirthday(new DateTime(1990, 01, 01));
            this.Age = this.GetAge();
        }

        public string Name { get => this.Name1; set => this.Name1 = value; }

        public int Age { get => this.age; set => this.age = value; }

        public DateTime Birthday { get => this.birthday; set => this.birthday = value; }

        public string Name1 { get => this.name; set => this.name = value; }

        public string Surname { get => this.surname; set => this.surname = value; }

        public string Patronymic { get => this.patronymic; set => this.patronymic = value; }

        public DateTime GetBirthday()
        {
            return this.Birthday;
        }

        public void SetBirthday(DateTime value)
        {
            if (value.Year > 1900)
            {
                this.Birthday = value;
            }
            else
            {
                Console.WriteLine($"{value.ToShortDateString()} - Incorrect data\n");
            }
        }

        public int GetAge()
        {
            DateTime nowDate = DateTime.Today;
            if (this.GetBirthday().Year > 1900)
            {
                return nowDate.Year - this.GetBirthday().Year;
            }
            else
            {
                return 0;
            }
        }
    }
}
