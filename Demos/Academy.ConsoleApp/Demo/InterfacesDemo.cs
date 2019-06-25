using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.ConsoleApp.Demo
{
    public class InterfacesDemo
    {
        public void Run()
        {
            //Array
            string[] rockstarsArray = 
                new string[] {
                    "Jim Morrison",
                    "Ozzy Osborne",
                    "Alice Timander",
                    "Kalle Jularbo",
                    "Kalle Moréus",
                    "Eddie Van Halen"
                };

            List<string> rockstarsList = 
                new List<string> {
                    "Jim Morrison",
                    "Ozzy Osborne",
                    "Alice Timander",
                    "Kalle Jularbo",
                    "Kalle Moréus",
                    "Eddie Van Halen" };

            Console.WriteLine("Array");
            DisplayArrayOfRockStars(rockstarsArray);
            Console.WriteLine();

            Console.WriteLine("List<string>");
            DisplayListOfRockStars(rockstarsList);
            Console.WriteLine();

            Console.WriteLine("IEnumerable<string> (arrayen)");
            DisplayRockStars(rockstarsArray);
            Console.WriteLine();

            Console.WriteLine("IEnumerable<string> (List<string>:en)");
            DisplayRockStars(rockstarsList);
        }

        private void DisplayArrayOfRockStars(string[] rockstars)
        {
            foreach (var rockstar in rockstars)
            {
                Console.WriteLine($"string[]: {rockstar}");
            }
        }

        private void DisplayListOfRockStars(List<string> rockstars)
        {
            rockstars.Add("Lill-Babs");
            foreach (var rockstar in rockstars)
            {
                Console.WriteLine($"List<string>: {rockstar}");
            }
        }

        private void DisplayRockStars(IEnumerable<string> rockstars)
        {
            foreach (var rockstar in rockstars)
            {
                Console.WriteLine($"List<string>: {rockstar}");
            }
        }

    }
}
