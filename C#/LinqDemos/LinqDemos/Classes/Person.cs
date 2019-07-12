using System;
using System.Collections.Generic;
using System.Text;

namespace EfSamurai.Test.Classes
{
    public class Person
    {
        // Field variables
        public string FirstName;
        public string LastName;
        public DateTime Birthdate;
        public GenderType Gender;
        public bool HasPet { get; set; }

        // Constructors
        public Person()
        {

        }
        public Person(string firstName, string lastName, DateTime birthdate, GenderType gender, bool hasPet)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
            Gender = gender;
            HasPet = hasPet;
        }
    }
}
