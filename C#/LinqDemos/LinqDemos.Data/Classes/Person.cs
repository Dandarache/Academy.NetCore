using System;
using System.Collections.Generic;
using System.Text;

namespace LinqDemos.Data.Classes
{
    public class Person
    {
        // Field variables
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime Birthdate { get; private set; }
        public GenderType Gender { get; private set; }
        public bool HasPet { get; private set; }
        public string StreetName { get; private set; }
        public string Zipcode { get; private set; }
        public string City { get; private set; }

        // Constructors
        public Person()
        {

        }
        public Person(
            string firstName, 
            string lastName, 
            DateTime birthdate, 
            GenderType gender, 
            bool hasPet)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
            Gender = gender;
            HasPet = hasPet;
        }
    }
}
