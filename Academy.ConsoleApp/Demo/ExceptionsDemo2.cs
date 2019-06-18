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
                        if (animal.Equals("academy", StringComparison.CurrentCultureIgnoreCase))
                        {
                            throw new AcademyException("Animals cannot be named Academy.");
                        }
                    }

                    // Display all animals
                    int animalNumber = 1;
                    foreach (var animal in animals)
                    {
                        Console.WriteLine($"Animal {animalNumber}: {animal}");
                        animalNumber++;
                    }

                    break;
                }
                catch (AcademyException aex)
                {
                    // Logga till externt system...
                    Console.WriteLine(aex.Message);
                }
                catch (ArgumentException aex)
                {
                    Console.WriteLine(aex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }
    }
}

