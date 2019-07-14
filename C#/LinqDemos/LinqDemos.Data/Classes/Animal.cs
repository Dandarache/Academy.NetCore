using System;
using System.Collections.Generic;
using System.Text;

namespace LinqDemos.Data.Classes
{
    public abstract class Animal
    {
        // readonly innebär att variabeln bara kan sättas mha konstruktorn
        private readonly string _latinName;

        public Animal(string latinName)
        {
            _latinName = latinName;
        }

        public string LatinName
        {
            get
            {
                return _latinName;
            }
        }
    }
}
