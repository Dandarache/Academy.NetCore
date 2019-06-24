using System;
using System.Collections.Generic;

namespace MethodsAndLists.Core
{
    public class NumberListToStringList
    {

        public List<string> LongOrShort(List<int> heightList)
        {
            throw new NotImplementedException();
        }

        public List<string> NegativeNumbersIsZip_PositiveNumbersIsZap_ZeroIsBoing(List<int> numbers)
        {
            throw new NotImplementedException();
        }

        public List<string> AddStarsToNumbersHigherThan1000(List<int> numbers)
        {
            List<string> retVal = new List<string>();

            foreach (var number in numbers)
            {
                if (number >= 1000)
                {
                    retVal.Add($"***{number}***");
                }
                else
                {
                    retVal.Add(number.ToString());
                }
            }

            return retVal;
        }

        public List<string> AddStars(List<int> numbers)
        {
            List<string> retVal = new List<string>();

            foreach (var number in numbers)
            {
                //string myString = "***" + number.ToString() + "***";
                //string myString = $"***{number.ToString()}***";
                //retVal.Add(myString);

                retVal.Add($"***{number.ToString()}***");

            }

            return retVal;

        }
    }
}