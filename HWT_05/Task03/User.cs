namespace Task03
{
    using System;

    class User
    {
        public string Name, Surname, Patronymic;
        private int Age;
        private DateTime Birthday;

        public User()
        {
            Name = "Иван";
            Surname = "Иванов";
            Patronymic = "Иванович";
            SetBirthday(new DateTime(1990, 01, 01));
            Age = GetAge();

        }

        public User(string name, string surname, string patronymic, DateTime birthday)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            SetBirthday(birthday);
            Age = GetAge();
        }

        public DateTime GetBirthday()
        {
            return Birthday;
        }

        public void SetBirthday(DateTime value)
        {
            if (value.Year > 1900)
            {
                Birthday = value;
            }
            else
            {
                Console.WriteLine("Invalid date");
            }
        }


        public int GetAge()
        {
            DateTime nowDate = DateTime.Today;
            return nowDate.Year - GetBirthday().Year;

        }

    }
}
