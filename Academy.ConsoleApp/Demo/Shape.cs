using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.ConsoleApp.Demo
{
    /// <summary>
    /// Base class for all shapes in this exercise.
    /// </summary>
    public abstract class Shape
    {
        public abstract double CalculateArea();

        //public abstract int NumberOfFoos();

        public string HelloType()
        {
            return $"Hello {this.GetType()}";
        }
    }
}
