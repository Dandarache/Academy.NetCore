using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.ConsoleApp.Demo
{
    public class ExceptionsDemo
    {
        public void Run()
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

            int totalAmount = 135;

            Console.WriteLine("Enter a number please:");
            string myOtherNumberString = Console.ReadLine();
            int.TryParse(myOtherNumberString, out int myOtherParsedNumber);

            int result = totalAmount / myOtherParsedNumber;

        }
    }
}
