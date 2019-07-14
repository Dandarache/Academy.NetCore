using LinqDemos.Data;
using LinqDemos.Data.Classes;
using System;
using System.IO;
using System.Linq;

namespace LinqDemos
{
    class Program
    {
        private static DataAccessAcademy _dataAccessAcademy
            = new DataAccessAcademy();

        static void Main(string[] args)
        {
            // Create instance of the dog class
            Dog myDog1 = new Dog("Fluffy", "Lupus Voffus");
            // Instance properties
            myDog1.Breed = "Jack Russel";
            myDog1.BirthDate = new DateTime(2012, 6, 20);
            Console.WriteLine(myDog1.LatinName);


            // Create dog using static method
            Dog myDog2 = AllMightyCreator.CreateDog("Fido");

            Console.WriteLine(myDog2.LatinName);

            // Create cat using instance method
            //AllMightyCreator allMighty = new AllMightyCreator();
            Cat myCat1 = AllMightyCreator.CreateCat("Morran");

            //string hello = AllMightyCreator.;






            //string[] lines = File.ReadAllLines("...");

            //File.WriteAllLines("", lines);

            //File myFile = new File();
            //string[] lines = myFile.ReadAllLines("...");


            // ----------------------------------

            //list_employees_with_full_name();
            //list_female_employees_with_pets();
            //list_employees_with_age_between_25_and_40();
            //list_full_name_of_employees_in_descending_order();
            //list_female_employees_that_live_in_stockholm();
            //list_employees_that_ulla_manages();
            //count_male_employees_that_lives_in_borlange();
            sort_employees_based_on_age_and_list_top_5();
        }

        private static void list_employees_with_full_name()
        {
            var employees = _dataAccessAcademy.GetEmployees();

            throw new NotImplementedException();
        }

        private static void count_female_employees_that_lives_in_borlange()
        {
            throw new NotImplementedException();
        }

        private static void list_employees_that_ulla_manages()
        {
            throw new NotImplementedException();
        }

        private static void list_female_employees_that_live_in_stockholm()
        {
            throw new NotImplementedException();
        }

        private static void list_full_name_of_employees_in_descending_order()
        {
            throw new NotImplementedException();
        }

        private static void list_male_employees_with_pets()
        {
            var employees = _dataAccessAcademy.GetEmployees();
        }

        private static void list_employees_with_age_between_25_and_40()
        {
            throw new NotImplementedException();
        }

        private static void sort_employees_based_on_age_and_list_top_5()
        {
            var employees = _dataAccessAcademy.GetEmployees();

            var filteredEmployees =
                employees
                    .OrderBy(a => ((DateTime.Today.Subtract(a.Birthdate)) / 365))
                    .Take(5);

            foreach (var employee in filteredEmployees)
            {
                Console.WriteLine(employee.ToString());
            }
        }
    }
}
