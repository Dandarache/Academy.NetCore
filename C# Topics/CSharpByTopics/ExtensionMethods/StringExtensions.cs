using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CSharpByTopics.ExtensionMethods
{

    public static class StringExtensions
    {
        public static string Reverse(this string inputString)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = inputString.Length - 1; i >= 0; i--)
            {
                sb.Append(inputString[i]);
            }
            return sb.ToString();
        }

        public static string Delimit(this string inputString, string delimiter)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < inputString.Length; i++)
            {
                if (i > 0)
                {
                    sb.Append(delimiter);
                }
                sb.Append(inputString[i]);
            }
            return sb.ToString();
        }

        public static string Repeat(this string inputString, int repeatCount)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < repeatCount; i++)
            {
                sb.Append(inputString);
            }
            return sb.ToString();
        }

        public static string TakeOnlyTwoWords(this string myValue)
        {
            string myResult = string.Empty;

            string[] myWords = myValue.Split(' ');
            if (myWords.Length <= 2)
            {
                return myValue;
            }

            if (myWords.Length > 2)
            {
                myResult = myWords[0] + " " + myWords[1];
            }

            return myResult;
        }

        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
