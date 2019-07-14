using System;
using System.Collections.Generic;
using System.Text;

namespace LinqDemos.Data.Classes
{
    public class Dog : Mammal
    {
        public Dog(string name) : base("Lupus Familiaris", false)
        {
        }
        public Dog(string name, string latinName) : base(latinName, false)
        {
            Name = name;
        }

        public string Name { get; set; }
        public HairStyle HairStyle { get; set; }
        public string Breed { get; set; }
        public GenderType Gender { get; set; }
        public DateTime BirthDate { get; set; }
        
    }
}
