using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Academy.ConsoleApp.Demo
{
    public class LinqExercise1
    {
        public void Run()
        {
            string filePath = @"..\..\..\ExternalData\PersonShort.csv";

            List<string> list = CreateListOfNames(filePath);

            // Remove first row since it contains column names.
            list = list.Skip(1).ToList();

            // Sort the list ascending.
            Console.WriteLine("Sorted list:");
            //List<string> sortedList = list.OrderBy(a => a).ToList();
            List<string> sortedList = list.OrderByDescending(a => a).ToList();
            foreach (var person in sortedList)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine();

            // Starts with 'J'
            Console.WriteLine("Starts with 'J'");
            List<string> personsThatStartsWithJ = 
                list
                    .Where(x => x.StartsWith("J", StringComparison.CurrentCultureIgnoreCase))
                    .ToList();
            foreach (var person in personsThatStartsWithJ)
            {
                Console.WriteLine(person);
            }
            Console.WriteLine();

            // Starts with 'J' and UPPERCASE
            Console.WriteLine("Starts with 'J' and UPPERCASE");
            List<string> personsThatStartWithJUpperCase =
                personsThatStartsWithJ.Select(a => a.ToUpper()).ToList();
            foreach (var person in personsThatStartWithJUpperCase)
            {
                Console.WriteLine(person);
            }
        }

        private List<string> CreateListOfNames(string filePath)
        {
            // Tänkbart fel: Sökvägen till filen är fel.
            // Tänkbart fel: Filen innehåller felaktig data.
            string[] rows = File.ReadAllLines(filePath);

            List<string> persons = new List<string>();

            foreach (var row in rows)
            {
                string[] columns = row.Split(',');
                string personName = $"{columns[1]} {columns[2]}";
                persons.Add(personName);
            }

            return persons;
        }
    }
}
