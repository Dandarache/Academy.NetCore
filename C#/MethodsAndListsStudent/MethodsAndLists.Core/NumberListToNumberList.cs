using System;
using System.Collections.Generic;
using System.Linq;

namespace MethodsAndLists.Core
{
    public class NumberListToNumberList
    {
        public List<int> Add70ToEverySecondElement(List<int> numbers)
        {
            List<int> returnValue = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                int myCalculatedValue = numbers[i];
                if (i % 2 == 1)
                {
                    myCalculatedValue = myCalculatedValue + 70;
                    //myCalculatedValue += 70;
                }
                returnValue.Add(myCalculatedValue);
            }

            return returnValue;
        }

        public List<int> Add50ToFirstThreeElements(List<int> numbers)
        {
            List<int> returnValues = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (i < 3)
                {
                    returnValues.Add(numbers[i] + 50);
                }
                else
                {
                    returnValues.Add(numbers[i]);
                }
            }

            return returnValues;
        }

        public List<int> Add50ToFirstThreeElements_Linq(List<int> numbers)
        {
            List<int> retVal = new List<int>();

            List<int> first = numbers.Take(3).Select(a => a + 50).ToList();
            retVal.AddRange(first);

            List<int> last = numbers.Skip(3).Select(a => a).ToList();
            retVal.AddRange(last);

            return retVal;
        }

        public List<int> NegateEachNumber(List<int> numbers)
        {
            List<int> retval = new List<int>();

            foreach (var number in numbers)
            {
                retval.Add(-number);
            }

            return retval;
        }

        public List<int> DivideEachNumberBy100(List<int> numbers)
        {
            List<int> returnValues = new List<int>();

            foreach (var number in numbers)
            {
                returnValues.Add(number / 100);
            }

            return returnValues;
        }

        public List<int> DivideEachNumberBy100_Linq(List<int> numbers)
        {
            throw new NotImplementedException();
        }

        public List<int> GetNumbersDividableByFive(List<int> numbers)
        {
            List<int> returnValues = new List<int>();

            foreach (var number in numbers)
            {
                if (number % 5 == 0)
                {
                    returnValues.Add(number);
                }
            }

            return returnValues;
        }

        public List<int> GetNumbersDividableByFive_Linq(List<int> numbers)
        {
            throw new NotImplementedException();
        }

        public List<int> GetNumbersHigherThan1000(List<int> numbers)
        {
            List<int> returnValues = new List<int>();

            foreach (var number in numbers)
            {
                if (number >= 1000)
                {
                    returnValues.Add(number);
                }
            }

            return returnValues;
        }

        public List<int> GetNumbersHigherThan1000_Linq(List<int> numbers)
        {
            throw new NotImplementedException();
        }


        public List<int> Add100ToEachNumber(List<int> numbers)
        {
            List<int> returnValues = new List<int>();

            foreach (var number in numbers)
            {
                int newValue = number + 100;
                returnValues.Add(newValue);
            }

            return returnValues;
        }

        public List<int> Add100ToEachNumber_Linq(List<int> numbers)
        {
            throw new NotImplementedException();
        }
    }
}