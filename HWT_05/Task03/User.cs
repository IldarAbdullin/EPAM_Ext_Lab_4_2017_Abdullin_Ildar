namespace Task03
{
    using System;

    public class User
    {
        private const string startName = "None";
        private const string startSurname = "None";
        private const string startPatronymic = "None";
        ////private const DateTime startBirthday = new DateTime(1990, 01, 01);  //// так и не понял как это в начальное значение сделать
        private const int minYear = 1990;
        private string patronymic; 
        private int age;
        private DateTime birthday;
        private string name;
        private string surname;

        public string Name { get => this.name; set => this.name = value; }

        public string Surname { get => this.surname; set => this.surname = value; }

        public string Patronymic { get => this.patronymic; set => this.patronymic = value; }

        public User()
        {
            this.Name = startName;
            this.Surname = startSurname;
            this.Patronymic = startPatronymic;
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
            if (value.Year > minYear)
			{
                this.birthday = value;
            }
            else
            {
                ErrMessage();
            }
        }

        public int GetAge()
        {
            DateTime nowDate = DateTime.Today;
            if ((nowDate.Day >= this.GetBirthday().Day) && (nowDate.Month >= this.GetBirthday().Month))
            {
                return nowDate.Year - this.GetBirthday().Year;
            }
            else
            {
                return nowDate.Year - this.GetBirthday().Year - 1;
            }
        }

        public void ErrMessage()
        {
            Console.WriteLine("Invalid date");
        }
    }
}
