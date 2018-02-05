namespace Task02
{
    using System;

    public class Person
    {
        public Person(string name)
        {
            this.Name = name;
        }

        public event Greeting OnCame;

        public event Parting OnOut;

        public string Name { get; set; }

        public void Enter(TimeSpan time)
        {
            if (this.OnCame != null)
            {             
                this.OnCame(this, time);                
            }

            Console.WriteLine("\n");
        }

        public void Greet(Person anotherPerson, TimeSpan time)
        {
            string message = string.Empty;
            if ((time.Hours >= 1) && (time.Hours <= 24))
            {
                if (time.Hours < 12)
                {
                    message = "Good morning";//todo pn хардкод
				}

                if ((time.Hours >= 12) && (time.Hours < 17))
                {
                    message = "Good afternoon";//todo pn хардкод
				}

                if (time.Hours >= 17)
                {
                    message = "Good evening";//todo pn хардкод
				}
            }
            else
            {
                message = "Hello";//todo pn хардкод
			}

            Console.WriteLine("'{0}, {1}!', - {2} said.", message, anotherPerson.Name, this.Name);//todo pn хардкод
		}

        public void Exit()
        {
            if (this.OnOut != null)
            {
                this.OnOut(this);
                Console.WriteLine("\n");
            }
        }

        public void Goodbye(Person anotherPerson)
        {
            Console.WriteLine("'Goodbye, {0}!', - {1} said.", anotherPerson.Name, this.Name);//todo pn хардкод
		}
    }
}
