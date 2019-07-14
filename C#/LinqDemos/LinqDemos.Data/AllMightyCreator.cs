using LinqDemos.Data.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinqDemos.Data
{
    public static class AllMightyCreator
    {
        // Konstanter kan aldrig ändras i runtime
        public const string CatDefaultName = "cat";
        public const string DogDefaultName = "dog";
        public const string AntilopeDefaultName = "antilope";
        public const string HamsterDefaultName = "hamster";
        public const string HorseDefaultName = "horse";
        public const string ZebraDefaultName = "zebra";

        // Method overloading
        public static Dog CreateDog(string name)
        {
            return new Dog(name);
        }
        // Method overloading
        public static Dog CreateDog(string name, string latinName)
        {
            return new Dog(name, latinName);
        }

        public static Cat CreateCat(string name)
        {
            return null;
        }

    }
}
