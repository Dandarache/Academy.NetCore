using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Academy.App.Demo
{
    public class LinqExercise2
    {
        public void Run()
        {
            //string filePath = @"..\..\..\ExternalData\PersonShort.csv";
            string filePath = @"..\..\..\ExternalData\PersonExtra.csv";

            int displayRows = 15;

            List<Customer> customers = CreateListOfCustomers(filePath);

            int maleCustomers = customers.Count(a => a.Gender == GenderType.Male);
            Console.WriteLine($"Number of male customers: {maleCustomers}");
            Console.WriteLine();

            int femaleCustomers = customers.Where(a => a.Gender == GenderType.Female).Count();
            Console.WriteLine($"Number of female customers: {femaleCustomers}");
            Console.WriteLine();

            int uniqueFirstNames = customers
                .Select(a => a.FirstName)
                .Distinct()
                .Count();
            Console.WriteLine($"Unique first names: {uniqueFirstNames}");
            Console.WriteLine();


            Console.WriteLine("Sorted list by Age");
            List<Customer> ageSortedCustomers =
                customers.OrderByDescending(a => a.Age).ToList();
            //customers.OrderBy(a => a.Age).ToList();
            DisplayData(ageSortedCustomers, displayRows);

            Console.WriteLine("Sorted list by First Name");
            List<Customer> firstNameSortedCustomers =
                customers.OrderBy(a => a.FirstName).ToList();
            //customers.OrderBy(a => a.Age).ToList();
            DisplayData(firstNameSortedCustomers, displayRows);

            Console.WriteLine("Men older than 35 year. Lambda Expression.");
            List<Customer> oldMenCustomers =
                customers.Where(a => a.Age >= 35 && a.Gender == GenderType.Male).ToList();
            DisplayData(oldMenCustomers, displayRows);

            Console.WriteLine("Manipulated");
            List<Customer> manipulatedCustomers =
                customers
                    .Where(a => a.Age >= 35)
                    .Where(a => a.Gender == GenderType.Male)
                    //.Where(a => a.Age >= 35 && a.Gender == GenderType.Male)
                    .Select(a => 
                        new Customer(
                            a.FirstName.ToUpper(), 
                            a.LastName.ToUpper(), 
                            a.Age + 1000, 
                            a.Gender, 
                            a.Email))
                    .ToList();
            DisplayData(manipulatedCustomers, displayRows);

            Console.WriteLine("Women older than 35 year. Query Expressions.");
            //// Define the query expression.
            //IEnumerable<int> scoreQuery =
            //    from score in scores
            //    where score > 80
            //    select score;

            var oldMenCustomers2 = from customer in customers
                                   where customer.Age >= 35
                                   where customer.Gender == GenderType.Female
                                   select customer;
            DisplayData(oldMenCustomers2.ToList(), displayRows);
        }

        //private void DisplayData(List<Customer> customers, int displayRows)
        private void DisplayData(IEnumerable<Customer> customers, int displayRows)
        {
            foreach (Customer customer in customers.Take(displayRows))
            {
                Console.WriteLine($"{customer.FirstName}\t\t{customer.Age}");
            }
            Console.WriteLine();
        }

        private List<Customer> CreateListOfCustomers(string filePath)
        {
            // Tänkbart fel: Sökvägen till filen är fel.
            // Tänkbart fel: Filen innehåller felaktig data.
            string[] rows = File.ReadAllLines(filePath);

            List<Customer> customers = new List<Customer>();

            //Id,First name, Last name,Email,Gender,Age,Play tennis, Like fruit,IP number

            foreach (var row in rows)
            {
                string[] columns = row.Split(',');

                string firstName = columns[1];
                string lastName = columns[2];
                int.TryParse(columns[5], out int age);
                string email = columns[3];
                GenderType gender = 
                    columns[4].Equals("Male", StringComparison.CurrentCultureIgnoreCase) ? 
                        GenderType.Male : 
                        GenderType.Female;

                Customer customer = new Customer(firstName, lastName, age, gender, email);

                customers.Add(customer);
            }

            return customers;
        }
    }

    class Customer
    {
        public Customer(string firstName, string lastName, int age, GenderType gender, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
            Email = email;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public GenderType Gender { get; set; }
    }

    enum GenderType
    {
        Male,
        Female
    }
}
