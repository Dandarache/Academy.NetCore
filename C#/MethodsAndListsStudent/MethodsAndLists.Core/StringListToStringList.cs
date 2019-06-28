using System;
using System.Collections.Generic;
using System.Linq;

namespace MethodsAndLists.Core
{
    public class StringListToStringList
    {
        public IEnumerable<string> GetEverySecondElement(string[] strings)
        {
            List<string> myNewList = new List<string>();

            for (int i = 0; i < strings.Length; i++)
            {
                if (i % 2 == 1)
                {
                    myNewList.Add(strings[i]);
                }
            }

            //int i = 0;
            //foreach (var currentString in strings)
            //{
            //    if (i % 2 == 1)
            //    {
            //        myNewList.Add(currentString);
            //    }
            //    i++;
            //}

            return myNewList;
        }

        public IEnumerable<string> GetEverySecondElement_WithYield(string[] strings)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetEverySecondElement_OneLiner(string[] strings)
        {
            throw new NotImplementedException();

        }

        // Lösning med hjälpmetod:

        public IEnumerable<string> GetEverySecondElement_OneLiner_WithHelpMethod(string[] strings)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> OddNumbersTo(int lastvalue)
        {
            throw new NotImplementedException();
        }

    }
}
