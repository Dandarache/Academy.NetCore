using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Academy.ConsoleApp.Demo
{
    public class ExceptionsDemo
    {
        public void Run()
        {
            while (true)
            {
                Console.WriteLine("Enter file name:");
                string fileName = Console.ReadLine();

                Console.WriteLine("Enter text that should be written to text file:");
                string fileInputText = Console.ReadLine();

                try
                {
                    using (StreamWriter file = File.CreateText(fileName))
                    {
                        file.Write(fileInputText);
                        break;
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("You're not authorized to create this file");
                }
                catch (DirectoryNotFoundException)
                {
                    Console.WriteLine("Directory not found");
                }
                catch (IOException)
                {
                    Console.WriteLine("Input output exception");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("The filename is not valid");
                }
                catch (Exception)
                {
                    Console.WriteLine($"Something strange happened");
                }
            }
            
            
            //Demo3();

            //Demo2();
            
            //Demo1();
        }

        /// <summary>
        /// This method will demonstrate UnauthorizedAccessException.
        /// The reason that this exception occur is because of the user 
        /// doesn't have access to create files or write to the root in C:\
        /// </summary>
        private void Demo3()
        {
            try
            {
                File.CreateText(@"C:\exceptionstest");
            }
            catch (UnauthorizedAccessException uaex)
            {
                Console.WriteLine($"An access related error occured: {uaex.Message}");
            }
        }

        /// <summary>
        /// This demo demonstrates the division by zero exception that will occur if you try to divide something with zero.
        /// Note that the data type need to be int.
        /// </summary>
        private void Demo2()
        {
            int totalAmount = 135;

            Console.WriteLine("Enter a number please:");
            string myOtherNumberString = Console.ReadLine();
            int.TryParse(myOtherNumberString, out int myOtherParsedNumber);

            try
            {
                int result = totalAmount / myOtherParsedNumber;
            }
            catch (DivideByZeroException dex)
            {
                Console.WriteLine("Division med noll!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// This demo demonstrates what will happen if you try to parse a string for a number, but the string is invalid.
        /// </summary>
        private void Demo1()
        {
            Console.WriteLine("Enter a number please:");
            string myNumberString = Console.ReadLine();

            try
            {
                int myParsedNumber = int.Parse(myNumberString);

                Console.WriteLine($"The parsed number is: {myParsedNumber}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occured when parsing the the input.");
            }
        }
    }
}
