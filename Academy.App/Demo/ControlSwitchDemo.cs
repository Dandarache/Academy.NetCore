using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.App.Demo
{
    public class ControlSwitchDemo
    {
        public void Run()
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();


            Console.WriteLine("What is your country?");
            string country = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            string greeting = string.Empty;
            switch (country)
            {
                case "norway":
                    greeting = $"God dag, {name}!";
                    break;
                case "sweden":
                    greeting = $"God dag, {name}!";
                    break;
                case "germany":
                    greeting = $"Guten tag, {name}!";
                    break;
                case "english":
                default:
                    greeting = $"Good day, {name}!";
                    break;
            }
            Console.WriteLine(greeting);

            Console.ForegroundColor = ConsoleColor.White;
        }
    }

}
