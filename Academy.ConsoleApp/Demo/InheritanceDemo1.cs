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

            Cat cat1 = new Cat();
            cat1.MjauFactor = 127;
            cat1.NumberOfLegs = 4;
            cat1.LatinName = "Felis catus";

            Dog dog1 = new Dog();
            dog1.BarkLevel = 42;
            dog1.NumberOfLegs = 4;
            dog1.LatinName = "Canis lupus familiaris";

            Dog dog2 = new Dog();
            dog2.BarkLevel = 19;
            dog2.NumberOfLegs = 4;
            dog2.LatinName = "Canis lupus familiaris";

            // Polymorphism
            List<Mammal> mammals = new List<Mammal>();
            mammals.Add(human);
            mammals.Add(cat1);
            mammals.Add(dog1);
            mammals.Add(dog2);
            // Animal is not inheriting the Mammal class.
            //mammals.Add(animal);

            foreach (var mammalItem in mammals)
            {
                Console.WriteLine(mammalItem.LatinName);
            }

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

    public class Cat : Mammal
    {
        public int MjauFactor { get; set; }
        //public string Breed { get; set; }
    }

    public class Dog : Mammal
    {
        public int BarkLevel { get; set; }
        //public string Breed { get; set; }
    }
}
