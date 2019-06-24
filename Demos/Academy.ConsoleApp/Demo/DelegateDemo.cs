using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.ConsoleApp.Demo
{
    public class DelegateDemo
    {
        public void Run()
        {
            //BadWay();
            SmartWay();
        }

        public void SmartWay()
        {
            AskUserAndRespond(ToUpper);
            AskUserAndRespond(Tripple);
            AskUserAndRespond(AddStars);
        }

        public void BadWay()
        {
            AskUserAndRespond_ToUpper();
            AskUserAndRespond_Tripple();
            AskUserAndRespond_AddStars();
        }

        private void AskUserAndRespond(Func<string, string> converter)
        {
            string methodName = converter.Method.Name;

            Console.WriteLine($"Enter a string to convert ({methodName}): ");
            string input = Console.ReadLine();

            string answer = converter(input);

            Console.WriteLine($"Here is the result: {answer}\n");
        }


        private void AskUserAndRespond_ToUpper()
        {

            Console.WriteLine("Enter a string to convert: ");
            string input = Console.ReadLine();

            string answer = ToUpper(input);
            Console.WriteLine($"Here is the result: {answer}\n");
        }

        private void AskUserAndRespond_Tripple()
        {
            Console.WriteLine("Enter a string to convert: ");
            string input = Console.ReadLine();

            string answer = Tripple(input);
            Console.WriteLine($"Here is the result: {answer}\n");
        }

        private void AskUserAndRespond_AddStars()
        {
            Console.WriteLine("Enter a string to convert:");
            string input = Console.ReadLine();

            string answer = AddStars(input);
            Console.WriteLine($"Here is the result: {answer}\n");
        }

        private string ToUpper(string s)
        {
            return s.ToUpper();
        }

        private string Tripple(string s)
        {
            return s + s + s;
        }

        private string AddStars(string s)
        {
            string spacyString = "";
            foreach (char c in s)
            {
                spacyString += c + "*";
            }
            spacyString = spacyString.TrimEnd('*');
            return spacyString;
        }

    }
}
