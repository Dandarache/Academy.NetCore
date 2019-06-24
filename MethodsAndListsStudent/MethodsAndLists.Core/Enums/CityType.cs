using System;
using System.Collections.Generic;
using System.Text;

namespace MethodsAndLists.Core.Enums
{
    public enum CityType
    {
        Large, //   >= 1 000 000
        Medium, //  < 1 000 000 && >=   500 000
        Normal, //  < 500 000   && >=    20 000
        Small, //     < 20 000
        Unknown
    }
}
