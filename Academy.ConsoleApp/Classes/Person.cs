using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.ConsoleApp.Classes
{
    public class Person
    {
        // Field variables
        public string FirstName;
        public string LastName;
        public int Age;
        public DateTime Birthdate;
        //public string Gender;
        public GenderType Gender;

        // Constructors
        public Person()
        {

        }
        //public Person(string firstName, string lastName, int age, DateTime birthdate, string gender)
        public Person(string firstName, string lastName, int age, DateTime birthdate, GenderType gender)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Birthdate = birthdate;
            Gender = gender;
        }

        // Instance methods
        public string FullName()
        {
            string fullName = $"{FirstName} {LastName}";
            return fullName;
        }
    }
}
