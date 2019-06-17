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
            //Demo1();

            //Demo2();

            //Demo3();
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
