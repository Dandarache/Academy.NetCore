using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.ConsoleApp.Classes
{
    public class Calculator
    {
        public int AddNumbers(int a, int b)
        {
            int sum = a + b; // + 1;
            return sum;
        }

        public int CalculateModulus(int x, int y)
        {
            return x % y;
        }
    }
}
