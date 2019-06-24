using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.ConsoleApp.Classes.Shapes
{
    /// <summary>
    /// Class definition for rectangle.
    /// </summary>
    public class Rectangle : RoundedShape
    {
        double _width = 0f;
        double _height = 0f;

        public override double CornerRadius { get; set; }

        public Rectangle(double width, double height)
        {
            _width = width;
            _height = height;
        }

        public override double CalculateArea()
        {
            return 2f;
        }

        public override string ToString()
        {
            return $"I'm a rectangle with width = {_width} and height = {_height}";
        }
    }
}
