using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.ConsoleApp.Classes.Shapes
{
    public abstract class RoundedShape : Shape
    {
        public abstract double CornerRadius { get; set; }
    }
}
