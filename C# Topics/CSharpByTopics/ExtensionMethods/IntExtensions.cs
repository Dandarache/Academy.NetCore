using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpByTopics.ExtensionMethods
{
    public static class IntExtensions
    {
        public static int MultiplyAndAdd3000(
            this int inputValue,
            int factor)
        {
            return ((inputValue * factor) + 3000);
        }
    }
}
