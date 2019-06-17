using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.ConsoleApp.Demo
{
    public abstract class RoundedShape : Shape
    {
        public abstract double CornerRadius { get; set; }
    }
}
