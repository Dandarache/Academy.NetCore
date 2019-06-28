using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Academy.ConsoleApp.Demo
{
    enum MessageType
    {
        Error,
        Warning,
        Information
    }

    public class MethodsDemo3
    {
        public void Run()
        {
            string separatorString = GetUserInput("Which separator do you want to use? Default is comma ','");
            char.TryParse(separatorString, out char separator);
            if (separator == 0)
            {
                separator = ',';
            }

            string enableErrorMessagesString = GetUserInput("Do you want to see error messages?");
            bool.TryParse(enableErrorMessagesString, out bool enableErrorMessages);

            string[] nameList;

            while (true)
            {
                string nameString = GetUserInput("Enter some names separated by comma");

                nameList = CreateStringArray(nameString, separator);

                // void CleanUpArray(string[] values)
                // string[] cleanedValues = CleanUpArray(string[] values)
                //string[] cleanedValues = CleanUpArray(nameList);
                CleanArrayFromWhiteSpace(nameList);

                bool isValid = PeopleArrayIsValid(nameList, enableErrorMessages);
                if (isValid)
                {
                    break;
                }
            }

            //PrintNames(cleanedValues);
            string template = "***SUPER-{0}***";
            PrintNamesWithTemplate(nameList, template);
        }

        private bool PeopleArrayIsValid(string[] peopleArray, bool showErrorMessages)
        {
            foreach (var name in peopleArray)
            {
                Regex regex = new Regex("^([a-zA-ZéöäåÖÄÅ]+)$");
                //^([a-zA-ZéöäåÖÄÅ]+)$

                if (string.IsNullOrWhiteSpace(name))
                {
                    if (showErrorMessages)
                    {
                        PrintMessage("Empty value for name.", MessageType.Error);
                    }
                    //PrintError("Empty value for name.");
                    return false;
                }
                else if (name.Length < 2 || name.Length > 9)
                {
                    if (showErrorMessages)
                    {
                        PrintMessage("The name is too long or too short.", MessageType.Error);
                    }
                    //PrintError("The name is too long or too short.");
                    return false;
                }
                else if (!regex.IsMatch(name))
                {
                    if (showErrorMessages)
                    {
                        PrintMessage("The name contains invalid characters.", MessageType.Error); //, "error");
                    }
                    //PrintError("The name contains invalid characters.");
                    return false;
                }
            }
            return true;
        }

        //private void PrintMessage(string message, string messageType)
        private  void PrintMessage(string message, MessageType messageType)
        {
            switch (messageType)
            {
                //case "error":
                case MessageType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                //case "information":
                case MessageType.Information:
                default:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
            }
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        //private void PrintError(string message)
        //{
        //    Console.ForegroundColor = ConsoleColor.Red;
        //    Console.WriteLine(message);
        //    Console.ForegroundColor = ConsoleColor.White;
        //}

        //private void PrintMessage(string message)
        //{
        //    Console.ForegroundColor = ConsoleColor.Green;
        //    Console.WriteLine(message);
        //    Console.ForegroundColor = ConsoleColor.White;
        //}


        private void CleanArrayFromWhiteSpace(string[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = values[i].Trim();
            }
        }

        //private string[] CleanUpArrayOverkill(string[] values)
        //{
        //    string[] cleanedValues = new string[values.Length];
        //    for (int i = 0; i < values.Length; i++)
        //    {
        //        cleanedValues[i] = values[i].Trim();
        //    }
        //    return cleanedValues;
        //}

        private string GetUserInput(string question)
        {
            Console.WriteLine(question);
            string names = Console.ReadLine();
            return names;
        }

        public string[] CreateStringArray(string values, char stringSeparator)
        {
            return values.Split(stringSeparator);
        }

        private void PrintNames(string[] nameList)
        {
            foreach (string name in nameList)
            {
                PrintMessage($"***SUPER-{name.ToUpper()}***", MessageType.Information); //  "info");
                //Console.WriteLine($"***SUPER-{name.ToUpper()}***");
            }
        }

        /// <summary>
        /// Prints all the values in an array based on a template.
        /// </summary>
        /// <param name="items">The array with values.</param>
        /// <param name="template">A string formatted with placeholders, e.g. {0}...</param>
        private void PrintNamesWithTemplate(string[] items, string template)
        {
            foreach (string item in items)
            {
                PrintMessage(string.Format(template, item), MessageType.Information); //  "info");
                //Console.WriteLine(string.Format(template, item));
            }
        }

    }
}
