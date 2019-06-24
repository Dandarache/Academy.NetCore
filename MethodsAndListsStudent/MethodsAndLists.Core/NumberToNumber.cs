using System;
using System.Linq;

namespace MethodsAndLists.Core
{
    public class NumberToNumber
    {
        public int SumNumbersTo(int input)
        {
            if (input <= 0)
            {
                throw new ArgumentException();
            }

            return Enumerable.Range(1, input).Sum();
        }

        public int SumNumbersTo_Recursion(int input)
        {
            if (input <= 0)
            {
                throw new ArgumentException();
            }

            if (input == 1)
            {
                return 1;
            }

            return input +  SumNumbersTo_Recursion(input - 1);
        }

        public int SumNumbersTo_OneLineOfCode(int input)
        {
            return input <= 0 ? 
                throw new ArgumentException() : 
                Enumerable
                    .Range(1, input)
                    .Sum();
        }

        public int SumNumbersTo_WithoutLinq(int input)
        {
            if (input <= 0)
            {
                throw new ArgumentException();
            }

            int sum = 0;
            for (int i = 0; i <= input; i++)
            {
                sum += i;
            }

            return sum;

        }

        public int SumNumbers(int from, int to)
        {
            throw new NotImplementedException();
        }

        public int SumNumbersDividedByThreeOrFive(int input)
        {
            throw new NotImplementedException();
        }
    }
}

// 90 / 3 = 30 med resten 0         90 % 3 = 0
// 91 / 3 = 30 med resten 1         91 % 3 = 1
// 92 / 3 = 30 med resten 2         92 % 3 = 2
// 93 / 3 = 31 med reston 0         93 % 3 = 0

