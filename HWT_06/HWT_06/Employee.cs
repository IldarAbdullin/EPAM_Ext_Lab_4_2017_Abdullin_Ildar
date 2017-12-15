namespace HWT_06
{
    using System;

    public class Employee : User
    {
        private int experienceMonth;

        private string post;

        public Employee()
        {
        }
        
        public Employee(string name, string surname, string patronymic, DateTime birthday, int experienceMonth, string post)
            : base(name, surname, patronymic, birthday)
        {
            this.SetExperienceMonth(experienceMonth);
            this.post = post;
        }

        public string Post { get => this.post; set => this.post = value; }

        public void SetExperienceMonth(int experience)
        {
            if (experience >= 0)
            {
                this.experienceMonth = experience;
            }
            else
            {
                Console.WriteLine($"{experience} - Incorrect data\n");
                this.experienceMonth = 0;
            }
        }

        public int GetExperienceMonth()
        {
            return this.experienceMonth;
        }

        public void PrintInformation()
        {
            Console.WriteLine($"Surname: {this.Surname}");
            Console.WriteLine($"Name: {this.Name}");
            Console.WriteLine($"Patronymic: {this.Patronymic}");
            Console.WriteLine($"Birthday: {this.GetBirthday().ToShortDateString()}");
            Console.WriteLine($"Age: {this.GetAge().ToString()}");
            Console.WriteLine($"Post: {this.Post.ToString()}");
            Console.WriteLine($"Work experience: {this.GetExperienceMonth().ToString()} month(s)\n");
        }
    }
}