using System;
using System.Collections.Generic;
using System.Text;

namespace LinqDemos.Data.Classes
{
    public abstract class Mammal : Animal
    {
        public Mammal(string latinName, bool livesInWater) : base(latinName)
        {
            LivesInWater = livesInWater;
        }

        public bool LivesInWater { get; private set; }
    }
}
