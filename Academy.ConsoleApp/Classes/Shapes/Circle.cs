using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.ConsoleApp.Classes.Shapes
{
    /// <summary>
    /// Class definition for circle.
    /// </summary>
    public class Circle : Shape
    {
        double _radius = 0f;

        public Circle(double radius)
        {
            _radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.Pow(_radius, 2) * Math.PI;
        }
    }
}
