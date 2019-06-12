using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.App.Demo
{
    public class ObjectsValueTypesDemo
    {
        public void Run()
        {
            string myString = "Kiwi";
            Console.WriteLine(myString);

            ChangeFruit(myString);
            Console.WriteLine(myString);

            // ---------------- 

            int myAge = 47;
            Console.WriteLine(myAge);

            ChangeAge(myAge);
            Console.WriteLine(myAge);

            // ---------------- 

            DateTime birthDate = new DateTime(1972, 1, 11);
            Console.WriteLine(birthDate);

            ChangeDate(birthDate);
            Console.WriteLine(birthDate);


        }

        private void ChangeFruit(string fruit)
        {
            fruit = "Banan";
        }

        private void ChangeAge(int age)
        {
            age = 25;
        }

        private void ChangeDate(DateTime date)
        {
            date = DateTime.Now;
        }
    }
}
