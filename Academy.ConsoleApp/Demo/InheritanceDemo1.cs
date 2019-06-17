using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.ConsoleApp.Demo
{
    public class InheritanceDemo1
    {
        public void Run()
        {
            Animal animal = new Animal("Homo Sapiens");
            Console.WriteLine(animal.LatinName);

            Console.WriteLine();

            Mammal mammal = new Mammal();
            mammal.LatinName = "Homo Sapiens";
            mammal.NumberOfLegs = 2;
            Console.WriteLine(mammal.LatinName);
            Console.WriteLine(mammal.NumberOfLegs);

            Console.WriteLine();

            Human human = new Human();
            human.IsLeftHanded = false;
            human.NumberOfLegs = 2;
            human.LatinName = "Homo Sapiens";
            Console.WriteLine(human.IsLeftHanded);
            Console.WriteLine(human.LatinName);
            Console.WriteLine(human.NumberOfLegs);
        }
    }

    public class Animal
    {
        public string LatinName { get; set; }

        public Animal()
        {

        }
        public Animal(string latinName)
        {
            LatinName = latinName;
        }
    }

    public class Mammal : Animal
    {
        public int NumberOfLegs { get; set; }
    }

    public class Human : Mammal
    {
        public bool IsLeftHanded { get; set; }
    }

}
