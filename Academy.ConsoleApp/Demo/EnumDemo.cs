using Academy.ConsoleApp.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.ConsoleApp.Demo
{
    public class EnumDemo
    {
        public void Run()
        {
            // en ändring 

            // Parse enum value.
            var gender1 = Enum.Parse(typeof(GenderType), "Female");
            Console.WriteLine(gender1);
            Console.WriteLine();

            // TryParse enum value.
            Enum.TryParse(typeof(GenderType), "Male", out object gender2);
            Console.WriteLine(gender2);
            Console.WriteLine();

            // Loop enum values.
            foreach (var enumValue in Enum.GetValues(typeof(GenderType)))
            {
                Console.WriteLine($"{enumValue.ToString()} = {enumValue.GetHashCode()}");
            }
        }
    }
}
