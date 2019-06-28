//using Academy.ConsoleApp.Demo.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.ConsoleApp.Demo
{
    public class FundamentalsDemo2
    {
        public void Run()
        {
            int currentHour = DateTime.Now.Hour;
            Console.WriteLine(currentHour);
            
            
            ////////////////////////
            /////// C8 - Switch
            ////////////////////////

            Console.WriteLine("Enter process instruction please!");
            string processInstruction = Console.ReadLine();

            //// XXX_99999_99999_99XX-X
            string[] inputValues = processInstruction.Split('_');

            if (inputValues.Length != 4)
            {
                Console.WriteLine("This is not a valid process instruction!");
            }
            else
            {

                string baseInstruction = inputValues[0];

                string returnMessageInstruction = string.Empty;

                switch (baseInstruction)
                {
                    case "ABC": // Create new product...
                        returnMessageInstruction = "CREATED PRODUCT";
                        break;
                    case "DEF": // Update product..
                        returnMessageInstruction = "UPDATED PRODUCT";
                        break;
                    case "GHI": // Revert product...
                        returnMessageInstruction = "REVERTED PRODUCT";
                        break;
                    case "ZXY": // Super product...
                        returnMessageInstruction = "SUPER PRODUCT";
                        break;
                    // ... = Default message
                    default:
                        returnMessageInstruction = "NO CHANGES";
                        break;
                }

                Console.WriteLine($"Program succeeded: {returnMessageInstruction}");
            }


            //// Om XXX = AHJ
            //// -> Anropa metod X med resterande data
            //if (processInstruction.StartsWith("AHJ_"))
            //{
            //    // Om resterande grupp 1 = 15352
            //    // -> Sätt flagga för extra kontroll till true

            //}

            //// Om XXX = GHJ
            //// -> Anropa metod Y
            //// Annars anropa metod Z



            ////////////////////////
            /////// C7 - Conditional statement
            ////////////////////////

            Random random = new Random();
            int myValue = random.Next(1, 6);
            //int myValue = GetStatusValue();

            //if (myValue > 3)
            //{
            //    Console.WriteLine($"The value '{myValue}' is higher than 3.");
            //}
            //else
            //{
            //    Console.WriteLine($"The value '{myValue}' is lower or equal to 3.");
            //}

            //string compareString = $"{(myValue == 3 ? "equal" : myValue > 3 ? "higher" : "lower")}";
            //Console.WriteLine($"The value '{myValue}' is {compareString}.");
            ////Console.WriteLine($"The value '{myValue}' is {(myValue > 3 ? "higher" : "lower or equal")} than 3.");

            //Person person = new Person("Dan", "Jansson", 47, new DateTime(1972, 1, 11));
            ////Person person = new Person("Dan", "Jansson", 47, DateTime.MinValue);

            //string birthDateString =
            //    person.BirthDate == DateTime.MinValue ? "Not valid" : person.BirthDate.ToString("yyyy-MM-dd");
            //Console.WriteLine($"Birthdate: {birthDateString}");



            //new SwitchDemo().Run();


        }

        private int GetStatusValue()
        {
            Random random = new Random();
            int foo = random.Next(1, 6); ;

            return foo;
        }
    }
}
