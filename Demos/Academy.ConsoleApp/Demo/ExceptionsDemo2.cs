using Academy.ConsoleApp.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Academy.ConsoleApp.Demo
{
    public class ExceptionsDemo2
    {
        public void Run()
        {
            while (true)
            {
                // Ask user for list of animals separated by comma.
                Console.WriteLine("Enter some animals separated by comma:");
                string animalsString = Console.ReadLine();

                // Invoke the method ParseAnimals to check the string and return the animals in an array.
                string[] animals = ParseAnimals(animalsString);

                // Display all animals
                int animalNumber = 1;
                foreach (var animal in animals)
                {
                    Console.WriteLine($"Animal {animalNumber}: {animal}");
                    animalNumber++;
                }

                break;
            }
        }

        /// <summary>
        /// This method splits a string using the comma character and returns an array of strings.
        /// If any of the array items is empty or contains invalid characters an exception will be thrown.
        /// </summary>
        /// <param name="animalsString">The string with comma-separated strings.</param>
        /// <returns>An array with string items.</returns>
        private string[] ParseAnimals(string animalsString)
        {
            // Split string into array of strings.
            string[] animals = animalsString.Split(',');

            // Validate the input and check that everything is ok and according to the rules that where defined in the exercise.
            try
            {
                // Check if this is an empty string.
                if (string.IsNullOrWhiteSpace(animalsString))
                {
                    throw new ArgumentException("Animal string doesn't contain any letters.");
                }

                // Test all animal names individually
                foreach (var animal in animals)
                {
                    if (string.IsNullOrWhiteSpace(animal))
                    {
                        throw new ArgumentException("One of the animals didn't contain any letters.");
                    }
                    if (animal.Length > 20)
                    {
                        throw new ArgumentException($"The animal '{animal}' has too many letters.");
                    }
                    Regex regex = new Regex(@"[^\w]+");
                    if (regex.IsMatch(animal))
                    {
                        throw new ArgumentException($"The animal '{animal}' contains invalid letters.");
                    }
                    // This exception will occur if the string item equals the word 'academy'.
                    if (animal.Equals("academy", StringComparison.CurrentCultureIgnoreCase))
                    {
                        throw new AcademyException("Animals cannot be named Academy.");
                    }
                }
            }
            //////////////////////////////////////////////////
            // NOTE: The order of the catch statements matter a lot and you should put the most significant exception first.
            //////////////////////////////////////////////////
            // Will be catched if the thrown exception is of type or inherits from AcademyException.
            catch (AcademyException aex)
            {
                // Logga till externt system...
                Console.WriteLine(aex.Message);
            }
            // Will be catched if the thrown exception is of type or inherits from ArgumentException.
            catch (ArgumentException aex)
            {
                Console.WriteLine(aex.Message);
            }
            // Will be catched if the thrown exception is of type or inherits from Exception.
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            // Return the string array to the calling context.
            return animals;
        }
    }
}

