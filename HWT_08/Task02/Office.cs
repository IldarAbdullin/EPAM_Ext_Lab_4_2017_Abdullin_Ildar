namespace Task02
{
    using System;
    using System.Collections.Generic;

    public class Office
    {
        private List<Person> persons;

        public Office()
        {
            this.persons = new List<Person>();
        }

        public void CamePerson(Person person, TimeSpan time)
        {
            Console.WriteLine("[{0} came to work.]", person.Name);//todo pn хардкод
            foreach (var e in this.persons)
            {
                person.OnCame += e.Greet;
                person.OnOut += e.Goodbye;
                e.OnOut += person.Goodbye;
            }

            this.persons.Add(person);
            person.Enter(time);
        }

        public void OutPerson(Person person)
        {
            Console.WriteLine("[{0} gone home.]", person.Name);//todo pn хардкод
			person.Exit();
            foreach (var c in this.persons)
            {
                c.OnCame -= person.Greet;
                c.OnOut -= person.Goodbye;
            }

            this.persons.Remove(person);
        }
    }
}
