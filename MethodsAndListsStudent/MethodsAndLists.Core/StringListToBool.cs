using System;
using System.Collections.Generic;
using System.Linq;

namespace MethodsAndLists.Core
{
    public class StringListToBool
    {
        public bool AllWordsAreFiveLettersOrLonger(IEnumerable<string> list)
        {
            if (list == null)
            {
                return false;
            }

            bool allWordsAreFiveOrLonger = true;

            foreach (var word in list)
            {
                if (word.Length < 5)
                {
                    allWordsAreFiveOrLonger = false;
                    break;
                }
            }

            return allWordsAreFiveOrLonger;
        }

        public bool AllWordsAreFiveLettersOrLonger_Linq(IEnumerable<string> list)
        {
            if (list == null)
            {
                return false;
            }

            //return !list.Any(a => a.Length < 5);
            return !list.ToList().Exists(a => a.Length < 5);

            //return list == null ? false : !list.ToList().Exists(a => a.Length < 5);
        }
    }
}
