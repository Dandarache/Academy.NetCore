using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.ConsoleApp.Demo.Classes
{
    public class Person
    {
        public Person() { }
        public Person(
            string firstName,
            string lastName,
            int age, 
            DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = FundamentalsDemo1.StaticRandom.Next(1, age);
            BirthDate = birthDate;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public DateTime BirthDate { get; private set; }

        public void UpdateLastName(string lastName)
        {
            this.LastName = lastName;
        }
    }
}
