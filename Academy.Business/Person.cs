using System;

namespace Academy.Business
{
    public class Person
    {
        public Person() { }
        public Person(
            string firstName,
            string lastName,
            int age, DateTime
            birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            BirthDate = birthDate;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public DateTime BirthDate { get; private set; }
    }
}
