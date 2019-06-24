using Academy.ConsoleApp.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.ConsoleApp.Demo
{
    public class ClassesDemo1
    {
        public void Run()
        {
            // Dan
            Person person1 = new Person();
            person1.FirstName = "Dan";
            person1.LastName = "Jansson";
            person1.Age = 47;
            person1.Birthdate = DateTime.Parse("1972-01-11");
            //person1.Gender = "Male";
            person1.Gender = GenderType.Male;
            Console.WriteLine(person1.FirstName);
            Console.WriteLine(person1.FullName());
            Console.WriteLine(person1.Gender);
            Console.WriteLine();

            // Lisa
            DateTime birthdate2 = DateTime.Parse("1984-01-11");
            Person person2 = new Person("Lisa", "Andersson", 35, birthdate2, GenderType.Female);
            //person2.FirstName = "Lisa";
            //person2.LastName = "Andersson";
            //person2.Age = 35;
            //person2.Birthdate = DateTime.Parse("1984-01-11");
            //person2.Gender = "Female";
            Console.WriteLine(person2.FirstName);
            Console.WriteLine(person2.FullName());
            Console.WriteLine(person2.Gender);
            Console.WriteLine();




        }
    }
}
